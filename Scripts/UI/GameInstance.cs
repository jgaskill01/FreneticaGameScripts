using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JG
{
    public class GameInstance : MonoBehaviour
    {
        public static GameInstance instance;
        

        public float playerScore;
        public float[] highScores = new float[10];


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }

        public void SetPlayerScore(float score)
        {
            playerScore = score;
            for (int i = 0; i < highScores.Length - 1; i++)
            {
                if (highScores[i] != 0)
                {
                    continue;
                }
                else if (highScores[i] <= 0) 
                {
                    highScores[i] = score;
                    return;
                }
                
            }
            
            
        }

        public float GetPlayerScore()
        {
            return playerScore;
        }

        public float[] DisplayAllScores()
        {
            return highScores;
        }       
        
    }
}
