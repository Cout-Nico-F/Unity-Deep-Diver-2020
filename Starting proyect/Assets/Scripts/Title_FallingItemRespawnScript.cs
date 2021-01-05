using UnityEngine;

public class Title_FallingItemRespawnScript : MonoBehaviour
{
    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRespawn();
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    //maybe can add some randomize to the position
    private void CheckRespawn()
    {
        if (transform.position.y <= -8.5)
        {
            transform.position = initialPos;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0.1f, -0.1f);
        }
    }
}
