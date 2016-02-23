using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemController : MonoBehaviour {

    public bool canDragItem;

    public Item item;
    public Sprite sprite;

    /**
    * Set the references of the slot into the InventoryController using an Event Trigger
    */
    public void SetReferences(bool mouseOver) {
        InventoryController invControl = transform.parent.parent.GetComponent<InventoryController>();
        if (canDragItem) {
            Transform trans = (mouseOver || invControl.canDragItem) ? this.transform : null;
            invControl.selectedItem = trans;
        }
    }

    public void IncreaseAmount(int amount) {
        item.amount += amount;
        transform.Find("Amount").GetComponent<Text>().text = item.amount.ToString();

    }

}
