using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scripts.Enums;
using Scripts.Views;
using Scripts.VO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerController> playersList = null;

        [SerializeField]
        private InputActionAsset inputAsset;

        [SerializeField]
        private Transform leftVegCounter = null;

        [SerializeField]
        private Transform rightVegCounter = null;

        [SerializeField]
        private LevelConfigData levelConfigData = null;

        [SerializeField]
        private VegetableItemView vegetableItemPrefab = null;

        [SerializeField]
        private CustomerController customerPrefab = null;

        [SerializeField]
        private Transform orderCounterTransform = null;

        [SerializeField]
        private List<VegetablesChopController> choppingBoardList = null;

        private List<CustomerController> customersOnCounterList = null;

        private Queue<CustomerController> customersQueue = null;

        private List<VegetableItemView> vegetableItemsList = null;

        private List<string> actionMapsList = null;

        private float timer = 0;

        public void Start ()
        {
            setupPlayers();
            setupStage();
            initializeOrders ();
            StartGame ();
        }

        public void StartGame ()
        {
            StartCustomerOrders ();
            StartCoroutine (startGameTimer ());
        }

        private void setupPlayers()
        {
            if (inputAsset != null)
            {
                actionMapsList = new List<string>();
                for (int i = 0; i < inputAsset.actionMaps.Count; i++)
                {
                    actionMapsList.Add(inputAsset.actionMaps[i].name);
                }
            }

            if (playersList != null && actionMapsList != null)
            {
                for (int i = 0; i < playersList.Count; i++)
                {
                    int playerId = getPlayerId ();
                    playersList[i].SetupPlayer(actionMapsList[0], levelConfigData.levelData.VegetablesCarryCapacity, playerId);
                    actionMapsList.RemoveAt(0);
                }
            }
        }

        private void setupStage ()
        {
            if (levelConfigData != null && levelConfigData.levelData.VegetableList.Count > 0)
            {
                vegetableItemsList = new List<VegetableItemView>();
                for (int i = 0 ; i < levelConfigData.levelData.VegetableList.Count ; i++)
                {
                    Transform vegParent = null;
                    if ( i < levelConfigData.levelData.VegetableList.Count/2 )
                    {
                        vegParent = leftVegCounter;
                    }
                    else
                    {
                        vegParent = rightVegCounter;
                    }

                    VegetableItemView vegInstance = Instantiate (vegetableItemPrefab, vegParent);
                    vegInstance.Initialize (levelConfigData.levelData.VegetableList [i]);
                    vegetableItemsList.Add (vegInstance);
                }

                if (choppingBoardList != null)
                {
                    for (int i = 0 ; i < choppingBoardList.Count ; i++)
                    {
                        choppingBoardList [i].Initialize (levelConfigData.levelData.WaitingTimePerVegetable,
                                                playersList [i].PlayerId);
                    }
                }
            }
        }

        private int getPlayerId ()
        {
            int id = 0;

            if ( playersList != null )
            {
                id = UnityEngine.Random.Range (1, 1000);

                PlayerController temp = playersList.Find (x => x.PlayerId == id);

                if(temp != null)
                {
                    id = getPlayerId ();
                }
            }

            return id;
        }

        private IEnumerator startGameTimer ()
        {
            timer = levelConfigData.levelData.LevelTime;
            while (timer > 0)
            {
                timer -= 1;
                // update UI
    
                yield return new WaitForSeconds (1);
            }
    
            timer = 0;
        }

        private void initializeOrders ()
        {
            if (customerPrefab != null)
            {
                customersQueue = new Queue<CustomerController>();
                for (int i = 0 ; i < levelConfigData.levelData.MaxCustomers ; i++)
                {
                    CustomerController customer = Instantiate (customerPrefab);
                    CustomerVO newCustomer = generateRandomCustomer ();
                    newCustomer.CustomerId = i;
                    customer.SetupOrder (newCustomer, 
                                        levelConfigData.levelData.WaitingTimePerVegetable, 
                                        onCustomerLeft);
                    customersQueue.Enqueue (customer);
                }
            }
        }

        private CustomerVO generateRandomCustomer ()
        {
            CustomerVO customerData = null;

            if (levelConfigData != null)
            {
                customerData = new CustomerVO();
                for (int i = 0 ; i < levelConfigData.levelData.SizePerOrder ; i++)
                {
                    int maxEnumValue = Enum.GetValues (typeof (VegetablesEnum)).Cast<int>().Max();
                    VegetablesEnum veg = (VegetablesEnum)UnityEngine.Random.Range (0, maxEnumValue);
                    customerData.CustomerOrder.VegetablesList.Add (veg);
                }

                customerData.CustomerMood = CustomerMoodsEnum.HAPPY;
            }

            return customerData;
        }

        private void StartCustomerOrders ()
        {
            if (customersQueue != null)
            {
                customersOnCounterList = new List<CustomerController>();
                for (int i = 0 ; i < levelConfigData.levelData.OrderCounterCapacity ; i++)
                {
                    moveCustomerToCounter ();
                }
            }
        }

        private void moveCustomerToCounter ()
        {
            if (customersQueue != null && customersOnCounterList != null)
            {
                CustomerController newCustomer = customersQueue.Dequeue ();
                newCustomer.StartWaiting ();
                newCustomer.transform.SetParent (orderCounterTransform);
                customersOnCounterList.Add (newCustomer);
            }
        }

        private void onCustomerLeft (CustomerController customer)
        {
            if (timer > 0.0f && customersOnCounterList != null)
            {
                customersOnCounterList.Remove (customer);
                customer.gameObject.SetActive (false);

                if ( customersQueue.Count > 0 )
                {
                    moveCustomerToCounter ();
                }
            }
        }
    }
}
