using UnityEngine;

public class FallingItemRespawnScript : MonoBehaviour
{
    Vector3 initialPos;
    // Start is called before the first frame update
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
        if (transform.position.y <= -3.4)
        {
            transform.position = initialPos + Vector3.up * 3;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0.1f, -0.1f);
        }
    }
}
