using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class DisplayScores : MonoBehaviour
    {
        GameInstance gameInstance;

        private void Awake()
        {
            gameInstance = FindObjectOfType<GameInstance>();

            GetScores();
        }

        public void GetScores()
        {
            float scoreToDisplay = gameInstance.playerScore;
            
        }
    }
}
