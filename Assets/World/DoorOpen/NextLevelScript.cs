using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    [Tooltip("������ ���������� ������ ��� ��������")]
    public int nextLevelIndex;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called"); // �������� ������ OnTriggerEnter

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger"); // �������� ����
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        Debug.Log("Loading next level with index: " + nextLevelIndex); // �������� �������
        SceneManager.LoadScene(nextLevelIndex);
    }
}
