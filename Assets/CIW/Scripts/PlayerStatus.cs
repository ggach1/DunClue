using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private GameObject _statusMenu;
    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private TextMeshProUGUI _attackText;
    [SerializeField] private TextMeshProUGUI _evasionText;
    [SerializeField] private TextMeshProUGUI _healText;

    [SerializeField] private GameObject _questBar;
    [SerializeField] private TextMeshProUGUI _attackStone;
    [SerializeField] private TextMeshProUGUI _attackCandle;
    [SerializeField] private TextMeshProUGUI _attackFocus;

    [SerializeField] private GameObject _attackBar;
    [SerializeField] private TextMeshProUGUI _attackADText;
    [SerializeField] private TextMeshProUGUI _attackAPText;

    public bool QuestStatus { get; set; } = false;
    public bool AttackStatus { get; set; } = false;
    public bool EvasionStatus { get; set; } = false;
    public bool HealStatus { get; set; } = false;

    public bool InQuest { get; set; } = false;
    public bool InAttack { get; set; } = false;
    public bool InEvasion { get; set; } = false;
    public bool InHeal { get; set; } = false;

    public bool PanelOpen { get; set; } = false;

    public bool QuestStone { get; set; } = false;
    public bool QuestCandle { get; set; } = false;
    public bool QuestFocus { get; set; } = false;

    private void Start()
    {
        QuestStatus = true;
        AttackStatus = false;
        EvasionStatus = false;
        HealStatus = false;

        _statusMenu.SetActive(true);
        _questBar.SetActive(false);
        _attackBar.SetActive(false);
    }

    private void Update()
    {
        if (QuestStatus)
        {
            _questText.color = Color.yellow;

            if (Input.GetKeyDown(KeyCode.Return)) // ¼Ó¼º ÆÐ³Î ¿ÀÇÂ
            {
                _questBar.SetActive(true);
                _statusMenu.SetActive(false);
                PanelOpen = true;
                InQuest = true;
                QuestStone = true;
                QuestCandle = false;
                QuestFocus = false;

                _attackStone.color = Color.yellow;
                _attackCandle.color = Color.white;
                _attackFocus.color = Color.white;

                if (InQuest && QuestStone)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        _attackStone.color = Color.white;
                        _attackCandle.color = Color.yellow;
                        _attackFocus.color = Color.white;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        _attackStone.color = Color.white;
                        _attackCandle.color = Color.white;
                        _attackFocus.color = Color.yellow;
                    }
                }
                else if (InQuest && QuestCandle)
                {
                    
                }
            }
            else if (Input.GetKeyDown(KeyCode.Backspace) && PanelOpen)
            {
                _questBar.SetActive(false);
                _statusMenu.SetActive(true);
                PanelOpen = false;
                InQuest = false;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !PanelOpen)
            {
                AttackStatus = true;
                _attackText.color = Color.yellow;

                QuestStatus = false;
                _questText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.S) && !PanelOpen)
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
                _attackBar.SetActive(true);
                _statusMenu.SetActive(false);
                PanelOpen = true;
                InAttack = true;

                if (InAttack)
                {
                    _attackADText.color = Color.yellow;
                    _attackAPText.color = Color.white;

                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        _attackADText.color = Color.white;
                        _attackAPText.color = Color.yellow;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        _attackADText.color = Color.yellow;
                        _attackAPText.color = Color.white;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Backspace) && PanelOpen)
            {
                _statusMenu.SetActive(true);
                _attackBar.SetActive(false);
                PanelOpen = false;
                InAttack = false;
            }

            if (!PanelOpen)
            {
                if (Input.GetKeyDown(KeyCode.A))
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
        }
        else if (EvasionStatus)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("È¸ÇÇÃ¢ ¿­¸²");
                PanelOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.Backspace) && PanelOpen)
            {
                Debug.Log("È¸ÇÇÃ¢ ´ÝÈû");
                PanelOpen = false;
            }
            else if (Input.GetKeyDown(KeyCode.W) && !PanelOpen)
            {
                QuestStatus = true;
                _questText.color = Color.yellow;

                EvasionStatus = false;
                _evasionText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !PanelOpen)
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
                Debug.Log("È¸º¹Ã¢ ¿­¸²");
                PanelOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.Backspace) && PanelOpen)
            {
                Debug.Log("È¸º¹Ã¢ ´ÝÈû");
                PanelOpen = false;
            }
            else if (Input.GetKeyDown(KeyCode.W) && !PanelOpen)
            {
                AttackStatus = true;
                _attackText.color = Color.yellow;

                HealStatus = false;
                _healText.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !PanelOpen)
            {
                EvasionStatus = true;
                _evasionText.color = Color.yellow;

                HealStatus = false;
                _healText.color = Color.white;
            }
        }
    }
}
