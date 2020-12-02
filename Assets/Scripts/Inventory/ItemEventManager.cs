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
        }

        public void OnUseCrystal(object obj)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.Damage(1);
            }
        }
    }
}
