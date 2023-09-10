using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.VO
{
    public class CustomerVO
    {
        [SerializeField]
        private int _customerId = 0;
        public int CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
            }
        }

        [SerializeField]
        private CustomerMoodsEnum _customerMood = CustomerMoodsEnum.NONE;
        public CustomerMoodsEnum CustomerMood
        {
            get
            {
                return _customerMood;
            }

            set
            {
                _customerMood = value;
            }
        }

        [SerializeField]
        private string _customerOrder = string.Empty;
        public string CustomerOrder
        {
            get
            {
                return _customerOrder;
            }

            set
            {
                _customerOrder = value;
            }
        }
    }
}
