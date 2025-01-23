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
    //    // Проверяем нажатие клавиши Escape для возврата в предыдущее меню
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        BackToPreviousMenu();
    //    }
    //}

    //public void ShowMenu(GameObject menu)
    //{
    //    // Скрываем текущее активное меню
    //    if (activeMenu != null)
    //    {
    //        activeMenu.SetActive(false);
    //    }

    //    // Показываем новое меню и запоминаем его как активное
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
    //    // Добавьте дополнительные условия для других меню, если нужно
    //}
}
