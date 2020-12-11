namespace Scripts.Inventory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Statue : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryManager.Instance.AddItem("statue");
                gameObject.SetActive(false);
            }
        }
    }
}
