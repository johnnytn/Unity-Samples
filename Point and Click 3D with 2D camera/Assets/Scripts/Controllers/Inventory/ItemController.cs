using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

    public bool canDragItem;
    public Item item;


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

    /**
    * Increase the item amount
    */
    public void IncreaseAmount(int amount) {
        item.amount += amount;
        transform.Find("Amount").GetComponent<Text>().text = item.amount.ToString();
    }

}
