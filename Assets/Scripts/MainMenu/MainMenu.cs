using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject audio;

    void Start()
    {
        if(!GameObject.Find("Audio(Clone)"))
            Instantiate(audio);
        Destroy(GameObject.Find("GameplayChecker(Clone)"));
        Destroy(GameObject.Find("GUI(Clone)"));
        Destroy(GameObject.Find("Main Camera(Clone)"));
        Destroy(GameObject.Find("Character(Clone)"));
        Resolution resolution = Screen.currentResolution;
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    public void PlayGame()
    {
        //this.gameObject.SetActive(false);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
