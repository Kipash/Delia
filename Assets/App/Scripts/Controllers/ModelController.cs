using UnityEngine;
using System;
using System.Collections;

namespace PROJECT_HUSKY
{
    [Serializable]
    public class ModelController
    {
        [SerializeField] ModelLevel[] levels;
        [HideInInspector] public int LandValue;
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get { return levels.Length; } }
        /* Debug */

        public void SelectLevel(int level)
        {
            CurrentLevel = level;
            level -= 1;
            if (!(level >= 0 && level < levels.Length))
                return;

            levels[level].SetState(true);
            //LandValue = levels[level].MinLandValue;

            for (int i = 0; i < levels.Length; i++)
            {
                if (i == level)
                    continue;
                levels[i].SetState(false);
            }
        }
    }
}