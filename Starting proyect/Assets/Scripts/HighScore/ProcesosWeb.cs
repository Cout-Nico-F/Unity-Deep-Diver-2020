using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
///  References YoutubeVideo : https://www.youtube.com/watch?v=6VLs-Ldi5BU From DGonzalez tutorial.
/// </summary>
public class ProcesosWeb : MonoBehaviour
{
    [System.Serializable]
    public struct StructHighscoreData
    {
        [System.Serializable]
        public struct Reg
        {
            public string name;
            public int score;
            public int level;
            public string date;
        }
        public List<Reg> highscores;
    }

    private StructHighscoreData highscoreData;
    public Transform highscore_Table;
    public GameObject register;
    private int registerAmount = 10;

    [ContextMenu("Read")]
 public void Leer()
    {
        StartCoroutine(ReadCoroutine());
    }

    private IEnumerator ReadCoroutine()
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
            highscoreData =JsonUtility.FromJson<StructHighscoreData>(web.downloadHandler.text);
        }
    }

    [ContextMenu("Write")]
    public void Escribir()
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
        if(web.isNetworkError)
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

}
