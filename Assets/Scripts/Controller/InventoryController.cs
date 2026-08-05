using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _inventory;

    public void AddItem(GameObject item)
    {
        GameObject newItem = Instantiate(item, _inventory, false);

        Button button = newItem.GetComponent<Button>();
        if (button == null)
        {
            button = newItem.AddComponent<Button>();
        }

        button.onClick.AddListener(() => OnItemClicked(newItem));
    }

    private void OnItemClicked(GameObject item)
    {
        IUsable usable = item.GetComponent<IUsable>();
        if (usable == null) return;

        usable.Use(_player);
    }
}
