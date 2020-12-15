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

    //animation variables
    [SerializeField]
    AudioClip collectSFX;
    [SerializeField]
    AudioClip puajSFX;
    [SerializeField]
    AudioClip deadSFX;
    private float puajAnimationElapsedTime;
    private float puajAnimationLastTime;
    [SerializeField]
    private float puajAnimationCooldownTime = 2f;

    public float PuajAnimationElapsedTime { get => puajAnimationElapsedTime; set => puajAnimationElapsedTime = value; }
    public float PuajAnimationLastTime { get => puajAnimationLastTime; set => puajAnimationLastTime = value; }
    public float PuajAnimationCooldownTime { get => puajAnimationCooldownTime; }
    public AudioClip CollectSFX { get => collectSFX; }
    public AudioClip PuajSFX { get => puajSFX; }
    public AudioClip DeadSFX { get => deadSFX; }

}
