using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using UnityEngine;

// acts as the final order data type
public class SaladVO
{
    [SerializeField]
    private List<VegetablesEnum> vegetablesList = null;
    public List<VegetablesEnum> VegetablesList
    {
        get
        {
            return vegetablesList;
        }

        set
        {
            vegetablesList = value;
        }
    }
}
