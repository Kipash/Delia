using UnityEngine;
using System.Collections;
using System.Linq;

using AppBackend;
using Zenject;

namespace PROJECT_HUSKY
{
    public class BlockController : MonoBehaviour, IInitializable
    {
        [Header("Block")]
        public DistrictData DistrictData;

        [Header("Retail")]
        public RetailData RetailData;

        [Header("Temp - testing => remove")]
        [SerializeField] CharacterComponent[] characters;

        [Inject] OnNewHour onNewHour;

        public void OnSelecting()
        {
            
        }

        public void Initialize()
        {
            /*
            DistrictData.SelectLevel(1);
            RetailData.SelectLevel(1);
            RetailData.IsOwned = false;
            

            for (int i = 0; i < characters.Length; i++)
            {
                RetailData.AddCharacter(characters[i].Data);
            }
            */
            onNewHour.Listen(OnNewHour_Handler);
        }
        void OnNewHour_Handler()
        {
            if (!RetailData.IsOwned)
            {
                if (Random.Range(0, 17) == 7)
                {
                    RetailData.IsOwned = true;
                    Debug.Log("Bought");
                }
            }
            else
            {
                if(Random.Range(0, 7) == 3 && DistrictData.CurrentLevel < 3)
                {
                    DistrictData.SelectLevel(DistrictData.CurrentLevel + 1);
                }
                if (Random.Range(0, 7) == 3 && RetailData.CurrentLevel < 3)
                {
                    RetailData.SelectLevel(RetailData.CurrentLevel + 1);
                }
            }
        }

    }
}