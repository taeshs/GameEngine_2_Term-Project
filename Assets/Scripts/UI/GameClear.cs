using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameClear : MonoBehaviour
{
    [SerializeField] Player _player;
    void Start()
    {
        EventManager.On("game_started", Hide);
        EventManager.On("game_ended", Hide);
        EventManager.On("game_paused", Hide);
        EventManager.On("game_clear", Show);
    }

    private void Show(object obj) { 
        gameObject.SetActive(true);
        
    }

    // private void Hide(object obj) => gameObject.SetActive(false);

    private void Hide(object obj)
    {
        gameObject.SetActive(false);
    }
}
