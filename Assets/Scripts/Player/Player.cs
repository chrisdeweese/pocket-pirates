using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerStats playerStats;
    public Tile currentTile;
    public List<Tile> moveSequence;

    public void Move()
    {
        currentTile = moveSequence[0];
        playerTransform.DOMove(moveSequence[0].transform.position, playerStats.speed).OnComplete(CheckMove);
    }

    void CheckMove()
    {
        if (currentTile.isBroken == false)
        {
            moveSequence.RemoveAt(0);
            Move();
        }
        else
        {
            //Repair
        }
    }

    public Player(Tile startingTile, Transform tileTransform)
    {
        currentTile = startingTile;
    }

    internal void CreateMoveSequence(List<Tile> _tileSequence)
    {
        moveSequence.Clear();
        moveSequence = _tileSequence;  
        moveSequence.RemoveAt(0);//Stops delay
        Move();
    }
}