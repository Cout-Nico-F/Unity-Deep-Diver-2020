using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences 
{
    private readonly Sprite deadSprite = Resources.Load<Sprite>("deadSquid");

    public Sprite DeadSprite { get => deadSprite;}

    
}
