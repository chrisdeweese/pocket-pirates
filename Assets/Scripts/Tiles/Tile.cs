using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coordinates;
    public Inventory inventory;
    public bool isBroken = false;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fixedSprite;
    [SerializeField] Sprite brokenSprite;
    public Color tileColor;

    public void ToggleBreak(bool _isBroken)
    {   
        isBroken = _isBroken;

        if (isBroken)
            spriteRenderer.sprite = brokenSprite;
        else
            spriteRenderer.sprite = fixedSprite;
    }
}