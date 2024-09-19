using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private void Start()
    {
        QuestStatus = true;
        _questText.color = Color.yellow;
        AttackStatus = false;
        EvasionStatus = false;
        HealStatus = false;
    }

    private void Update()
    {
        if (QuestStatus && Input.GetKeyDown(KeyCode.D))
        {
            AttackStatus = true;
            _attackText.color = Color.yellow;
            
            QuestStatus = false;
            _questText.color = Color.white;
        }
        else if (QuestStatus && Input.GetKeyDown(KeyCode.S))
        {
            EvasionStatus = true;
            _evasionText.color = Color.yellow;
            
            QuestStatus = false;
            _questText.color = Color.white;
        }

        if (AttackStatus && Input.GetKeyDown(KeyCode.A))
        {
            QuestStatus = true;
            _questText.color = Color.yellow;
            
            AttackStatus = false;
            _attackText.color = Color.white;
        }
        else if (AttackStatus && Input.GetKeyDown(KeyCode.S))
        {
            HealStatus = true;
            _healText.color = Color.yellow;

            AttackStatus = false;
            _attackText.color = Color.white;
        }

        if (EvasionStatus && Input.GetKeyDown(KeyCode.W))
        {
            QuestStatus = true;
            _questText.color = Color.yellow;

            EvasionStatus = false;
            _evasionText.color = Color.white;
        }
        else if (EvasionStatus && Input.GetKeyDown(KeyCode.D))
        {
            HealStatus = true;
            _healText.color = Color.yellow;

            EvasionStatus = false;
            _evasionText.color = Color.white;
        }

        if (HealStatus && Input.GetKeyDown(KeyCode.W))
        {
            AttackStatus = true;
            _attackText.color = Color.yellow;

            HealStatus = false;
            _healText.color = Color.white;
        }
        else if (HealStatus && Input.GetKeyDown(KeyCode.A))
        {
            EvasionStatus = true;
            _evasionText.color = Color.yellow;

            HealStatus = false;
            _healText.color = Color.white;
        }
    }
}
