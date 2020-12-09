using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        if (player == null)
        {
            Debug.Log("Assign player to GameManager!! (Player was null on gamemanager script)");
        }
        if (ingameUI.ScoreText == null)
        {
            Debug.Log("Assign scoreText to GameManager!! (ScoreText was null on gamemanager script)");
        }
        if (gameOverPanel == null)
        {
            Debug.Log("Assign GameOverPanel to GameManager!! (GameOverPanel was null on gamemanager script)");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player.gameObject != GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.LogError("Forgot to change serializable Player on GameManager object");
        }
        gameOverPanel.SetActive(false);
        SetScore();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateScore();
    }

    void SetScore()
    {
        player.Stats.LootAmmount = 0;
        ingameUI.Score = player.Stats.LootAmmount;
    }
    void UpdateScore()
    {
        Debug.Log("UpdatingScore");
        ingameUI.Score = player.Stats.LootAmmount;
        ingameUI.ScoreText.text = " Treasures: " + ingameUI.Score;
        Debug.Log("player.Stats.LootAmmount = " + player.Stats.LootAmmount.ToString());
    }


    public void GameOver ()
    {
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        //SceneManager.LoadScene("LevelOne", LoadSceneMode )
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()//from unity docs
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelOne");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
