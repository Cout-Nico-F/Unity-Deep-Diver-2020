using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        GetComponent<Rigidbody2D>().AddTorque(2f);
    }
}
