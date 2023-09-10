using System.Collections;
using System.Collections.Generic;
using Scripts.Views;
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

        private VegetableItemView onVegetable = null;

        private Vector2 movementInput = Vector2.zero;

        private bool canDrop = false;

        private List<VegetableItemView> vegList = null;

        public void Awake ()
        {
            playerControls = new PlayerControls();
            vegList = new List<VegetableItemView>();
        }

        public void Update ()
        {
            if ( movementInput != Vector2.zero )
            {
                movePlayer ();
            }
        }

        public void SetupPlayer ( string inputActionMap )
        {
            playerInputs.SwitchCurrentActionMap ( inputActionMap );
            playerInputs.actions[playerControls.MovementA.Pick.name].performed += pickInput;
            playerInputs.actions[playerControls.MovementA.Drop.name].performed += dropInput;
            playerInputs.actions[playerControls.MovementA.Move.name].performed += moveInput;
            playerInputs.actions[playerControls.MovementA.Move.name].canceled += moveInput;
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
            bool pick = val.ReadValue<bool>();

            if ( pick )
            {
                pickVegetable ();
            }
        }

        private void dropInput (InputAction.CallbackContext val)
        {
            bool drop = val.ReadValue<bool>();

            if ( drop )
            {
                dropVegetable ();
            }
        }

        private void pickVegetable ()
        {
            if ( onVegetable != null )
            {
                vegList.Add ( onVegetable );
            }
        }

        private void dropVegetable ()
        {
            if ( vegList != null && vegList.Count > 0 )
            {
                vegList.RemoveAt ( vegList.Count - 1 );
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
            if ( col.gameObject.layer.Equals ( VEGETABLE_LAYER ) )
            {
                onVegetable = null;
            }
        }
    }
}
