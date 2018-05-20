using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Skyrise
{
    public class UIGameManager : MonoBehaviour
    {
        /*

        #region Block info panel
        [Header("Block info panel")]
        [SerializeField] GameObject BlockInfoPanel;

        [SerializeField] Text districtLevel;
        [SerializeField] Text districtLandValue;

        [SerializeField] Text retailLevel;
        [SerializeField] Text retailLandValue;
        [SerializeField] Text retailIncome;
        [SerializeField] Text retailChracters;
        [SerializeField] Button retailBuyButton;
        [SerializeField] Button districtBuyButton;
        #endregion

        [Header("HUD")]
        public Text MoneyLabel;
        public Text TimeLabel;
        public Text DateLabel;

        public void Initialize()
        {
            retailBuyButton.onClick.AddListener(new UnityAction(GameServices.Instance.BlockManager.BuyRetail));
            districtBuyButton.onClick.AddListener(new UnityAction(GameServices.Instance.BlockManager.BuyDistrict));
        }

        public void ShowBlockInfo(RetailData retailData, DistrictData districtData)
        {
            BlockInfoPanel.SetActive(true);

            districtLevel.text = string.Format("Level {0} / {1}", districtData.CurrentLevel, districtData.MaxLevel);
            districtLandValue.text = "Land value " + districtData.LandValue;

            retailLevel.text = string.Format("Level {0} / {1}", retailData.CurrentLevel, retailData.MaxLevel);
            retailLandValue.text = "Land value " + retailData.LandValue;
            retailIncome.text = "Income " + retailData.Income;

            retailChracters.text = "Characters " + retailData.CharacterCount;
        }
        public void HideBlockInfo()
        {
            BlockInfoPanel.SetActive(false);
        }
        public void SetTime(DateTime t)
        {
            TimeLabel.text = (t.Hour < 10 ? "0" + t.Hour : t.Hour.ToString()) + ":" +
                              (t.Minute < 10 ? "0" + t.Minute : t.Minute.ToString()) + ":" +
                              (t.Second < 10 ? "0" + t.Second : t.Second.ToString());
        }
        public void SetDate(DateTime t)
        {
            DateLabel.text = (t.Day < 10 ? "0" + t.Day : t.Day.ToString()) + "/" +
                              (t.Month < 10 ? "0" + t.Month : t.Month.ToString()) + "/" +
                              "0000".Substring(t.Year.ToString().Length) + t.Year.ToString();
        }
        public void SetMoney(int money)
        {
            MoneyLabel.text = money + "$";
        }
        */
    }
}