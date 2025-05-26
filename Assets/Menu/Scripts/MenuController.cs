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

        //if (settingsMenu)
        //{
        //    AudioSettings.MusicVolume
        //}
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
        Time.timeScale = 1.0f;
    }

    public void selectLevel_1()
    {
        SceneManager.LoadScene("Level-1");
        Time.timeScale = 1.0f;
    }
    public void selectLevel_2()
    {
        SceneManager.LoadScene("Level-2");
        Time.timeScale = 1.0f;
    }
    public void selectLevel_3()
    {
        SceneManager.LoadScene("Level-3");
        Time.timeScale = 1.0f;
    }
    public void selectLevel_4()
    {
        SceneManager.LoadScene("Level-4");
        Time.timeScale = 1.0f;
    }
    public void selectLevel_5()
    {
        SceneManager.LoadScene("Level-5");
        Time.timeScale = 1.0f;
    }
    public void selectLevel_6()
    {
        SceneManager.LoadScene("Level-6");
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

