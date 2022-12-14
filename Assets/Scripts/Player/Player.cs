using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    private LoadAssetBundles assetBundleLoader;
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Tile currentTile;
    public List<Tile> moveSequence;

    public int team = 0;

    [Header("Repair")]
    [SerializeField] float repairAmount = 0;
    private GameObject repairSliderOBJ;
    [SerializeField] Slider repairSlider;

    private void Awake()
    {
        assetBundleLoader = FindObjectOfType<LoadAssetBundles>();
        repairSliderOBJ = repairSlider.gameObject; 
    }

    private void Start()
    {
        if (team == 0)
        {
            spriteRenderer.sprite = assetBundleLoader.playerSkinBundle0.LoadAsset<Sprite>(assetBundleLoader.playerKey0);
        }
        else
        {
            spriteRenderer.sprite = assetBundleLoader.playerSkinBundle1.LoadAsset<Sprite>(assetBundleLoader.playerKey1);
        }
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
        repairSlider.value = repairAmount;
        currentTile.ToggleBreak(false);
        repairSliderOBJ.SetActive(false);
        repairAmount = 0;
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