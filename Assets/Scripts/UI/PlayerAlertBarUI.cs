using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class PlayerAlertBarUI : MonoBehaviour
    {

        private Slider _slider;
        public Player _player;
        public Stat _stat;

     private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            _slider.value = _player.Alert / _stat.MaxAlert;
            
        }
    }
}
