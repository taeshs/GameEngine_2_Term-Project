using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU;
using KPU.Manager;

namespace Assets.Scripts.UI
{

    public class GameStartButtonUI : MonoBehaviour
    {

        public void Clicked()
        {
            print("클릭");
            EventManager.Emit("game_started", null);
        }
    }
}