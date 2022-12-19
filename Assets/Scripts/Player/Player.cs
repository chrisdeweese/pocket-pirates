using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerStats playerStats;
    public Tile currentTile;
    public List<Tile> moveSequence;

    [Header("Repair")]
    [SerializeField] float repairAmount = 0;
    private GameObject repairSliderOBJ;
    [SerializeField] Slider repairSlider;

    private void Awake()
    {
        repairSliderOBJ = repairSlider.gameObject; 
    }

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
            repairSliderOBJ.SetActive(false);
            moveSequence.RemoveAt(0);
            Move();
        }
        else
        {
            //Repair
            repairSliderOBJ.SetActive(true);
            DOTween.To(() =>repairAmount, x => repairAmount = x, 1, playerStats.repairSpeed).OnComplete(Repair);
        }
    }

    private void FixedUpdate()
    {
        repairSlider.value = repairAmount;
    }

    void Repair()
    {
        repairAmount = 0;
        repairSlider.value = repairAmount;
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