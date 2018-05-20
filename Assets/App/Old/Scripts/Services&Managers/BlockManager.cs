using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Skyrise
{
    [Serializable]
    public class BlockManager
    {
        /*
        public BlockController CurrentBlock { get; private set; }

        public void Select(BlockController block)
        {
            CurrentBlock = block;

            GameServices.Instance.UI.ShowBlockInfo(block.RetailData, block.DistrictData);
        }
        public void BuyDistrict()
        {
            //TODO: disable button when this is true
            if (CurrentBlock.DistrictData.MaxLevel <= CurrentBlock.DistrictData.CurrentLevel)
                return;

            CurrentBlock.DistrictData.LandValue += 10;
            CurrentBlock.DistrictData.SelectLevel(CurrentBlock.DistrictData.CurrentLevel + 1);

            GameServices.Instance.UI.ShowBlockInfo(CurrentBlock.RetailData, CurrentBlock.DistrictData);
        }
        public void BuyRetail()
        {
            //TODO: disable button when this is true
            if (CurrentBlock.RetailData.MaxLevel <= CurrentBlock.RetailData.CurrentLevel)
                return;
            if(!CurrentBlock.RetailData.IsOwned)
                CurrentBlock.RetailData.IsOwned = true;

            CurrentBlock.RetailData.LandValue += 10;
            CurrentBlock.RetailData.SelectLevel(CurrentBlock.RetailData.CurrentLevel + 1);

            GameServices.Instance.UI.ShowBlockInfo(CurrentBlock.RetailData, CurrentBlock.DistrictData);
        }
        */
    }
}