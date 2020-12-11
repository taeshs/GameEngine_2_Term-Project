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
            EventManager.On("use_statue", OnUseStatue);
            EventManager.On("get_treasure", OnGetTreasure);
            EventManager.On("use_booster", OnUseBooster);
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

        public void OnUseStatue(object obj)
        {
            print("use crystal!!!!!!!!!!!!!!!!!!");
            var enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.setStun();
            }
        }



        public void OnGetTreasure(object obj)
        {
            print("get Treasure!!!!!!!!!!!!!!");
        }

         public void OnUseBooster(object obj)
        {
            print("use booster!!!!!!!!!!!!!!");
            player.BoosterOn();
            print("use booster!!!!!!!!!!!!!11111111111111111111111111!");
        }
        
    }
}
