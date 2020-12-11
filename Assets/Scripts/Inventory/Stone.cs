namespace Scripts.Inventory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Stone : MonoBehaviour
    {
        private void OnEnable()
        {
            //print("sss");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryManager.Instance.AddItem("stone");
                gameObject.SetActive(false);
            }
        }
    }
}
