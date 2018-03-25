using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        public GameObject inventoryUI;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            inventoryUI.SetActive(true);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            inventoryUI.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadSettingsMenu()
        {
            
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1f;
            if(PlayerPrefs.GetString("CurrentTime") == "Past_Time_Test" || GameObject.Find("GameManager").GetComponent<GameManager>().currentTime == "Past_Time_Test")
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
            else
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
            
            DontDestroyOnLoad(GameObject.Find("Audio(Clone)"));
        }

       
    }
}
