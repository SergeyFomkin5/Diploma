using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    [Tooltip("Индекс следующего уровня для загрузки")]
    public int nextLevelIndex;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called"); // Проверка вызова OnTriggerEnter

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger"); // Проверка тега
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        Debug.Log("Loading next level with index: " + nextLevelIndex); // Проверка индекса
        SceneManager.LoadScene(nextLevelIndex);
    }
}
