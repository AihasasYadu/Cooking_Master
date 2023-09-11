using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using Scripts.Views;
using Scripts.VO;
using UnityEngine;

namespace Scripts.Core
{
    // handles individual customers
    public class CustomerController : MonoBehaviour
    {
        [SerializeField]
        private OrderItemView orderView = null;

        private CustomerVO customerData = null;

        private float orderTime = 0;
    
        private float timer = 0;

        private float timeMultiplier = 0;

        private int moodSwitchedByPlayer = 0;

        private Coroutine timerCoroutine = null;

        public void SetupOrder (CustomerVO customer, int waitTimePerVeg)
        {
            customerData = customer;

            string order = string.Empty;
            if (customerData.CustomerOrder != null)
            {
                for (int i = 0 ; i < customerData.CustomerOrder.VegetablesList.Count ; i++)
                {
                    orderTime += waitTimePerVeg;
                    order += customerData.CustomerOrder.VegetablesList [i].ToString ();
                }
            }
            orderView.InitializeOrder (order, customerData.CustomerMood);
        }

        public void StartWaiting ()
        {
            timerCoroutine = StartCoroutine (startOrderTimer ());
        }
    
        private IEnumerator startOrderTimer ()
        {
            timer = orderTime;
            while (timer > 0)
            {
                timer -= Time.deltaTime * orderTime * timeMultiplier;
                orderView.UpdateTimerSlider ( timer / orderTime );
    
                yield return new WaitForEndOfFrame ();        
            }
    
            timer = 0;
            timeRunout ();
        }

        private void timeRunout ()
        {
            if (moodSwitchedByPlayer == 0)
            {
                // deduct points from both the players
            }
            else
            {
                // deduct double points from player matching player id
            }
        }

        public void SubmitOrder (SaladVO salad, int playerId)
        {
            if (customerData != null && salad != null)
            {
                if (salad.Equals (customerData.CustomerOrder))
                {
                    // reward the player with matching player id

                    if (timerCoroutine != null)
                    {
                        StopCoroutine (timerCoroutine);
                    }
                }
                else
                {
                    customerData.CustomerMood = CustomerMoodsEnum.ANGRY;
                    timeMultiplier = 1.5f;
                    moodSwitchedByPlayer = playerId;
                }
            }
        }
    }
}
