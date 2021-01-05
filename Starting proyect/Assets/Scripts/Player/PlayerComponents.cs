using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidbody2D = null;

    public Rigidbody2D Rigidbody2D { get => rigidbody2D; }
}
