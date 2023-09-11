using System.Collections;
using System.Collections.Generic;
using Scripts.Enums;
using Scripts.Views;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 100.0f;

        [SerializeField]
        public PlayerControls playerControls = null;

        [SerializeField]
        private PlayerInput playerInputs = null;

        [SerializeField]
        private RectTransform rectTransform = null;

        [SerializeField]
        private TextMeshProUGUI carryVegText = null;

        [SerializeField]
        private SaladController saladItem = null;

        private SaladVO saladOrder = null;

        private VegetableItemView lastDroppedVeg = null;
        public VegetableItemView LastDroppedVeg
        {
            get
            {
                return lastDroppedVeg;
            }

            private set
            {
                lastDroppedVeg = value;
            }
        }

        private int playerId = 0;
        public int PlayerId
        {
            get
            {
                return playerId;
            }

            private set
            {
                playerId = value;
            }
        }

        private int carryCapacity = 0;

        private VegetableItemView onVegetable = null;

        private CustomerController onCustomer = null;

        private Vector2 movementInput = Vector2.zero;

        private bool canDrop = false;

        private Queue<VegetableItemView> vegQueue = null;

        private VegetablesChopController vegetablesChopStation = null;

        private bool canSubmitOrder = true;

        public void Awake ()
        {
            playerControls = new PlayerControls();
            vegQueue = new Queue<VegetableItemView>();
        }

        public void Update ()
        {
            if ( vegetablesChopStation == null
                || (vegetablesChopStation != null && !vegetablesChopStation.IsChopping) )
            {
                if ( movementInput != Vector2.zero )
                {
                    movePlayer ();
                }
            }
            else
            {
                movementInput = Vector2.zero;
            }
        }

        public void SetupPlayer ( string inputActionMap, int maxCarryCapacity, int id )
        {
            PlayerId = id;
            carryCapacity = maxCarryCapacity;
            playerInputs.SwitchCurrentActionMap ( inputActionMap );

            // using ActionMap MovementA as reference for Action names
            // as the names are similar in both the ActionMaps
            playerInputs.actions[playerControls.MovementA.Pick.name].performed += pickInput;
            playerInputs.actions[playerControls.MovementA.Drop.name].performed += dropInput;
            playerInputs.actions[playerControls.MovementA.Serve.name].performed += orderInput;
            playerInputs.actions[playerControls.MovementA.Move.name].performed += moveInput;
            playerInputs.actions[playerControls.MovementA.Move.name].canceled += moveInput;

            if (carryVegText != null)
            {
                carryVegText.text = string.Empty;
            }
        }

        private void moveInput (InputAction.CallbackContext val)
        {
            if ( vegetablesChopStation == null
                || (vegetablesChopStation != null && !vegetablesChopStation.IsChopping) )
            {
                movementInput = val.ReadValue<Vector2>();
            }
        }
    
        private void movePlayer ()
        {
            Vector3 movementDirection = new Vector3(movementInput.x, movementInput.y, 0);
            movementDirection.Normalize();
    
            rectTransform.Translate(movementDirection * speed * Time.deltaTime, Space.Self);
        }

        private void pickInput (InputAction.CallbackContext val)
        {
            if ( vegetablesChopStation == null
                || (vegetablesChopStation != null && !vegetablesChopStation.IsChopping) )
            {
                pickVegetable ();
            }
        }

        private void dropInput (InputAction.CallbackContext val)
        {
            if ( vegetablesChopStation == null
                || (vegetablesChopStation != null && !vegetablesChopStation.IsChopping) )
            {
                dropVegetable ();
            }
        }

        private void pickVegetable ()
        {
            if ( onVegetable != null && vegQueue.Count < carryCapacity )
            {
                vegQueue.Enqueue ( onVegetable );
                addVegToCarryData (onVegetable.VegetableType.ToString ());
            }
            else
            {
                Debug.Log ("Nothing Around to Pick");
            }
        }

        private void dropVegetable ()
        {
            if (canDrop)
            {
                if ( vegQueue != null && vegQueue.Count > 0 )
                {
                    LastDroppedVeg = vegQueue.Dequeue ();
                    removeFromCarryData ();
    
                    if (vegetablesChopStation != null)
                    {
                        vegetablesChopStation.ChopVegetable (LastDroppedVeg);
                    }
                    else
                    {
                        // deduct points
                    }
                }
                else
                {
                    Debug.Log ("Nothing to Drop");
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if ( col.gameObject.layer.Equals ( LayerConstants.VEGETABLE_LAYER ) )
            {
                onVegetable = col.gameObject.GetComponent<VegetableItemView>();
            }

            if ( col.gameObject.layer.Equals ( LayerConstants.DROP_VEG_LAYER ) )
            {
                canDrop = true;
                col.gameObject.TryGetComponent<VegetablesChopController>(out vegetablesChopStation);

                if (vegetablesChopStation != null
                    && vegetablesChopStation.ChopsForPlayerId != PlayerId)
                {
                    canDrop = false;
                    vegetablesChopStation = null;
                }
            }

            if ( col.gameObject.layer.Equals ( LayerConstants.CUSTOMER_LAYER ) )
            {
                canSubmitOrder = true;
                col.gameObject.TryGetComponent<CustomerController>(out onCustomer);
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if ( col.gameObject.layer.Equals ( LayerConstants.VEGETABLE_LAYER )
                && (onVegetable != null
                && col.gameObject == onVegetable.gameObject) )
            {
                onVegetable = null;
            }

            if ( col.gameObject.layer.Equals ( LayerConstants.DROP_VEG_LAYER ) )
            {
                canDrop = false;
                vegetablesChopStation = null;
            }

            if ( col.gameObject.layer.Equals ( LayerConstants.CUSTOMER_LAYER ) )
            {
                canSubmitOrder = false;
                onCustomer = null;
            }
        }

        private void addVegToCarryData (string veg)
        {
            if (carryVegText != null)
            {
                if ( string.IsNullOrEmpty (carryVegText.text) )
                {
                    carryVegText.text = veg;
                }
                else
                {
                    carryVegText.text += ", " + veg;
                }
            }
        }

        private void removeFromCarryData ()
        {
            if (carryVegText != null)
            {
                if ( !string.IsNullOrEmpty (carryVegText.text) )
                {
                    string currCarry = carryVegText.text;
                    if ( vegQueue.Count >= 1 )
                    {
                        currCarry = currCarry.Substring (3);
                    }
                    else
                    {
                        currCarry = string.Empty;
                    }

                    carryVegText.text = currCarry;
                }
            }
        }

        private void orderInput (InputAction.CallbackContext val)
        {
            if (saladOrder != null)
            {
                if ( canSubmitOrder )
                {
                    serveOrder ();
                }
            }
            else
            {
                pickupOrder ();
            }
        }

        private void pickupOrder ()
        {
            if (saladItem != null && vegQueue.Count == 0)
            {
                saladOrder = saladItem.PickSaladPlate ();
                
                carryVegText.text = string.Empty;
                for (int i = 0 ; i < saladOrder.VegetablesList.Count ; i++)
                {
                    carryVegText.text += saladOrder.VegetablesList [i].ToString ();
                }
            }
        }

        private void serveOrder ()
        {
            if (saladOrder != null && onCustomer != null)
            {
                onCustomer.SubmitOrder (saladOrder, playerId);
                saladOrder = null;
                vegQueue.Clear ();
                canSubmitOrder = false;
                carryVegText.text = string.Empty;
            }
        }
    }
}
