using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
///  References YoutubeVideo : https://www.youtube.com/watch?v=6VLs-Ldi5BU From DGonzalez tutorial.
/// </summary>
public class ProcesosWeb : MonoBehaviour
{
    public Player player;
    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        player = Player.FindObjectOfType<Player>();
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }

    public void ReadFromWeb()
    {
        Read(EnsamlbeHighScore);
    }
    public void EnsamlbeHighScore()
    {
        CheckForHighscore();
        CreateTable();
        FillTable();
    }


    [System.Serializable]
    public struct StructHighscoreData
    {
        [System.Serializable]
        public struct Reg
        {
            public string name;
            public int score;
            //public int level;
            //public string date;
        }
        public List<Reg> highscores;
    }


    public StructHighscoreData highscoreData;
    public Transform highscore_Table;
    public Transform new_Highscore;
    public TMPro.TMP_InputField inpuName;

    public GameObject register;
    private int registerAmount = 10;

    [ContextMenu("Read")]
    public void Read(System.Action whenFinished)
    {
        StartCoroutine(ReadCoroutine(whenFinished));
    }

    private IEnumerator ReadCoroutine(System.Action whenFinished)
    {
        UnityWebRequest web = UnityWebRequest.Get("https://pipasjourney.com/compartido/DeepDiver2020HighScores.txt");
        yield return web.SendWebRequest();
        if (web.isNetworkError)
        {
            Debug.LogError("Web Get request: Is Network Error!");
        }
        else if (web.isHttpError)
        {
            Debug.LogError("Web Get request: Is HTTP Error!");
        }
        else
        {
            Debug.Log("Web Post request: All good");
            highscoreData = JsonUtility.FromJson<StructHighscoreData>(web.downloadHandler.text);
            whenFinished();
        }
    }

    [ContextMenu("Write")]
    public void Write()
    {
        StartCoroutine(WriteCoroutine());
    }

    private IEnumerator WriteCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "DeepDiver2020HighScores.txt");
        form.AddField("texto", JsonUtility.ToJson(highscoreData));

        UnityWebRequest web = UnityWebRequest.Post("https://pipasjourney.com/compartido/escribir.php", form);
        yield return web.SendWebRequest();
        if (web.isNetworkError)
        {
            Debug.LogError("Web Post request: Is Network Error!");
        }
        else if (web.isHttpError)
        {
            Debug.LogError("Web Post request: Is HTTP Error!");
        }
        else
            Debug.Log("Web Post request: All good");
    }

    [ContextMenu("Create Table")]
    void CreateTable()
    {
        for (int i = 0; i < registerAmount; i++)
        {
            GameObject instance = Instantiate(register, highscore_Table);
            instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * -50);
        }
    }

    [ContextMenu("Fill Table")]
    void FillTable()
    {
        for (int i = 0; i < registerAmount; i++)
        {
            highscore_Table.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = highscoreData.highscores[i].name;
            highscore_Table.GetChild(i).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = highscoreData.highscores[i].score.ToString();
        }
    }

    [ContextMenu("Check for Highscore")]
    void CheckForHighscore()
    {
        if (player.Stats.LootAmmount > highscoreData.highscores[registerAmount - 1].score)
        {
            gameManager.PlaySFX("ApplauseSFX");
            highscore_Table.gameObject.SetActive(false);
            new_Highscore.gameObject.SetActive(true);
        }
        else
        {
            highscore_Table.gameObject.SetActive(true);
            new_Highscore.gameObject.SetActive(false);
        }
    }

    [ContextMenu("Insert new reg")]
    void InsertReg()
    {
        for (int i = 0; i < registerAmount; i++)
        {
            if (player.Stats.LootAmmount > highscoreData.highscores[i].score)
            {
                highscoreData.highscores.Insert(i, new StructHighscoreData.Reg()
                {
                    name = inpuName.text,
                    score = player.Stats.LootAmmount
                });
                break;
            }
        }
    }

    public void ImputFinished()
    {
        new_Highscore.gameObject.SetActive(false);
        highscore_Table.gameObject.SetActive(true);
        Read(InsertAndWrite);
    }

    public void InsertAndWrite()
    {
        InsertReg();
        Write();
        FillTable();
    }




}
