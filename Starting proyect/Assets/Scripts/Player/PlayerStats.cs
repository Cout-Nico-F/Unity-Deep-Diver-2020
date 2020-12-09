using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats 
{
    private Vector2 direction;

    [SerializeField]
    private float walkSpeed = 0;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private int lootAmmount = 0;
    public float Speed { get; set; }

    public Vector2 Direction { get => direction; set => direction = value; }
    public float WalkSpeed { get => walkSpeed; }
    public int LootAmmount { get => lootAmmount; set => lootAmmount = value; }

    
}
