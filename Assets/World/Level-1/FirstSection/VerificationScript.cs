using UnityEngine;
using System.Collections;
using System.Linq;

public class VerificationScript : MonoBehaviour
{
    [SerializeField] private GameObject failMessage;
    [SerializeField] private GameObject congratulationsMessage;

    private cubesTestsScript cubesTests;
    private Coroutine messageCoroutine;
    private bool checkPerformed;
    private bool isDirty;

    private void Start()
    {
        cubesTests = FindObjectOfType<cubesTestsScript>();
    }

    private void Update()
    {
        if (cubesTests != null)
        {
            bool allPlaced = cubesTests.intCube.isPlaced &&
                            cubesTests.boolCube.isPlaced &&
                            cubesTests.stringCube.isPlaced &&
                            cubesTests.charCube.isPlaced &&
                            cubesTests.floatCube.isPlaced;

            if (!allPlaced)
            {
                isDirty = true;
                checkPerformed = false;
                HideAllMessages();
            }
            else if (isDirty && !checkPerformed)
            {
                CheckAnswers();
                checkPerformed = true;
                isDirty = false;
            }
        }
    }

    private void CheckAnswers()
    {
        int[] answers = {
            cubesTests.intCube.isCorrectAnswer,
            cubesTests.boolCube.isCorrectAnswer,
            cubesTests.stringCube.isCorrectAnswer,
            cubesTests.charCube.isCorrectAnswer,
            cubesTests.floatCube.isCorrectAnswer
        };

        if (answers.Sum() == 5)
        {
            ShowCongratulationsMessage();
        }
        else
        {
            ShowFailMessage();
        }
    }

    private void ShowCongratulationsMessage()
    {
        if (!congratulationsMessage.activeSelf && !failMessage.activeSelf)
        {
            HideAllMessages();
            congratulationsMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void ShowFailMessage()
    {
        if (!failMessage.activeSelf && !congratulationsMessage.activeSelf)
        {
            HideAllMessages();
            failMessage.SetActive(true);
            messageCoroutine = StartCoroutine(HideAfterDelay(5f));
        }
    }

    private void HideAllMessages()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
            messageCoroutine = null;
        }
        failMessage.SetActive(false);
        congratulationsMessage.SetActive(false);
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideAllMessages();
    }
}