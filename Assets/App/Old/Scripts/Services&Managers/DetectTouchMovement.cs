using UnityEngine;
using System.Collections;

namespace Skyrise
{
    public class DetectTouchMovement
    {
        const float pinchTurnRatio = Mathf.PI / 2;
        const float minTurnAngle = 1;

        const float pinchRatio = 1;
        const float minPinchDistance = 3;

        const float panRatio = 1;
        const float minPanDistance = 0;


        static Touch touch1;
        static Touch touch2;


        /// <summary>
        ///   The delta of the motion while only one finger is present
        /// </summary>
        static public Vector3 PanDelta;

        /// <summary>
        ///   The delta of the angle between two touch points
        /// </summary>
        static public float turnAngleDelta;
        /// <summary>
        ///   The angle between two touch points
        /// </summary>
        static public float turnAngle;

        /// <summary>
        ///   The delta of the distance between two touch points that were distancing from each other
        /// </summary>
        static public float pinchDistanceDelta;
        /// <summary>
        ///   The distance between two touch points that were distancing from each other
        /// </summary>
        static public float pinchDistance;

        /// <summary>
        ///   Calculates Pinch and Turn - This should be used inside LateUpdate
        /// </summary>
        /// 
        static public void Calculate()
        {
            pinchDistance = pinchDistanceDelta = 0;
            turnAngle = turnAngleDelta = 0;
            PanDelta = Vector3.zero;

            // if two fingers are touching the screen at the same time ...
            if (Input.touchCount == 2)
            {
                touch1 = Input.touches[0];
                touch2 = Input.touches[1];

                // ... if at least one of them moved ...
                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    // ... check the delta distance between them ...
                    pinchDistance = Vector2.Distance(touch1.position, touch2.position);
                    float prevDistance = Vector2.Distance(touch1.position - touch1.deltaPosition,
                                                          touch2.position - touch2.deltaPosition);
                    pinchDistanceDelta = pinchDistance - prevDistance;

                    // ... if it's greater than a minimum threshold, it's a pinch!
                    if (Mathf.Abs(pinchDistanceDelta) > minPinchDistance)
                    {
                        pinchDistanceDelta *= pinchRatio;
                    }
                    else
                    {
                        pinchDistance = pinchDistanceDelta = 0;
                    }

                    // ... or check the delta angle between them ...
                    turnAngle = Angle(touch1.position, touch2.position);
                    float prevTurn = Angle(touch1.position - touch1.deltaPosition,
                                           touch2.position - touch2.deltaPosition);
                    turnAngleDelta = Mathf.DeltaAngle(prevTurn, turnAngle);

                    // ... if it's greater than a minimum threshold, it's a turn!
                    if (Mathf.Abs(turnAngleDelta) > minTurnAngle)
                    {
                        turnAngleDelta *= pinchTurnRatio;
                    }
                    else
                    {
                        turnAngle = turnAngleDelta = 0;
                    }
                }
            }
            else if (Input.touchCount == 1)
            {
                touch1 = Input.touches[0];

                PanDelta = touch1.deltaPosition * -1;

            }
        }

        static private float Angle(Vector2 pos1, Vector2 pos2)
        {
            Vector2 from = pos2 - pos1;
            Vector2 to = new Vector2(1, 0);

            float result = Vector2.Angle(from, to);
            Vector3 cross = Vector3.Cross(from, to);

            if (cross.z > 0)
            {
                result = 360f - result;
            }

            return result;
        }
    }
}