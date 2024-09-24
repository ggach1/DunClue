using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Object/Enemy")]
public class EnemySO : ScriptableObject
{
    public string _enemyName;
    public float _attack;
    public float _health;
    public float _evasion;
}
