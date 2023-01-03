using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame_OnClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenScene(int _buildIndex)
    {
        SceneManager.LoadScene(_buildIndex);
    }

#if UNITY_EDITOR
    //Saves player pref for what tileset is saved  THIS IS TEMPORARY
    public void SaveString(string _key)
    {
        PlayerPrefs.SetString("SelectedTile", _key);
    }

    public void SavePlayerString(string _key)
    {
        PlayerPrefs.SetString("SelectedPlayerSkin", _key);
    }
#endif
}
