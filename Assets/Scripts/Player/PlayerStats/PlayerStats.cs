using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerStat")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public float moveSpeed = 1f;
    public float repairSpeed = 1f;
}