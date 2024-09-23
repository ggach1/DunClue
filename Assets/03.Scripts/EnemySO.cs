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

    public List<string> throwStone;
    public List<string> card;
    public List<string> focus;

    public void ThrowStone()
    {
        int r;
    }
}
