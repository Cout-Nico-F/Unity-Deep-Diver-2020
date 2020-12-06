using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities 
{
    Player player;

    public PlayerUtilities(Player _player)
    {
        player = _player;
    }
    public void HandleImputs()
    {
        player.Stats.Direction = new Vector2 ( Input.GetAxis("Horizontal") , player.Components.Rigidbody2D.velocity.y);
        //Parametro1: Puedo manejar la sensibilidad del eje en project settings->imput ( O usar Raw para pasar de 1 a 0 en un instante  ) 
        //Parametro2: Mantiene intacta la velocidad que el rb tenia en caso de estar cayendo o saltando.

    }
}
