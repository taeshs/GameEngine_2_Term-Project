using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameEndZone : MonoBehaviour
{
    [SerializeField] Player _player;

    private void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("gameOver");
            if (_player.IsEnd)
            {
                EventManager.Emit("game_clear");
                print("gameOver");
            }
        }
    }
}
