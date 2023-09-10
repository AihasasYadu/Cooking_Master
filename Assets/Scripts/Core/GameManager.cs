using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerController> playersList = null;

        [SerializeField]
        private InputActionAsset inputAsset;

        private List<string> actionMapsList = null;

        public void Start ()
        {
            if (inputAsset != null)
            {
                actionMapsList = new List<string>();
                for (int i = 0 ; i < inputAsset.actionMaps.Count ; i++)
                {
                    actionMapsList.Add (inputAsset.actionMaps [i].name);
                }
            }

            if (playersList != null && actionMapsList != null)
            {
                for (int i = 0 ; i < playersList.Count ; i++)
                {
                    playersList [i].SetupPlayer ( actionMapsList [0] );
                    actionMapsList.RemoveAt (0);
                }
            }
        }
    }
}
