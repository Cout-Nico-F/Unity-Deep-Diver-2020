using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
    Player player;

    public PlayerActions(Player _player)
    {
        player = _player;
    }
    public void Move(Transform transform)
    {
        player.Components.Rigidbody2D.velocity = new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Components.Rigidbody2D.velocity.y);
    }
    public void PickCollectable (Collider2D col)
    {
        player.Stats.LootAmmount+=1;
        Destroy(col.gameObject);
        //col.gameObject.SetActive(false); //TODO:research about what is better(cheaper): destroy or setACtive? 
    }
    private void Destroy(GameObject obj)
    {
        player.DestroyDelegate(obj);//TODO:im not sure about this method delegation. should player destroy the object instead? 
    }
}
 