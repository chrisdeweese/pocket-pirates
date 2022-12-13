using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerStat")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public float speed = 1f;
}