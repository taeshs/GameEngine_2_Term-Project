namespace Scripts.Inventory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Treasure : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryManager.Instance.AddItem("treasure");
                gameObject.SetActive(false);
            }
        }
    }
}
