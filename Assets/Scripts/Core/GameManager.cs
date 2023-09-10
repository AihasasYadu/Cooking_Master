using System.Collections;
using System.Collections.Generic;
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
        private List<VegetablesChopController> choppingBoardList = null;

        private List<VegetableItemView> vegetableItemsList = null;

        private List<string> actionMapsList = null;

        public void Start ()
        {
            setupPlayers();
            setupStage();
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
                id = Random.Range (1, 1000);

                PlayerController temp = playersList.Find (x => x.PlayerId == id);

                if(temp != null)
                {
                    id = getPlayerId ();
                }
            }

            return id;
        }
    }
}
