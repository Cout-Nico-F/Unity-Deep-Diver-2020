using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    public Rigidbody2D Rigidbody2D { get => rigidbody2D; }
}
