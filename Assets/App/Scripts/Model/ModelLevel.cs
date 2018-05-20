using UnityEngine;
using System.Collections;
using System;

namespace PROJECT_HUSKY
{
    [Serializable]
    public class ModelLevel
    {
        [SerializeField] string name;
        public GameObject[] Gfx;
        public int MinLandValue;

        public void SetState(bool state)
        {
            for (int i = 0; i < Gfx.Length; i++)
            {
                Gfx[i].SetActive(state);
            }
        }
    }
}