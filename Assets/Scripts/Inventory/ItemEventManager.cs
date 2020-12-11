namespace Scripts.Inventory
{

    using System.Collections;
    using System.Collections.Generic;
    using KPU.Manager;
    using UnityEngine;

    public class ItemEventManager : MonoBehaviour
    {
        [SerializeField] private Player player;
        // Start is called before the first frame update
        void Start()
        {
            EventManager.On("use_crystal", OnUseCrystal);
            EventManager.On("use_stone", OnUseStone);
            EventManager.On("get_treasure", OnGetTreasure);
        }


        public void OnUseStone(object obj)
        {
            print("use stone!!!!!!!!!!!!!!!!!!");
            if(player.Stat.Alert < 99)
            {
                float Minus_alert = player.Stat.Alert / 2 * -1.0f;
                player.AddAlert(Minus_alert);
            }
            
        }

        public void OnUseCrystal(object obj)
        {
            //player.
            print("use crystal!!!!!!!!!!!!!!!!!!");
        }

        

        public void OnGetTreasure(object obj)
        {
            print("get Treasure!!!!!!!!!!!!!!");
        }
    }
}
