using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerReferences
{
    [SerializeField]
    private Sprite deadSprite;

    public Sprite DeadSprite { get => deadSprite;}

    [SerializeField]
    AudioClip collectSFX;
    [SerializeField]
    AudioClip puajSFX;
    [SerializeField]
    AudioClip deadSFX;
    [SerializeField]
    GameObject nopeSFX;
    [SerializeField]
    AudioClip applauseSFX;
    public AudioClip CollectSFX { get => collectSFX; }
    public AudioClip PuajSFX { get => puajSFX; }
    public AudioClip DeadSFX { get => deadSFX; }
    public GameObject NopeSFX { get => nopeSFX; }
    public AudioClip ApplauseSFX { get => applauseSFX; }
}
