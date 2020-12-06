using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    IngameUI ingameUI;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        player.Stats.LootAmmount = 0;
        ingameUI.Score = player.Stats.LootAmmount;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ingameUI.Score = player.Stats.LootAmmount;
        ingameUI.ScoreText.text = " Treasures: " + ingameUI.Score;
    }
}
