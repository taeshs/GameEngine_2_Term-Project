namespace Scripts.Inventory
{

    using System.Collections;
    using System.Collections.Generic;
    using KPU.Manager;
    using UnityEngine;

    public class ItemEventManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventManager.On("use_crystal", OnUseCrystal);
            EventManager.On("use_stone", OnUseStone);
            EventManager.On("get_treasure", OnGetTreasure);
        }

        public void OnUseCrystal(object obj)
        {
            /*
            var enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.Damage(1);
            }
            */
            print("use stone!!!!!!!!!!!!!!!!!!");
        }

        public void OnUseStone(object obj)
        {
            print("use stone!!!!!!!!!!!!!!!!!!");
        }

        public void OnGetTreasure(object obj)
        {
            print("get Treasure!!!!!!!!!!!!!!");
        }
    }
}
