using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class OrderItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI orderText = null;
    
        [SerializeField]
        private Image orderTimerImage = null;

        [SerializeField]
        private Image angryIndicatorImage = null;
    
        public void InitializeOrder (string order, CustomerMoodsEnum mood)
        {
            orderText.text = order;
            UpdateMood (mood);
        }

        public void UpdateMood (CustomerMoodsEnum mood)
        {
            if (angryIndicatorImage != null 
                && mood == CustomerMoodsEnum.ANGRY)
            {
                angryIndicatorImage.gameObject.SetActive (true);
            }
            else
            {
                angryIndicatorImage.gameObject.SetActive (false);
            }
        }
    
        public void UpdateTimerSlider (float sliderValue)
        {
            orderTimerImage.fillAmount = sliderValue;
        }
    }
}
