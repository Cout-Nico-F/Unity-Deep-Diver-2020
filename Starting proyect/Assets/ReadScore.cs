using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScore : MonoBehaviour
{
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.Stats.LootAmmount = PlayerPrefs.GetInt("Score");
    }
}
