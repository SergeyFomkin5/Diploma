using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject levelsMenu;

    private GameObject activeMenu;
    public void btnPLay()
    {
        levelsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void btnSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void btnQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    //void Update()
    //{
    //    // ��������� ������� ������� Escape ��� �������� � ���������� ����
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        BackToPreviousMenu();
    //    }
    //}

    //public void ShowMenu(GameObject menu)
    //{
    //    // �������� ������� �������� ����
    //    if (activeMenu != null)
    //    {
    //        activeMenu.SetActive(false);
    //    }

    //    // ���������� ����� ���� � ���������� ��� ��� ��������
    //    menu.SetActive(true);
    //    activeMenu = menu;
    //}

    //public void BackToPreviousMenu()
    //{
    //    if (activeMenu == levelsMenu)
    //    {
    //        ShowMenu(mainMenu);
    //    }
    //    else if (activeMenu == settingsMenu)
    //    {
    //        ShowMenu(mainMenu);
    //    }
    //    // �������� �������������� ������� ��� ������ ����, ���� �����
    //}
}
