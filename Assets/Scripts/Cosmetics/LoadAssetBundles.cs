using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    //Asset bundle that has the players currently selected tile sprites
    public AssetBundle playerSkinBundle;
    string playerBundlePath;
    public string playerKey;

    public AssetBundle playerTileBundle;
    string tileBundlePath;
    public string tileKey;


    void Awake()
    {
        GetKeys();
        playerBundlePath = Application.persistentDataPath + @"\AssetBundles\" + playerKey;
        tileBundlePath = Application.persistentDataPath + @"\AssetBundles\" + tileKey;
        Debug.Log(tileBundlePath);
        LoadPlayerAssetBundle(playerBundlePath);
        LoadTileAssetBundle(tileBundlePath);
    }

    void GetKeys()
    {
        playerKey = PlayerPrefs.GetString("SelectedPlayerSkin");
        tileKey = PlayerPrefs.GetString("SelectedTile");
    }

    void LoadPlayerAssetBundle(string bundlePath)
    {
        playerSkinBundle = AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(playerTileBundle == null ? "Failed to load player skin assetbundle" : " Player Skin Assetbundle loaded");
    }   
    
    void LoadTileAssetBundle(string bundlePath)
    {
        playerTileBundle = AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(playerTileBundle == null ? "Failed to load tile assetbundle" : "Tile Assetbundle loaded");
    }
}