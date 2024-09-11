using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    private void Start()
    {
        _settingPanel.SetActive(false);
    }

    public void StartButton()
    {
        Debug.Log("Ω√¿€");
    }

    public void SettingButton()
    {
        _settingPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ExitSetting()
    {
        _settingPanel.SetActive(false);
    }
}
