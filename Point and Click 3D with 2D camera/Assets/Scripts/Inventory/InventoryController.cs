using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public Transform selectedItem;
    public Transform selectedSlot;
    public Transform originalSlot;

    public bool canDragItem;

    public GameObject slotPrefab;
    public GameObject itemPrefab;

    public Vector2 invetorySize = new Vector2(4, 6);
    public float slotSize;
    public Vector2 windowSize;

    // Use this for initialization
    void Awake() {
//        CreateSlots();
    }

    /**
     * Update is called once per frame
     */
    void Update() {
        if (selectedItem != null) {
            // Click Down
            if (Input.GetMouseButtonDown(0)) {
                canDragItem = true;
                originalSlot = selectedItem.parent;
                //selectedItem.GetComponent<Image>().raycastTarget = false;
                SetDragableItens(false);
            }
            DragItem();
        }
    }

    /**
     * Create and Recreate(if sorted) the Inventory
     */
    public void CreateAndRecreatetInvetory() {
        if (this.transform.childCount < 1) {
            CreateInvetory();
        } else {
            ClearSlots();
            CreateInvetory();
        }
    }

    /**
    * Create the Inventory with a X numbers of lines and Y numbers of columns
    */
    public void CreateSlots() {
        for (int x = 1; x <= invetorySize.x; x++) {
            for (int y = 1; y <= invetorySize.y; y++) {
                GameObject slot = Instantiate(slotPrefab) as GameObject;
                slot.transform.SetParent(this.transform);
                slot.name = "slot_" + x + "_" + y;
                slot.GetComponent<SlotController>().coords = new Vector2(x, y);
                slot.GetComponent<SlotController>().isEmpty = true;
                slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                // Calculate the position of the slot based on the window size and inventory size
                float xPos = windowSize.x / (invetorySize.x + 1) * x;
                float yPos = windowSize.y / (invetorySize.y + 1) * -y;
                // Attach a slot to the anchor
                slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos, 0);
            }
        }
    }

    /**
    * Clear the invetory Slots, deleting the Itens
    */
    public void ClearSlots() {
        foreach (Transform t in this.transform) {
            if (!t.tag.Equals("UI") && t.childCount > 0) {
                Destroy(t.GetChild(0).gameObject);
            }
        }
    }

    /**
    * Create the invetory Itens
    */
    private void CreateInvetory() {
        for (int n = 0; n < GameManager.gm.sortedItens.Count; n++) {
            ItemController iData = GameManager.gm.sortedItens[n];
            Vector2 coords = iData.coords;
            if (coords != Vector2.zero) {
                GameObject item = Instantiate(itemPrefab) as GameObject;
                item.name = iData.item.name;
                item.GetComponent<Image>().sprite = iData.sprite;
                Transform slot = transform.Find("slot_" + coords.x + "_" + coords.y);
                item.transform.SetParent(slot);
                slot.GetComponent<SlotController>().isEmpty = false;
                item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                // Item component
                ItemController i = item.GetComponent<ItemController>();
                i.item = iData.item;
                i.sprite = iData.sprite;
                i.coords = iData.coords;
                i.canDragItem = true;
            }
        }
    }

    /**
    * Drag an Item to a Slot, if there is an other Item, exchange places    
    */
    private void DragItem() {
        // Click Drag 
        if (Input.GetMouseButton(0) && canDragItem) {
            selectedItem.position = Input.mousePosition;

            // Click Release 
        } else if (Input.GetMouseButtonUp(0)) {
            canDragItem = false;
            SetDragableItens(true);
            Debug.Log("aqui");

            if (selectedSlot == null) {
                selectedItem.SetParent(originalSlot);
            } else {
                if (selectedSlot.childCount > 0) {
                    Transform slotChild = selectedSlot.GetChild(0);
                    ItemController selectedIC = selectedItem.GetComponent<ItemController>();
                    ItemController slotItemIC = slotChild.GetComponent<ItemController>();
                    // Stack Itens
                    if (isStackable(slotChild, selectedIC)) {
                        selectedIC.IncreaseAmount(slotItemIC.item.amount);
                        Destroy(slotChild.gameObject);
                        // Swap Item 
                    } else {

                        //ChangeCoordinates(selectedIC, slotItemIC);
                        // Change the parent of the item in the slot
                        slotChild.SetParent(originalSlot);
                        // Move the item to the previous location of the item you're holding
                        originalSlot.GetChild(0).localPosition = Vector3.zero;

                    }
                }
                selectedItem.SetParent(selectedSlot);
            }
            selectedItem.localPosition = Vector3.zero;
            //selectedItem.GetComponent<Image>().raycastTarget = true;
        }
    }

    //TODO 
    private void ChangeCoordinates(ItemController selectedIC, ItemController slotItemIC) {
        // Vector2 oldPos = selectedIC.coords;
        //Vector2 newPos = slotItemIC.coords;
        // Debug.Log("oldPos:" + oldPos);
        //Debug.Log("newPos:" + newPos);
        //selectedIC.coords = oldPos;
        //slotItemIC.coords = newPos;
        //GameManager.gm.allItens
        throw new NotImplementedException();
    }

    /**
    * Define if an Item is dragable
    */
    private void SetDragableItens(bool b) {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item")) {
            item.GetComponent<ItemController>().canDragItem = b;
        }
    }

    /**
    * Define if an Item is stackable
    */
    private bool isStackable(Transform slotChild, ItemController selectedIC) {
        return selectedItem.name == slotChild.name
               && !selectedIC.item.Equals(slotChild.GetComponent<ItemController>().item) &&
               (selectedIC.item.type == ItemType.USABLE || selectedIC.item.type == ItemType.MISCELLANEOUS);
    }
       
}
