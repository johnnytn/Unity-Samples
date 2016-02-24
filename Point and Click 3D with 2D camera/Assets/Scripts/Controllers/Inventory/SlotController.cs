using UnityEngine;
using System.Collections;

public class SlotController : MonoBehaviour {

    public Vector2 coords;
    public bool isEmpty;

    /**
    * Set the references of the slot into the InventoryController using an Event Trigger
    */
    public void SetReferences(bool mouseOver) {
        Transform trans = mouseOver ? this.transform : null;
        transform.parent.GetComponent<InventoryController>().selectedSlot = trans;
    }
}
