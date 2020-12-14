using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU;
using KPU.Manager;

namespace Assets.Scripts.UI
{
public class MainMenuUI : MonoBehaviour
{
    
     void Start()
        {
            EventManager.On("game_started", Hide);
            EventManager.On("game_ended", Hide);
            EventManager.On("game_paused", Hide);
            EventManager.On("game_clear", Hide);
        }

        private void Show(object obj) => gameObject.SetActive(true); //c#에 이런기능이

       // private void Hide(object obj) => gameObject.SetActive(false);

        private void Hide(object obj)
        {
            gameObject.SetActive(false);
        }


}
}
