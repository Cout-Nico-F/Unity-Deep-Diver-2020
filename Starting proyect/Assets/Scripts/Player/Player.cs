using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Space]
    [SerializeField]
    GameManager gameManager = null;
    [Space]
    [SerializeField]
    PlayerComponents components = null;
    PlayerReferences references;
    PlayerUtilities  utilities;
    PlayerActions actions;
    [SerializeField]
    PlayerStats stats = null;
    
   



    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }

    private void Awake()
    {
        if (gameManager == null)
        {
            Debug.Log("Assign GameManager object to Player!! (gameManager was null on Player script)");
        }
        
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Collectable"))
        {
            actions.PickCollectable(col);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            Destroy(gameObject);//destroys the player.
            gameManager.GameOver();
        }
    }

}
