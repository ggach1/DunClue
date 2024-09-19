using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private TextMeshProUGUI _attackText;
    [SerializeField] private TextMeshProUGUI _evasionText;
    [SerializeField] private TextMeshProUGUI _healText;

    public bool QuestStatus { get; set; } = false;
    public bool AttackStatus { get; set; } = false;
    public bool EvasionStatus { get; set; } = false;
    public bool HealStatus { get; set; } = false;

    public bool PanelOpen { get; set; } = false;

    private void Start()
    {
        QuestStatus = true;
        AttackStatus = false;
        EvasionStatus = false;
        HealStatus = false;
    }

    private void Update()
    {
        if (QuestStatus)
        {
            _questText.color = Color.yellow;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("탐색창 열림");
                PanelOpen = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                AttackStatus = true;
                _attackText.color = Color.yellow;

                QuestStatus = false;
                _questText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                EvasionStatus = true;
                _evasionText.color = Color.yellow;

                QuestStatus = false;
                _questText.color = Color.white;
            }
        }
        else if (AttackStatus)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("공격창 열림");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                QuestStatus = true;
                _questText.color = Color.yellow;

                AttackStatus = false;
                _attackText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                HealStatus = true;
                _healText.color = Color.yellow;

                AttackStatus = false;
                _attackText.color = Color.white;
            }
        }
        else if (EvasionStatus)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("회피창 열림");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                QuestStatus = true;
                _questText.color = Color.yellow;

                EvasionStatus = false;
                _evasionText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                HealStatus = true;
                _healText.color = Color.yellow;

                EvasionStatus = false;
                _evasionText.color = Color.white;
            }
        }
        else if (HealStatus)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("회복창 열림");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                AttackStatus = true;
                _attackText.color = Color.yellow;

                HealStatus = false;
                _healText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                EvasionStatus = true;
                _evasionText.color = Color.yellow;

                HealStatus = false;
                _healText.color = Color.white;
            }
        }
    }
}
