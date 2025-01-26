using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour

{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject levelsMenu;

    private void Start()
    {
        // ���������, ��� ��� ���� ���������, ����� ��������
        settingsMenu.SetActive(false);
        levelsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� ������� ���� ��������, ��������� ���
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
            // ���� ������� ���� �������, ��������� ���
            else if (levelsMenu.activeSelf)
            {
                levelsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        levelsMenu.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }

    public void ShowLevelsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void selectLevel_0()
    {
        SceneManager.LoadScene("Level-0");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

