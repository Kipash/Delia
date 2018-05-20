using UnityEngine;
using System.Collections;
using System.Linq;

namespace PROJECT_HUSKY
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] LayerMask mask;

        Vector3 panMotion;
        float zoomMotion;
        float rotateMotion;

        RaycastHit[] hits = new RaycastHit[10];
        void LateUpdate()
        {
            panMotion.x = (Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0)) * Time.deltaTime * 100;
            panMotion.z = (Input.GetKey(KeyCode.S) ? -1 : (Input.GetKey(KeyCode.W) ? 1 : 0)) * Time.deltaTime * 100;

            zoomMotion = (Input.GetKey(KeyCode.DownArrow) ? -1 : (Input.GetKey(KeyCode.UpArrow) ? 1 : 0)) * Time.deltaTime * 100;

            rotateMotion = (Input.GetKey(KeyCode.LeftArrow) ? -1 : (Input.GetKey(KeyCode.RightArrow) ? 1 : 0)) * Time.deltaTime * 100;

            transform.position += transform.right * panMotion.x;
            transform.position += transform.forward * panMotion.z;

            transform.Rotate(new Vector3(0, rotateMotion));

            Camera.main.transform.position += Camera.main.transform.forward * zoomMotion;
        }
        void Update()
        {
            /*
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                int count = Physics.RaycastNonAlloc(ray, hits, 600, mask, QueryTriggerInteraction.Ignore);

                
                //not sure if this is still necessary
                hits = hits.OrderBy(x => Vector3.Distance(Camera.main.transform.position, x.point)).ToArray();
                

                for (int i = 0; i < count; i++)
                {
                    BlockComponent component = hits[i].collider.gameObject.GetComponentInParent<BlockComponent>();
                    if (component != null)
                    {
                        component.OnSelecting();
                        break;
                    }
                }
            }
            */
        }


        /* Touch Control
        [SerializeField] float speed;
        [SerializeField] float rotationSpeed;

        Vector3 rotationDeg;
        Vector3 panDelta;
        Quaternion desiredRotation;
        float pinchAmount = 0;

        void LateUpdate()
        {
            desiredRotation = transform.rotation;
            pinchAmount = 0;

            DetectTouchMovement.Calculate();


            if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0)
            { // zoom
                pinchAmount = DetectTouchMovement.pinchDistanceDelta;
            }
            else if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
            { // rotate
                rotationDeg = Vector3.zero;
                rotationDeg.y = -DetectTouchMovement.turnAngleDelta * rotationSpeed;
                desiredRotation *= Quaternion.Euler(rotationDeg);
            }
            else if(DetectTouchMovement.PanDelta != Vector3.zero)
            {
                transform.position += transform.right * DetectTouchMovement.PanDelta.x * Time.deltaTime * speed;
                transform.position += transform.forward * DetectTouchMovement.PanDelta.y * Time.deltaTime * speed;
            }

            transform.rotation = desiredRotation;
            transform.position += Camera.main.transform.forward * Time.deltaTime * pinchAmount;
        }
        */
    }
}