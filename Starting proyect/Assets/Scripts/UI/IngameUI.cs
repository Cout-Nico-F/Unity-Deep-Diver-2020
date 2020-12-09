using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IngameUI
{
    private int score;

    [SerializeField]
    private Text scoreText = null;
    
    public int Score { get => score; set => score = value; }
    public Text ScoreText { get => scoreText; set => scoreText = value; }

}
