using UnityEngine;
using System;
using System.Collections;

namespace PROJECT_HUSKY
{
    [Serializable]
    public class CharacterData
    {
        [Range(1, 10)] public int Power;
        [Range(1, 10)] public int Charisma;
        public int Level = 1;

        public CharacterSpecialization Specialization;

        public CharacterComponent Component;
    }
}