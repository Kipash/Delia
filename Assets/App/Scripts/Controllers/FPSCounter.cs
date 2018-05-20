using UnityEngine;
using System.Collections;

namespace PROJECT_HUSKY
{
    public class FPSCounter : MonoBehaviour
    {
        public int AverageFPS { get; private set; }
        public int HighestFPS { get; private set; }
        public int LowestFPS { get; private set; }

        [SerializeField] int frameRange = 60;

        int[] fpsBuffer;
        int fpsBufferIndex;

        void Update()
        {
            if (fpsBuffer == null || fpsBuffer.Length != frameRange)
                InitializeBuffer();

            UpdateBuffer();
            CalculateFPS();
        }
        void InitializeBuffer()
        {
            if (frameRange <= 0)
                frameRange = 1;
            fpsBuffer = new int[frameRange];
            fpsBufferIndex = 0;
        }
        void UpdateBuffer()
        {
            fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
            if (fpsBufferIndex >= frameRange)
                fpsBufferIndex = 0;
        }
        void CalculateFPS()
        {
            int highest = 0;
            int lowest = int.MaxValue;
            int sum = 0;
            for (int i = 0; i < frameRange; i++)
            {
                int fps = fpsBuffer[i];
                sum += fps;
                if (fps > highest)
                    highest = fps;
                if (fps < lowest)
                    lowest = fps;
            }
            AverageFPS = sum / frameRange;
            HighestFPS = highest;
            LowestFPS = lowest;
        }
    }
}