using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    LoadAssetBundles assetBundleLoader;

    public Vector2Int coordinates;
    public Inventory inventory;
    public bool isBroken = false;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fixedSprite;
    [SerializeField] Sprite brokenSprite;
    public Color tileColor;

    private void Start()
    {
        assetBundleLoader = FindObjectOfType<LoadAssetBundles>();
        fixedSprite = assetBundleLoader.playerTileBundle.LoadAsset<Sprite>("temp_wood");
        brokenSprite = assetBundleLoader.playerTileBundle.LoadAsset<Sprite>("temp_wood_broken");
        if (!isBroken)
        {
            spriteRenderer.sprite = fixedSprite;
        }
        else
        {
            spriteRenderer.sprite = brokenSprite;
        }
    }

    public void ToggleBreak(bool _isBroken)
    {   
        isBroken = _isBroken;

        if (isBroken)
            spriteRenderer.sprite = brokenSprite;
        else
            spriteRenderer.sprite = fixedSprite;
    }
}