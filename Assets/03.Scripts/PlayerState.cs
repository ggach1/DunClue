using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int _plycurrentHp = 15;
    [SerializeField] private int _plymaxHp = 15;
    [SerializeField] private int _plyAtk = 3;
    [SerializeField] private float _plyAvoidRate = 0f;
    [SerializeField] private int Action = 5;
    private bool _plyAvoid = false;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

}
