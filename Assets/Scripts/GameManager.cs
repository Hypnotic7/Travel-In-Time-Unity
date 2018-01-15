using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public string currentTime { get; set; }
        // Use this for initialization
        void Start()
        {
            currentTime = "Past_Time_Test";
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
        }
    }
}
