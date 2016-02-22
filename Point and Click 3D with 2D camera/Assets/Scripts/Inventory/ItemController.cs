using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    public bool canDragItem;


    public Item item;
    public Sprite sprite;

    // Set the references of the item into the InventoryController using an Event Trigger
    public void SetReferences(bool mouseOver) {
        InventoryController invControl = transform.parent.parent.GetComponent<InventoryController>();
        if (canDragItem) {
            Transform trans = (mouseOver || invControl.canDragItem) ? this.transform : null;
            invControl.selectedItem = trans;
        }
    }

}
