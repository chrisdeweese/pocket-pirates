using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    //Asset bundle that has the players currently selected tile sprites
    public AssetBundle playerTileBundle;
    public string path;

    void Awake()
    {
        LoadAssetBundle(path);
    }

    void LoadAssetBundle(string bundlePath)
    {
        playerTileBundle = AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(playerTileBundle == null ? "Failed to load assetbundle" : "Assetbundle loaded");
    }
}