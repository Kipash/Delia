using UnityEngine;
using System;
using System.Collections;

namespace PROJECT_HUSKY
{
    [Serializable]
    public class RetailData : ModelController
    {
        public int CharacterCount { get; private set; }
        [HideInInspector] public CharacterData[] CharacterSlots { get; private set; } = new CharacterData[3];

        public bool IsOwned;
        public int Income { get; private set; }
        [SerializeField] int basicIncome;

        public void AddCharacter(CharacterData data)
        {
            CharacterCount++;
            for (int i = 0; i < CharacterSlots.Length; i++)
            {
                if (CharacterSlots[i] == null)
                {
                    CharacterSlots[i] = data;
                }
            }
            UpdateData();
        }

        public void UpdateData()
        {
            // (basicIncome + chracers) * level

            Income = (basicIncome + CharacterCount) * CurrentLevel;
        }
    }
}