using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class PlayerHealthBarUI : MonoBehaviour
    {
        private Slider _slider;
        public Player _player;


        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {

            _slider.value = _player.Hp/ _player.MaxHp;

            //print(_slider.value);
           
        }
    }
}
