using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("��� ���������")]
    [SerializeField] private bool isMusicVolume; // ���� true - ������, false - �����

    private Scrollbar _scrollbar;

    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();

        // ������������� ��������� �������� Scrollbar �� ���������� ��������
        if (isMusicVolume)
            _scrollbar.value = AudioSettings.MusicVolume;
        else
            _scrollbar.value = AudioSettings.SoundVolume;

        // ������������� �� ��������� ��������
        _scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value)
    {
        if (isMusicVolume)
        {
            AudioSettings.MusicVolume = value;
            Debug.Log($"��������� ������ ��������: {value}");
        }
        else
        {
            AudioSettings.SoundVolume = value;
            Debug.Log($"��������� ������ ��������: {value}");
        }

        // ����� ����� ����� �������� ���� � �����-���������, ���� �� ����
        // ��������: AudioManager.Instance.UpdateVolume();
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������
        _scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
    }
}
