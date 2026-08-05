using UnityEngine;

public class GiveItem : MonoBehaviour
{
    [SerializeField] private GameObject _prefabItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InventoryController inventoryController = collision.GetComponent<InventoryController>();
        if(inventoryController != null)
        {
            inventoryController.AddItem(_prefabItem);
            Destroy(this.gameObject);
        }
    }
}
