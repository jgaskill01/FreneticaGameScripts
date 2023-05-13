using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JG
{
    public class ElapsedTimeTimer : MonoBehaviour
    {
        PlayerStats playerStats;
        GameInstance GameInstance;

        float time = 0.0f;
       
        public Text disvar;

        private void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            GameInstance = FindObjectOfType<GameInstance>();
        }

        private void Update()
        {
            if (playerStats.isAlive == false)
            {
                if (time < 5000)
                {
                    time += Time.deltaTime;
                }

                double b = System.Math.Round(time, 2);
                disvar.text = b.ToString();
                
            }
        }

        private void OnDestroy()
        {
            GameInstance.SetPlayerScore(time);
        }
    }
}
