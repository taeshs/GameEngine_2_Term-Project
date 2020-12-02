using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Inventory.Scripts;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem("stone");
            gameObject.SetActive(false);
        }
    }
}
