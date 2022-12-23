using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    //Asset bundle that has the players currently selected tile sprites
    public AssetBundle playerTileBundle;
    string assetBundlePath;

    void Awake()
    {
        assetBundlePath = Application.persistentDataPath + @"\AssetBundles\tile_testwood";
        Debug.Log(assetBundlePath);
        LoadAssetBundle(assetBundlePath);
    }

    void LoadAssetBundle(string bundlePath)
    {
        playerTileBundle = AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(playerTileBundle == null ? "Failed to load assetbundle" : "Assetbundle loaded");
    }
}