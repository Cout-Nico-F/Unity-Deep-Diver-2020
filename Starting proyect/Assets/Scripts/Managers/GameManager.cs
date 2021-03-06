﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player = null;
    [SerializeField]
    IngameUI ingameUI = null;

    [SerializeField]
    GameObject gameOverPanel = null;
    [SerializeField]
    GameObject highScoresPanel = null;
    [SerializeField]
    int foodForNextLevel;
    private bool isGameOver;

    public bool IsGameOver { get => isGameOver; }

    private void Awake()
    {
        if (player == null)
        {
            Debug.LogWarning("Assign player to GameManager!! (Player was null on gamemanager script)");
        }
        if (ingameUI.ScoreText == null)
        {
            Debug.LogWarning("Assign scoreText to GameManager!! (ScoreText was null on gamemanager script)");
        }
        if (gameOverPanel == null)
        {
            Debug.LogWarning("Assign GameOverPanel to GameManager!! (GameOverPanel was null on gamemanager script)");
        }
        if (highScoresPanel == null)
        {
            Debug.LogWarning("Assign HighScore panel to GameManager!! (highScoresPanel was null on gamemanager script)");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        if (player.gameObject != GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.LogError("Forgot to change serializable Player on GameManager object");

        }
        gameOverPanel.SetActive(false);
        highScoresPanel.SetActive(false);
        SetScore();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isGameOver)
        { return; }

        UpdateScore();
    }

    void SetScore()
    {
        player.Stats.LootAmmount = 0;
        ingameUI.Score = player.Stats.LootAmmount;
    }
    void UpdateScore()
    {
        ingameUI.Score = player.Stats.LootAmmount;
        ingameUI.ScoreText.text = ingameUI.Score.ToString();
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void GameOver()
    {
        isGameOver = true;
        PlayerPrefs.SetInt("Score", 0);

        highScoresPanel.transform.parent.parent.Find("Ingame_Buttons").gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        isGameOver = false;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //StartCoroutine(LoadAsyncScene());
    }
    public void ToMainMenu()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Main_Menu");
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Score", player.Stats.LootAmmount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    public void SubmitScore()
    {
        if (player.transform.position.y >= -2) //cant submit when fallen
        {
            isGameOver = true;
            //show HighScores panel and ask for input player's name
            highScoresPanel.SetActive(true);
            highScoresPanel.transform.parent.parent.Find("Ingame_Buttons").gameObject.SetActive(false);
            //save player score, name and date to Json
            //maybe give some seconds to visualize your name in the highscore table or wait for input to continue.

            if (player.Stats.LootAmmount > foodForNextLevel)//Condition to be able to pass to next level. Maybe [ score > avg(highscore) ] or score > 40.
            {
                //Enable button to pass to next level
                highScoresPanel.transform.Find("NextLevel_Submit").gameObject.SetActive(true);
            }
            else
            {
                //show a message saying You cant proceed with such a low score. or smthing
                highScoresPanel.transform.Find("CantPassLevel").gameObject.SetActive(true);
            }
        }
        else
        {
            player.References.NopeSFX.GetComponent<AudioSource>().Play();
            //AudioSource.PlayClipAtPoint(player.Stats.NopeSFX.GetComponent<AudioSource>().clip, transform.position, 1f);
        }
    }

    public void PlaySFX(string name)
    {
        name = name.ToUpper();

        switch (name)
        {
            case "COLLECTSFX":
                player.References.CollectSFX.GetComponent<AudioSource>().Play();
                break;
            case "NOPESFX":
                player.References.NopeSFX.GetComponent<AudioSource>().Play();
                break;
            case "APPLAUSESFX":
                player.References.ApplauseSFX.GetComponent<AudioSource>().Play();
                break;
            case "DEADSFX":
                player.References.DeadSFX.GetComponent<AudioSource>().Play();
                break;
            case "PUAJSFX":
                player.References.PuajSFX.GetComponent<AudioSource>().Play();
                break;
            default:
                Debug.LogError("ERROR:Something went wrong on PlaySFX method on GameManager.cs Line:168/GameManager.cs");
                break;
        }
    }
}
