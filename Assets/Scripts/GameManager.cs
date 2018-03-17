using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Wilberforce;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public string currentTime;
        public GameObject GUI;
        public GameObject Character;
        public GameObject MainCamera;
        public GameObject EventSystem;
        public GameObject AudioSystem;
        public GameObject GameplayCheckerObj;


        // Use this for initialization
        void Start()
        {
            //currentTime = "Past_Time_Test";
            if (GameObject.Find("GameplayChecker(Clone)") == null)
            {
                Instantiate(GameplayCheckerObj);
            }
            
            if (GameObject.Find("GUI(Clone)") == null)
            {
                Instantiate(GUI);
            }
            

            if (GameObject.Find("Main Camera(Clone)") == null)
            {
                Instantiate(MainCamera);
            }

            if (GameObject.Find("Character(Clone)") == null)
            {
                Instantiate(Character);
                GameObject.Find("Main Camera(Clone)").GetComponent<SmoothFollow>().target = GameObject.Find("Character(Clone)").transform;
            }
            else
            {
                GameObject.Find("Main Camera(Clone)").GetComponent<SmoothFollow>().target = GameObject.Find("Character(Clone)").transform;
            }

            if (GameObject.Find("EventSystem(Clone)") == null)
            {
                Instantiate(EventSystem);
            }

            if (GameObject.Find("Audio(Clone)") == null)
            {
                Instantiate(AudioSystem);
            }


            if (GameplayChecker.InvisibilityMode)
            {
                var colorBlind = GameObject.Find("Main Camera(Clone)").GetComponent<Colorblind>();

                if (PlayerPrefs.GetString("CurrentTime") == "Past_Time_Test" && colorBlind.enabled)
                {
                    var vinyls = GameObject.Find("Vinyls").transform;
                    for (int i = 0; i < vinyls.childCount; i++)
                    {
                        vinyls.GetChild(i).gameObject.SetActive(colorBlind.enabled);
                    }

                }
                else if (PlayerPrefs.GetString("CurrentTime") == "Past_Time_Test" && !colorBlind.enabled)
                {
                    var vinyls = GameObject.Find("Vinyls").transform;
                    for (int i = 0; i < vinyls.childCount; i++)
                    {
                        vinyls.GetChild(i).gameObject.SetActive(colorBlind.enabled);
                    }

                }
            }


        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            Debug.Log("Game Status was destroyed");
            PlayerPrefs.SetString("CurrentTime", currentTime);

        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            DontDestroyOnLoad(GameObject.Find("GameplayChecker(Clone)"));
            DontDestroyOnLoad(GameObject.Find("GUI(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Main Camera(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Character(Clone)"));
            DontDestroyOnLoad(GameObject.Find("EventSystem(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Audio(Clone)"));
            
        }
    }
}
