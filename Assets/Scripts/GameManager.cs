using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Tile> playerTiles;
    public List<Tile> enemyTiles;
    public List<Player> players;
    public List<CannonController> cannons;
    public List<CannonBall> cannonBalls;


    private void Start()
    {
        players.Clear();
        cannons.Clear();
        cannonBalls.Clear();
    }
}
