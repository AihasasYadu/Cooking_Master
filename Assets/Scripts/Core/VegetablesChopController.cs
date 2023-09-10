using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using Scripts.Views;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class VegetablesChopController : MonoBehaviour
    {
        [SerializeField]
        private Image timerImage = null;
    
        [SerializeField]
        private TextMeshProUGUI vegOnBoardText = null;
    
        [SerializeField]
        private SaladItemView saladPlate = null;

        private bool isChopping = false;
        public bool IsChopping 
        {
            get
            {
                return isChopping;
            }

            private set
            {
                isChopping = value;
            }
        }
    
        private int chopForPlayerId = 0;
        public int ChopsForPlayerId
        {
            get
            {
                return chopForPlayerId;
            }
    
            private set
            {
                chopForPlayerId = value;
            }
        }
    
        private VegetableItemView choppingVegetable = null;
    
        private float chopTime = 0;
    
        private float timer = 0;
    
        public void Start ()
        {
            timer = 0;
            if (vegOnBoardText != null)
            {
                vegOnBoardText.text = string.Empty;
            }
        }
    
        public void Initialize (float chopTimerPerVeg, int playerId)
        {
            chopTime = chopTimerPerVeg;
            chopForPlayerId = playerId;
            timerImage.fillAmount = 0;
        }
    
        public void ChopVegetable (VegetableItemView veg)
        {
            IsChopping = true;
            choppingVegetable = veg;
            vegOnBoardText.text = veg.VegetableType.ToString ();
            StartCoroutine (chopTimer ());
        }
    
        private IEnumerator chopTimer ()
        {
            timer = 0;
            while (timer < chopTime)
            {
                timer += Time.deltaTime;
                timerImage.fillAmount = timer / chopTime;
    
                yield return null;        
            }
    
            timerImage.fillAmount = 0;
            moveVegToSalad ();
        }
    
        private void moveVegToSalad ()
        {
            saladPlate.AddVegToSalad (choppingVegetable.VegetableType);
            vegOnBoardText.text = string.Empty;
            IsChopping = false;
        }
    }
}
