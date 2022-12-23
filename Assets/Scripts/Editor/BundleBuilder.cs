using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/Build AssetBudles")]
    static void BuildAllAssetBundles()
    {
        string bundleFolderPath = Path.Combine(Application.persistentDataPath, "AssetBundles");
        if (!Directory.Exists(bundleFolderPath))
        {
            Directory.CreateDirectory(bundleFolderPath);
        }

        BuildPipeline.BuildAssetBundles(bundleFolderPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}