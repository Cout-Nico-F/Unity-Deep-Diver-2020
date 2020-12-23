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
    GameObject collectSFX;
    [SerializeField]
    GameObject puajSFX;
    [SerializeField]
    GameObject deadSFX;
    [SerializeField]
    GameObject nopeSFX;
    [SerializeField]
    GameObject applauseSFX;
    public GameObject CollectSFX { get => collectSFX; }
    public GameObject PuajSFX { get => puajSFX; }
    public GameObject DeadSFX { get => deadSFX; }
    public GameObject NopeSFX { get => nopeSFX; }
    public GameObject ApplauseSFX { get => applauseSFX; }
}
