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
}
 