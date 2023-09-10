using System.Collections;
using System.Collections.Generic;
using Scripts.Views;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        private const int VEGETABLE_LAYER = 7;

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

        private Vector2 movementInput = Vector2.zero;

        private bool canDrop = false;

        private Queue<VegetableItemView> vegQueue = null;

        public void Awake ()
        {
            playerControls = new PlayerControls();
            vegQueue = new Queue<VegetableItemView>();
        }

        public void Update ()
        {
            if ( movementInput != Vector2.zero )
            {
                movePlayer ();
            }
        }

        public void SetupPlayer ( string inputActionMap, int maxCarryCapacity )
        {
            carryCapacity = maxCarryCapacity;
            playerInputs.SwitchCurrentActionMap ( inputActionMap );
            playerInputs.actions[playerControls.MovementA.Pick.name].performed += pickInput;
            playerInputs.actions[playerControls.MovementA.Drop.name].performed += dropInput;
            playerInputs.actions[playerControls.MovementA.Move.name].performed += moveInput;
            playerInputs.actions[playerControls.MovementA.Move.name].canceled += moveInput;

            if (carryVegText != null)
            {
                carryVegText.text = string.Empty;
            }
        }

        private void moveInput (InputAction.CallbackContext val)
        {
            movementInput = val.ReadValue<Vector2>();
        }
    
        private void movePlayer ()
        {
            Vector3 movementDirection = new Vector3(movementInput.x, movementInput.y, 0);
            movementDirection.Normalize();
    
            rectTransform.Translate(movementDirection * speed * Time.deltaTime, Space.Self);
        }

        private void pickInput (InputAction.CallbackContext val)
        {
            pickVegetable ();
        }

        private void dropInput (InputAction.CallbackContext val)
        {
            dropVegetable ();
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
            if ( vegQueue != null && vegQueue.Count > 0 )
            {
                LastDroppedVeg = vegQueue.Dequeue ();
                removeFromCarryData ();
            }
            else
            {
                Debug.Log ("Nothing to Drop");
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if ( col.gameObject.layer.Equals ( VEGETABLE_LAYER ) )
            {
                onVegetable = col.gameObject.GetComponent<VegetableItemView>();
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if ( col.gameObject.layer.Equals ( VEGETABLE_LAYER )
                && (onVegetable != null
                && col.gameObject == onVegetable.gameObject) )
            {
                onVegetable = null;
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
    }
}
