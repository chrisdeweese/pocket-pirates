using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    LoadAssetBundles assetBundleLoader;

    public Vector2Int coordinates;
    public Inventory inventory;
    public bool isBroken = false;
    public int team = 0;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite fixedSprite;
    [SerializeField] Sprite brokenSprite;
    public Color tileColor;

    private void Start()
    {
        assetBundleLoader = FindObjectOfType<LoadAssetBundles>();
        if (team == 0)
        {
            Debug.Log(assetBundleLoader.playerTileBundle0.LoadAsset<Sprite>(assetBundleLoader.tileKey0 + "_repaired"));
            fixedSprite = assetBundleLoader.playerTileBundle0.LoadAsset<Sprite>(assetBundleLoader.tileKey0 + "_repaired");
            brokenSprite = assetBundleLoader.playerTileBundle0.LoadAsset<Sprite>(assetBundleLoader.tileKey0 + "_broken");
        }
        else
        {
            Debug.Log(assetBundleLoader.playerTileBundle0.LoadAsset<Sprite>(assetBundleLoader.tileKey0 + "_repaired"));
            fixedSprite = assetBundleLoader.playerTileBundle1.LoadAsset<Sprite>(assetBundleLoader.tileKey1 + "_repaired");
            brokenSprite = assetBundleLoader.playerTileBundle1.LoadAsset<Sprite>(assetBundleLoader.tileKey1 + "_broken");
        }

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