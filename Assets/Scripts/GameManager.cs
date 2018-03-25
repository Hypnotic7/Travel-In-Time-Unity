using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
        public Image LoadingSpiral;


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

            if (GameObject.Find("GUI(Clone)").transform.GetChild(3).gameObject.activeSelf)
                GameObject.Find("GUI(Clone)").transform.GetChild(3).gameObject.SetActive(false);


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
            GameObject.Find("GUI(Clone)").transform.GetChild(3).gameObject.SetActive(true);
            StartCoroutine(Rotate(3));

            SceneManager.LoadSceneAsync(sceneName);
            DontDestroyOnLoad(GameObject.Find("GameplayChecker(Clone)"));
            DontDestroyOnLoad(GameObject.Find("GUI(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Main Camera(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Character(Clone)"));
            DontDestroyOnLoad(GameObject.Find("EventSystem(Clone)"));
            DontDestroyOnLoad(GameObject.Find("Audio(Clone)"));
            
        }

        IEnumerator Rotate(float duration)
        {
            float startRotation = transform.eulerAngles.z;
            float endRotation = startRotation + 360.0f;
            float t = 0.0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
                GameObject.Find("Spiral").transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
                yield return null;
            }
        }
    }
}
