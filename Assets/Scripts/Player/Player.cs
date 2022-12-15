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
    [SerializeField] float repairAmount = 1;

    public void Move()
    {
        currentTile = moveSequence[0];
        playerTransform.DOMove(moveSequence[0].transform.position, playerStats.moveSpeed).OnComplete(CheckMove);
    }

    public void ContinueMove()
    {
        playerTransform.DOMove(moveSequence[0].transform.position, playerStats.moveSpeed).OnComplete(CheckMove);
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
            DOTween.To(() =>repairAmount, x => repairAmount = x, 0, playerStats.repairSpeed).OnComplete(Repair);
        }
    }

    void Repair()
    {
        repairAmount = 1;
        currentTile.ToggleBreak(false);
        ContinueMove();
    }

    public Player(Tile startingTile)
    {
        currentTile = startingTile;
    }

    internal void CreateMoveSequence(List<Tile> _tileSequence)
    {
        moveSequence.Clear();
        moveSequence = _tileSequence;  
       // moveSequence.RemoveAt(0);//Stops delay
        Move();
    }
}