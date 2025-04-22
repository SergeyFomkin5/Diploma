using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Тип настройки")]
    [SerializeField] private bool isMusicVolume; // Если true - музыка, false - звуки

    private Scrollbar _scrollbar;

    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();

        // Устанавливаем начальное значение Scrollbar из сохранённых настроек
        if (isMusicVolume)
            _scrollbar.value = AudioSettings.MusicVolume;
        else
            _scrollbar.value = AudioSettings.SoundVolume;

        // Подписываемся на изменение значения
        _scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value)
    {
        if (isMusicVolume)
        {
            AudioSettings.MusicVolume = value;
            Debug.Log($"Громкость музыки изменена: {value}");
        }
        else
        {
            AudioSettings.SoundVolume = value;
            Debug.Log($"Громкость звуков изменена: {value}");
        }

        // Здесь можно сразу обновить звук в аудио-менеджере, если он есть
        // Например: AudioManager.Instance.UpdateVolume();
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        _scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
    }
}
