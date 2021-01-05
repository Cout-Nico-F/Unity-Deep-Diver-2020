using TMPro;
using UnityEngine;

[System.Serializable]
public class IngameUI
{
    private int score;

    [SerializeField]
    private TextMeshPro scoreText = null;

    public int Score { get => score; set => score = value; }
    public TextMeshPro ScoreText { get => scoreText; set => scoreText = value; }

}
