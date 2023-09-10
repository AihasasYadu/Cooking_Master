using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Core;
using Scripts.Enums;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupItemView : MonoBehaviour
{
    [SerializeField]
    private PickupsEnum _pickupType = PickupsEnum.NONE;
    public PickupsEnum PickupType
    {
        get
        {
            return _pickupType;
        }

        private set
        {
            _pickupType = value;
        }
    }

    [SerializeField]
    private TextMeshProUGUI pickupText = null;

    [SerializeField]
    private Image pickupContainerImage = null;

    private Action<PickupsEnum> onPickupCallback = null;

    private int checkId = 0;

    public void Initialize ( int playerId, PickupsEnum pickup, Color color, Action<PickupsEnum> onPickup )
    {
        checkId = playerId;
        PickupType = pickup;
        onPickupCallback = onPickup;

        if ( pickupText != null )
        {
            pickupText.text = PickupType.ToString ();
        }

        if ( pickupContainerImage != null )
        {
            pickupContainerImage.color = color;
        }
    }

    public void OnTriggerEnter2D( Collider2D col)
    {
        if (col.gameObject.layer.Equals ( LayerConstants.PLAYER_LAYER ))
        {
            int playerId = col.gameObject.GetComponent<PlayerController>().PlayerId;
            if ( checkId == playerId )
            {
                onPickupCallback?.Invoke (PickupType);
            }
        }
    }
}
