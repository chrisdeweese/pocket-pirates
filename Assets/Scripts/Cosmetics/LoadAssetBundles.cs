using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    //Asset bundle that has the players currently selected tile sprites
    public AssetBundle playerSkinBundle0;
    public AssetBundle playerSkinBundle1;
    string playerBundlePath0;
    string playerBundlePath1;
    public string playerKey0;//player skin for team 0
    public string playerKey1;//player skin for team 1

    public AssetBundle playerTileBundle0;
    public AssetBundle playerTileBundle1;
    string tileBundlePath0;
    string tileBundlePath1;
    public string tileKey0;//tile skin for team 0
    public string tileKey1;//tile skin for team 1


    void Awake()
    {
        GetKeys();

        SetPaths();

        LoadBundles();
    }

    void GetKeys()//Gets the saved keys of selected assets
    {
        playerKey0 = PlayerPrefs.GetString("SelectedPlayerSkin0", "player_default");
        tileKey0 = PlayerPrefs.GetString("SelectedTile0", "tile_wood");

        playerKey1 = PlayerPrefs.GetString("SelectedPlayerSkin1", "player_pirate");
        tileKey1 = PlayerPrefs.GetString("SelectedTile1", "tile_stone");
    }   
    
    void SetPaths()//Sets the folder path strings 
    {
        playerBundlePath0 = Application.persistentDataPath + @"\AssetBundles\" + playerKey0;
        tileBundlePath0 = Application.persistentDataPath + @"\AssetBundles\" + tileKey0;

        playerBundlePath1 = Application.persistentDataPath + @"\AssetBundles\" + playerKey1;
        tileBundlePath1 = Application.persistentDataPath + @"\AssetBundles\" + tileKey1;
    }

    void LoadBundles()//Loads bundles after paths are found
    {
        //LoadAssetBundle(playerSkinBundle0, playerBundlePath0);
        //LoadAssetBundle(playerTileBundle0, tileBundlePath0);

        //LoadAssetBundle(playerSkinBundle1, playerBundlePath1);
        //LoadAssetBundle(playerTileBundle1, tileBundlePath1);
        playerSkinBundle0 = LoadAssetBundle(playerBundlePath0);
        playerSkinBundle1 = LoadAssetBundle(playerBundlePath1);       
        
        playerTileBundle0 = LoadAssetBundle(tileBundlePath0);
        playerTileBundle1 = LoadAssetBundle(tileBundlePath1);
    }


    AssetBundle LoadAssetBundle(string bundlePath)
    {
        //if (_bundle == playerSkinBundle0)
        //{
        //    playerSkinBundle0 = AssetBundle.LoadFromFile(bundlePath);
        //}
        //else if (_bundle == playerSkinBundle1)
        //{
        //    playerSkinBundle1 = AssetBundle.LoadFromFile(bundlePath);
        //}
        //else if (_bundle == playerTileBundle0)
        //{
        //    playerTileBundle0 = AssetBundle.LoadFromFile(bundlePath);
        //}
        //else if (_bundle == playerTileBundle1)
        //{
        //    playerTileBundle1 = AssetBundle.LoadFromFile(bundlePath);
        //}

        return AssetBundle.LoadFromFile(bundlePath);

        Debug.Log(bundlePath == null ? "Failed to load " + bundlePath + " assetbundle" : bundlePath + "  Assetbundle loaded");
    }   
}