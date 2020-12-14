using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU;
using KPU.Manager;

namespace Assets.Scripts.UI
{
    
public class GameEndButtonUI : MonoBehaviour
{
     public void Clicked()
        {
            Application.Quit();
        }
}
}
