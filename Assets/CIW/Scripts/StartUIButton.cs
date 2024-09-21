using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private string _nextScene;

    private void Start()
    {
        _settingPanel.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
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
