using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemBase : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}