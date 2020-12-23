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
    GameObject VolumeSlider;
    [SerializeField]
    AudioClip bubbleSXF;

    private void Start()
    {
        if (GameObject.Find("MUSIC"))
        {
            Destroy(GameObject.Find("MUSIC"));
        }
    }
    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(bubbleSXF, transform.position, 1f);
        StartCoroutine(LoadAsyncScene("LevelOne"));
    }
    public void QuitGame()
    {
        Application.Quit();
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

    public void HowToPlay()
    {
        AudioSource.PlayClipAtPoint(bubbleSXF, transform.position, 1f);
        howToPlayScreen.SetActive(true);
        VolumeSlider.SetActive(false);
    }

    public void Credits()
    {
        AudioSource.PlayClipAtPoint(bubbleSXF, transform.position, 1f);
        creditsScreen.SetActive(true);
        VolumeSlider.SetActive(false);
    }
    public void Menu()
    {
        AudioSource.PlayClipAtPoint(bubbleSXF, transform.position, 1f);
        creditsScreen.SetActive(false);
        VolumeSlider.SetActive(true);
    }

}
