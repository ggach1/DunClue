using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool QuestStatus { get; set; } = false;
    public bool AttackStatus { get; set; } = false;
    public bool EvasionStatus { get; set; } = false;
    public bool HealStatus { get; set; } = false;
}
