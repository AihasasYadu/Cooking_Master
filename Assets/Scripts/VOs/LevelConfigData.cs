using System.Collections;
using System.Collections.Generic;
using Scripts.VO;
using UnityEngine;

namespace Scripts.VO
{
    [CreateAssetMenu (fileName = "LevelConfig", menuName = "Scriptables/LevelData")]
    public class LevelConfigData : ScriptableObject
    {
        /// <summary>
        /// level data for the current setup
        /// could use list to manage several levels based on difficulties
        /// </summary>
        public LevelVO levelData = null;
    }
}
