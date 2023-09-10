using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerController> playersList = null;

        [SerializeField]
        private List<string> actionMapsList = null;

        public void Start ()
        {
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
