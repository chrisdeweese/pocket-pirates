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

    private void Awake()
    {
        //SET A DEFAULT TILE SO WE DONT HAVE INVISIBLE TILES WE WILL HAVE TO CHANGE THE DEFAULT LATER
        PlayerPrefs.GetString("SelectedTile", "tile_wood");
    }

    private void Start()
    {
        players.Clear();
        cannons.Clear();
        cannonBalls.Clear();
    }
}
