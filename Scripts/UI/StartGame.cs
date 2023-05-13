using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JG
{
    public class StartGame : MonoBehaviour
    {
        
        

      

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ReturnToMenu()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);                                        
        }
    }
}
