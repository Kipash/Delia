using UnityEngine;
using System.Collections;
using Zenject;

namespace PROJECT_HUSKY
{
    public class BlockManager : IInitializable
    {
        [Inject] OnBlockSelect onBlockSelect;
        public void Initialize()
        {
            onBlockSelect.Listen(OnBlockSelect_Handler);
        }

        void OnBlockSelect_Handler(BlockController blockController)
        {
            //blockController
        }
    }
}