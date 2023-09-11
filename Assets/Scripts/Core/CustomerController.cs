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

        private Action<CustomerController> customerLeaveCallback = null;

        public void SetupOrder (CustomerVO customer, float waitTimePerVeg, Action<CustomerController> callback)
        {
            customerData = customer;
            customerLeaveCallback = callback;

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
            timeMultiplier = 1;
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
                timer -= Time.deltaTime * timeMultiplier;
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

            customerLeaveCallback?.Invoke (this);
        }

        public void SubmitOrder (SaladVO salad, int playerId)
        {
            if (customerData != null && salad != null)
            {
                if (isOrderCorrect (salad))
                {
                    // reward the player with matching player id
                    if (timerCoroutine != null)
                    {
                        StopCoroutine (timerCoroutine);
                    }

                    customerLeaveCallback?.Invoke (this);
                }
                else
                {
                    customerData.CustomerMood = CustomerMoodsEnum.ANGRY;
                    orderView.UpdateMood (customerData.CustomerMood);
                    timeMultiplier += 0.5f;
                    moodSwitchedByPlayer = playerId;
                }
            }
        }

        private bool isOrderCorrect (SaladVO salad)
        {
            bool orderCorrect = false;

            if (salad != null && customerData != null)
            {
                if (salad.VegetablesList.Count == customerData.CustomerOrder.VegetablesList.Count)
                {
                    orderCorrect = true;
                    for (int i = 0 ; i < salad.VegetablesList.Count ; i++)
                    {
                        if ( salad.VegetablesList [i] != customerData.CustomerOrder.VegetablesList [i] )
                        {
                            orderCorrect = false;
                            break;
                        }
                    }
                }
            }

            return orderCorrect;
        }
    }
}
