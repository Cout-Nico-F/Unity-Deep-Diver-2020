using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject howToPlayScreen;
    [SerializeField]
    GameObject creditsScreen;
    [SerializeField]
    GameObject Volume_Slider;
    [SerializeField]
    GameObject SFX_slider;
    [SerializeField]
    GameObject bubbleSFX;

    private void Start()
    {
        if (GameObject.Find("MUSIC"))
        {
            Destroy(GameObject.Find("MUSIC"));
        }
    }
    public void StartGame()
    {
        bubbleSFX.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadAsyncScene("LevelOne"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        bubbleSFX.GetComponent<AudioSource>().Play();
        howToPlayScreen.SetActive(true);
        Volume_Slider.SetActive(false);
        SFX_slider.SetActive(false);
    }

    public void Credits()
    {
        bubbleSFX.GetComponent<AudioSource>().Play();
        creditsScreen.SetActive(true);
        Volume_Slider.SetActive(false);
        SFX_slider.SetActive(false);

    }
    public void Menu()
    {

        bubbleSFX.GetComponent<AudioSource>().Play();
        creditsScreen.SetActive(false);
        Volume_Slider.SetActive(true);
        SFX_slider.SetActive(true);

    }

    IEnumerator LoadAsyncScene(string scene_name)//from unity docs
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene_name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
