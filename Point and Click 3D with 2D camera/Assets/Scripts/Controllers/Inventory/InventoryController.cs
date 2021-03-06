﻿using System;
using System.Collections.Generic;
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

    public List<ItemController> allItens = new List<ItemController>();
    private List<ItemController> sortedItens = new List<ItemController>();

    public List<Item> itens = new List<Item>();
    public Sprite[] sprites;

    /**
     * Update is called once per frame
     */
    void Update() {
        if (selectedItem != null) {
            // Click Down
            if (Input.GetMouseButtonDown(0)) {
                canDragItem = true;
                originalSlot = selectedItem.parent;
                SetDragableItens(false);
            }
            DragItem();
        }
    }

    /**
    * Creating an ItemController
    */
    private ItemController CreateItem(Item item, int spritePos, Vector2 slotPos) {
        ItemController ic = gameObject.AddComponent<ItemController>();
        ic.item = item;
        return ic;
    }

    /**
    * Add all Itens to the list
    */
    public void SortAllItens() {
        sortedItens.Clear();
        itens.Clear();
        foreach (ItemController ic in allItens) {
            sortedItens.Add(ic);
            // Debug.Log(ic);
            //Debug.Log(ic.item);
            itens.Add(ic.item);
        }
    }

    /**
    * Sort Itens by Type
    */
    public void SortItensByType(string type) {
        sortedItens.Clear();
        foreach (ItemController i in allItens) {
            if (i.item.type.ToString() == type) {
                sortedItens.Add(i);
            }
        }
    }

    public void PrepareInventory() {
        CreateSlots();
        //PrepareTestItens();
        CreateAndRecreatetInvetory();
    }

    /**
     * Create and Recreate(if sorted) the Inventory
     */
    public void CreateAndRecreatetInvetory() {
        SortAllItens();
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
        for (int x = 0; x < allItens.Count; x++) {
            ItemController iData = allItens[x];
            Vector2 coords = new Vector2(iData.item.coords[0], iData.item.coords[1]);
            if (coords != Vector2.zero) {
                GameObject item = Instantiate(itemPrefab) as GameObject;
                item.name = iData.item.name;
                item.GetComponent<Image>().sprite = sprites[iData.item.spritePos];
                Transform slot = transform.Find("slot_" + coords.x + "_" + coords.y);
                item.transform.SetParent(slot);
                slot.GetComponent<SlotController>().isEmpty = false;
                item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                // Item component
                ItemController i = item.GetComponent<ItemController>();
                i.item = iData.item;
                i.item.spritePos = iData.item.spritePos;
                i.item.coords = iData.item.coords;

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
                        // Change the parent of the item in the slot
                        slotChild.SetParent(originalSlot);
                        // Move the item to the previous location of the item you're holding
                        originalSlot.GetChild(0).localPosition = Vector3.zero;
                    }
                }
                selectedItem.SetParent(selectedSlot);
            }
            selectedItem.localPosition = Vector3.zero;
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
     * Add an Item to the list
     */
    public void AddItem(ItemController ic) {
        // TODO : search why adding ic directly the reference is missing
        ItemController icTemp = gameObject.AddComponent<ItemController>();
        icTemp.canDragItem = ic.canDragItem;
        icTemp.item = ic.item;
        icTemp.canDragItem = true;

        allItens.Add(icTemp);
        SortAllItens();
    }

    /**
    * Get the position of the next empty slot
    */
    public Vector2 getEmptySlotPos() {
        int xPos = 1;
        int yPos = 1;
        bool isCoordsSet = false;
        Vector2 coords = new Vector2(xPos, yPos);

        for (int y = 1; y <= invetorySize.y; y++) {
            for (int x = 1; x <= invetorySize.x; x++) {
                Transform slot = transform.Find("slot_" + x + "_" + y);
                SlotController sc = slot.GetComponent<SlotController>();

                if (sc.isEmpty && !isCoordsSet) {
                    coords = sc.coords;
                    isCoordsSet = true;
                    sc.isEmpty = false;
                    break;
                }
            }
        }
        return coords;
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

    /**
   * Prepare the Item list, creating Itens and populating a List
   */
    private void PrepareTestItens() {
        // Item
        Item item = new Item(1, "Sword", "sharp weapon", ItemType.EQUIPMENT, 1, 0, new int[] { 1, 1 });
        ItemController ic = CreateItem(item, 0, new Vector2(1, 1));
        allItens.Add(ic);

        // Item
        Item item1 = new Item(2, "Health Potion", "Heal your wounds", ItemType.USABLE, 1, 1, new int[] { 2, 1 });
        ItemController ic1 = CreateItem(item1, 1, new Vector2(2, 1));
        allItens.Add(ic1);

        // Item
        Item item2 = new Item(3, "Scraps", "Scraps Scraps", ItemType.MISCELLANEOUS, 1, 2, new int[] { 3, 1 });
        ItemController ic2 = CreateItem(item2, 2, new Vector2(3, 1));
        allItens.Add(ic2);

        // Item
        Item item3 = new Item(4, "Health Potion", "Heal your wounds", ItemType.USABLE, 1, 1, new int[] { 4, 1 });
        ItemController ic3 = CreateItem(item3, 1, new Vector2(4, 1));
        allItens.Add(ic3);

        SortAllItens();
    }
}
