using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject ammo;

    private GameManager _gameManager;

    private void Start()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Debug.LogError("SpawnManager cannot find a reference for GameManager!", this);
            return;
        }
        _gameManager = FindObjectOfType<GameManager>();
        
        // Spawns for the player
        SpawnPlayer(1);
        SpawnCannon(1);
        SpawnAmmo(1);

        // Spawns for the AI
        //SpawnPlayer(2);
        //SpawnCannon(2);
        //SpawnAmmo(2);
    }

    public void SpawnPlayer(int shipId)
    {
        int randomPos = Random.Range(0, 25);
        if (shipId == 1)
        {
            Player newPlayer = Instantiate(player, _gameManager.playerTiles[randomPos].transform.position, Quaternion.identity).GetComponent<Player>();
            newPlayer.currentTile = _gameManager.playerTiles[randomPos];
            _gameManager.players.Add(newPlayer);
        }
        else if (shipId == 2)
        {
            
        }
    }

    public void SpawnCannon(int shipId)
    {
        int randomPos = Random.Range(0, 25);
        if (shipId == 1)
        {
            CannonController newCannon = Instantiate(cannon, _gameManager.playerTiles[randomPos].transform.position, Quaternion.identity).GetComponent<CannonController>();
            _gameManager.cannons.Add(newCannon);
        }
        else if (shipId == 2)
        {
            
        }
    }

    public void SpawnAmmo(int shipId)
    {
        int randomPos = Random.Range(0, 25);
        if (shipId == 1)
        {
            GameObject newAmmo = Instantiate(ammo, _gameManager.playerTiles[randomPos].transform.position, Quaternion.identity);
            // if (newAmmo.GetComponent<CannonBall>() != null)
            // {
            //     _gameManager.cannonBalls.Add(newAmmo.GetComponent<CannonBall>());
            // }
        }
        else if (shipId == 2)
        {
            
        }
    }

    public void SpawnItem(int shipId)
    {
        
    }
}
