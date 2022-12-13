using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemBase : ScriptableObject
{
    public string itemName { get; set; }
    public Sprite itemSprite { get; set; }
    public bool isPickup { get; set; }
    public ItemTypes itemType { get; set; }

    public enum ItemTypes
    {
        Ammo,
        Cannon
    }
}