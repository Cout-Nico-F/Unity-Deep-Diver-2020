using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IngameUI
{
    private int score;

    [SerializeField]
    private TextMeshPro scoreText = null;

    public int Score { get => score; set => score = value; }
    public TextMeshPro ScoreText { get => scoreText; set => scoreText = value; }

}
