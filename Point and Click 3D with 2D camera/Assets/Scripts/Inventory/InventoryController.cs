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
    void Start() {
        CreateInvetory();
    }

    /**
     * Update is called once per frame
     */
    void Update() {
        if (selectedItem != null) {
            if (Input.GetMouseButtonDown(0)) {
                canDragItem = true;
                originalSlot = selectedItem.parent;
                selectedItem.GetComponent<Image>().raycastTarget = false;
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
            foreach (Transform t in this.transform) {
                Destroy(t.gameObject);
            }
            CreateInvetory();
        }
    }

    /**
    * Create the Inventory with a X numbers of lines and Y numbers of columns, 
    * also instatiate the itens of the player    
    */
    private void CreateInvetory() {
        for (int x = 1; x <= invetorySize.x; x++) {
            for (int y = 1; y <= invetorySize.y; y++) {
                GameObject slot = Instantiate(slotPrefab) as GameObject;
                slot.transform.SetParent(this.transform);
                slot.name = "slot_" + x + "_" + y;
                slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x / (invetorySize.x + 1) * x,
                                                                                  windowSize.y / (invetorySize.y + 1) * -y, 0);
                if (x + (y - 1) * 4 <= GameDB.sortedItens.Count) {
                    GameObject item = Instantiate(itemPrefab) as GameObject;
                    item.transform.SetParent(slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    ItemController i = item.GetComponent<ItemController>();

                    // Item component
                    i.item.name = GameDB.sortedItens[(x + (y - 1) * 4) - 1].item.name;
                    i.item.type = GameDB.sortedItens[(x + (y - 1) * 4) - 1].item.type;
                    i.item.description = GameDB.sortedItens[(x + (y - 1) * 4) - 1].item.description;
                    i.sprite = GameDB.sortedItens[(x + (y - 1) * 4) - 1].sprite;

                    item.name = i.item.name;
                    item.GetComponent<Image>().sprite = i.sprite;
                }
            }
        }
    }
    /**
    * Drag an Item to a Slot, if there is an other Item, exchange places    
    */
    private void DragItem() {
        if (Input.GetMouseButton(0) && canDragItem) {
            selectedItem.position = Input.mousePosition;

            // CLICK RELEASE     

        } else if (Input.GetMouseButtonUp(0)) {
            canDragItem = false;
            SetDragableItens(true);

            if (selectedSlot == null) {
                selectedItem.SetParent(originalSlot);
            } else {
                if (selectedSlot.childCount > 0) {
                    // Change the parent of the item in the slot
                    selectedSlot.GetChild(0).SetParent(originalSlot);
                    // Move the item to the previous location of the item you're holding
                    originalSlot.GetChild(1).localPosition = Vector3.zero;
                }
                selectedItem.SetParent(selectedSlot);
            }
            selectedItem.localPosition = Vector3.zero;
            selectedItem.GetComponent<Image>().raycastTarget = true;
        }
    }

    /**
    * 
    */
    private void SetDragableItens(bool b) {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item")) {
            item.GetComponent<ItemController>().canDragItem = b;
        }
    }
}
