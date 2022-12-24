using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    //Asset bundle that has the players currently selected tile sprites
    public AssetBundle playerTileBundle;
    string tileBundlePath;
    public string tileKey;

    void Awake()
    {
        GetKeys();
        tileBundlePath = Application.persistentDataPath + @"\AssetBundles\" + tileKey;
        Debug.Log(tileBundlePath);
        LoadAssetBundle(tileBundlePath);
    }

    void GetKeys()
    {
        tileKey = PlayerPrefs.GetString("SelectedTile");
    }

    void LoadAssetBundle(string bundlePath)
    {
        playerTileBundle = AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(playerTileBundle == null ? "Failed to load assetbundle" : "Assetbundle loaded");
    }
}