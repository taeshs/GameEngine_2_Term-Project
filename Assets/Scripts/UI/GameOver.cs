using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU;
using KPU.Manager;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.On("game_started", Hide);
            EventManager.On("game_ended", Show);
            EventManager.On("game_paused", Hide);
        
    }

     private void Show(object obj) => gameObject.SetActive(true); //c#에 이런기능이

       // private void Hide(object obj) => gameObject.SetActive(false);

        private void Hide(object obj)
        {
            gameObject.SetActive(false);
        }

}
