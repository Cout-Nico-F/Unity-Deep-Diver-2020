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

    public StructHighscoreData highscoreData;

 [ContextMenu("Leer")]
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

    [ContextMenu("Escribir")]
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

}
