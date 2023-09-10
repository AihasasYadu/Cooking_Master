using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using TMPro;
using UnityEngine;

namespace Scripts.Views
{
    public class VegetableItemView : MonoBehaviour
    {
        [SerializeField]
        private VegetablesEnum vegetableType = VegetablesEnum.NONE;
        public VegetablesEnum VegetableType
        {
            get
            {
                return vegetableType;
            }

            private set
            {
                vegetableType = value;
            }
        }

        [SerializeField]
        private TextMeshProUGUI vegetableText = null;

        public void Initialize ( VegetablesEnum veg )
        {
            VegetableType = veg;

            if ( vegetableText != null )
            {
                vegetableText.text = VegetableType.ToString ();
            }
        }
    }
}
