namespace Scripts.Inventory
{
    using UnityEngine;

    public class Booster : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryManager.Instance.AddItem("booster");
                gameObject.SetActive(false);
            }
        }
    }
}