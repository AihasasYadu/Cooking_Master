using System.Collections.Generic;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.VO
{
    [System.Serializable]
    public class LevelVO
    {
        [SerializeField]
        private int _levelId = 0;
        public int LevelId
        {
            get
            {
                return _levelId;
            }

            set
            {
                _levelId = value;
            }
        }

        [SerializeField]
        private int _maxCustomers = 0;
        public int MaxCustomers
        {
            get
            {
                return _maxCustomers;
            }

            set
            {
                _maxCustomers = value;
            }
        }

        [SerializeField]
        private List<VegetablesEnum> _vegetableList = null;
        public List<VegetablesEnum> VegetableList
        {
            get
            {
                return _vegetableList;
            }

            set
            {
                _vegetableList = value;
            }
        }

        [SerializeField]
        private float _levelTime = 0.0f;
        public float LevelTime
        {
            get
            {
                return _levelTime;
            }

            set
            {
                _levelTime = value;
            }
        }

        [SerializeField]
        private float _waitingTimePerVegetable = 0.0f;
        public float WaitingTimePerVegetable
        {
            get
            {
                return _waitingTimePerVegetable;
            }

            set
            {
                _waitingTimePerVegetable = value;
            }
        }

        [SerializeField]
        private int _rewardPoints = 0;
        public int RewardPoints
        {
            get
            {
                return _rewardPoints;
            }

            set
            {
                _rewardPoints = value;
            }
        }

        [SerializeField]
        private int _deductPoints = 0;
        public int DeductPoints
        {
            get
            {
                return _deductPoints;
            }

            set
            {
                _deductPoints = value;
            }
        }

        [SerializeField]
        private float _choppingTime = 0.0f;
        public float ChoppingTime
        {
            get
            {
                return _choppingTime;
            }

            set
            {
                _choppingTime = value;
            }
        }

        [SerializeField]
        private int _vegetablesCarryCapacity = 0;
        public int VegetablesCarryCapacity
        {
            get
            {
                return _vegetablesCarryCapacity;
            }

            set
            {
                _vegetablesCarryCapacity = value;
            }
        }

        [SerializeField]
        private int _sizePerOrder = 0;
        public int SizePerOrder
        {
            get
            {
                return _sizePerOrder;
            }

            set
            {
                _sizePerOrder = value;
            }
        }

        [SerializeField]
        private int _orderCounterCapacity = 0;
        public int OrderCounterCapacity
        {
            get
            {
                return _orderCounterCapacity;
            }

            set
            {
                _orderCounterCapacity = value;
            }
        }
    }
}
