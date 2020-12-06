using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerComponents components;
    PlayerReferences references;
    PlayerUtilities  utilities;
    PlayerActions actions;
    [SerializeField]
    PlayerStats stats;
    [SerializeField]
    IngameUI IngameUI;
  


    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }

    private void Awake()
    {
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        stats.LootAmmount = 0;
        IngameUI.Score = stats.LootAmmount;
    }

    // Update is called once per frame
    void Update()
    {
        utilities.HandleImputs();
    }

    private void FixedUpdate()
    {
        actions.Move(transform);
    }
    private void LateUpdate()
    {
        IngameUI.Score = stats.LootAmmount;
        IngameUI.ScoreText.text = " Treasures: " + IngameUI.Score;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
        if (col.CompareTag("Collectable"))
        {
            Debug.Log("Recognised as Collectable");
            Stats.LootAmmount++;
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false); //TODO:research about what is better(cheaper): destroy or setACtive? 
        }
    }
}
