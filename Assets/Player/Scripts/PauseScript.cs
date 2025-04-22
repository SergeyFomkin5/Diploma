using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settings;
    public TerminalList terminalList;
    public bool isPaused = false;
    public bool isSettingsActive = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume(); // Если игра на паузе — возобновить
            else
                Pause();  // Если игра идет — поставить на паузу
        }

        if (isSettingsActive && Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(false);
            isSettingsActive = false;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;  // Возобновляем время
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void Settings()
    {
        settings.SetActive(true);
        isSettingsActive = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}