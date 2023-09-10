using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using TMPro;
using UnityEngine;

namespace Scripts.Views
{
    public class SaladItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI saladText = null;
    
        private List<VegetablesEnum> saladCombinationList = null;
    
        public void Start ()
        {
            saladCombinationList = new List<VegetablesEnum>();
            if (saladText != null)
            {
                saladText.text = string.Empty;
            }
        }
    
        public void AddVegToSalad (VegetablesEnum veg)
        {
            if (saladCombinationList != null && veg != VegetablesEnum.NONE)
            {
                saladCombinationList.Add (veg);
                addSaladText (veg.ToString ());
            }
        }
    
        private void addSaladText (string veg)
        {
            if (saladCombinationList != null)
            {
                saladText.text += veg;
            }
        }
    
        public SaladVO PickSaladPlate ()
        {
            SaladVO salad = null;
            if (saladCombinationList != null)
            {
                salad = new SaladVO();
                salad.VegetablesList = saladCombinationList;
                saladCombinationList.Clear ();
                saladText.text = string.Empty;
            }
    
            return salad;
        }
    }
}