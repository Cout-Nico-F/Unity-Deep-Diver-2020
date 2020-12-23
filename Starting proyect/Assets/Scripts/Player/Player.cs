using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Steps when changing players: </para>
    /// Serialize player in GameManager object. </para>
    /// Serialize player in cameraFollow (Camera object) </para>
    /// 
    /// </summary>

    [Space]
    [SerializeField]
    GameManager gameManager = null;
    
    [Space]
    [SerializeField]
    PlayerComponents components = null;
    [SerializeField]
    PlayerReferences references = null;

    PlayerUtilities utilities;
    PlayerActions actions;
    [SerializeField]
    PlayerStats stats = null;


    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }
    public PlayerReferences References { get => references; }

    private void Awake()
    {
        if (gameManager == null)
        {
            Debug.LogError("Assign GameManager object to Player!! (gameManager was null on Player script)");
        }
        if (references.CollectSFX == null)
        {
            Debug.LogError("Assign Collect-SFX to the Player!");
        }
        if (references.PuajSFX == null)
        {
            Debug.LogError("Assign Puaj-SFX to the Player!");
        }

        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        stats.PuajAnimationElapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver)//If its game over update wont do anything.
        {
            return;
        }
        utilities.HandleImputs();
    }

    private void FixedUpdate()
    {
        if (gameManager.IsGameOver)//If its game over update wont do anything.
        {
            return;
        }
        actions.Move(transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!gameManager.IsGameOver)
        {
            if (col.CompareTag("Collectable"))
            {
                AudioSource.PlayClipAtPoint(references.CollectSFX, transform.position, 0.45f);
                actions.PickCollectable(col);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        stats.PuajAnimationElapsedTime = Time.time - stats.PuajAnimationLastTime;
        if (!gameManager.IsGameOver)
        {
            if (col.gameObject.CompareTag("Danger"))
            {
                //Vector3 cameraPos = new Vector3(transform.position.x, transform.position.y, Camera.main.transform);
                //AudioSource.PlayClipAtPoint(stats.DeadSFX, Camera.main.transform.position, 1f);
                AudioSource.PlayClipAtPoint(references.DeadSFX, transform.position,1f);
                GetComponent<Animator>().SetBool("Dead", true);
                Components.Rigidbody2D.AddForce(new Vector2(6.2f, 5.0f), ForceMode2D.Impulse);
                gameManager.GameOver();
            }
            if (col.gameObject.CompareTag("Puaj") && stats.PuajAnimationElapsedTime > stats.PuajAnimationCooldownTime)
            {
                AudioSource.PlayClipAtPoint(references.PuajSFX, transform.position,0.45f);
                GetComponent<Animator>().SetTrigger("Cucumber_Touch");
                stats.PuajAnimationLastTime = Time.time;
            }
        }
    }

    public void DestroyDelegate(GameObject obj)
    {
        gameManager.DestroyObject(obj);
    }

}
