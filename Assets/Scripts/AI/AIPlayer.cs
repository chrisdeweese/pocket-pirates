using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIPlayer : MonoBehaviour
{
    private Vector2 _location;
    private float _timer;
    private bool _isProcessing;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 5.0f)
        {
            _timer = 0f;
            CalculateNextMove();
        }
    }

    private void CalculateNextMove()
    {
        int randomMoveChoice = Random.Range(0, 3);
        
        switch (randomMoveChoice)
        {
            case 0:
                MoveToNearestAmmo();
                break;
            case 1:
                MoveToNearestCannon();
                break;
            case 2:
                MoveToNearestDamage();
                break;
            case 3:
                MoveToIdle();
                break;
        }
    }

    private void MoveToNearestAmmo()
    {
        Item[] items = FindObjectsOfType<Item>();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemBase.itemType == ItemBase.ItemTypes.Ammo)
            {
                
            }
        }
    }

    private void MoveToNearestCannon()
    {
        
    }

    private void MoveToNearestDamage()
    {
        
    }

    private void MoveToIdle()
    {
        // do nothing and wait next turn
    }
}
