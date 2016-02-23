using UnityEngine;
using System.Collections.Generic;

public class GameManager : Util {

    public static GameManager gm = null;

    [HideInInspector]
    public Node currentNote;
    public Node startingNode;

    public Player player;
    public InventoryDisplay invDisp;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public Loading load;
    public GameObject inventory;
    // Cursor Icon
    public Texture2D cursorTexture;

    public List<ItemController> allItens = new List<ItemController>();
    public List<ItemController> sortedItens = new List<ItemController>();
    public Sprite[] sprites;

    void Awake() {
        PrepareGameManager();
        PrepareInventory();
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    void Start() {
        startingNode.Arrive();
    }

    // Update is called once per frame
    void Update() {
        CloseInspectors();
    }

    /**
    * Close UI elements used to inspect objects
    */
    private void CloseInspectors() {
        if (Input.GetMouseButtonDown(1) && currentNote != null && currentNote.GetComponent<Prop>() != null) {
            if (ivCanvas.gameObject.activeInHierarchy) {
                ivCanvas.Close();
                return;
            }
            if (obsCamera.gameObject.activeInHierarchy) {
                obsCamera.Close();
                return;
            }
            currentNote.GetComponent<Prop>().loc.Arrive();
        }
    }

    /**
    * Prepare GM before the game starts
    */
    private void PrepareGameManager() {
        if (gm == null) {
            gm = this;
        } else if (gm != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void PrepareInventory() {
        inventory.GetComponent<InventoryController>().CreateSlots();
        PrepareItens();
        inventory.GetComponent<InventoryController>().CreateAndRecreatetInvetory();
    }

    /**
    * Prepare the Item list, creating Itens and populating a List
    */
    private void PrepareItens() {
        // Item
        Item item = new Item("Sword", "sharp weapon", ItemType.EQUIPMENT, 1);
        ItemController ic = gameObject.AddComponent<ItemController>();
        ic.item = item;
        ic.sprite = sprites[0];
        ic.coords = new Vector2(1, 1);
        allItens.Add(ic);

        // Item
        Item item1 = new Item("Health Potion", "Heal your wounds", ItemType.USABLE, 1);
        ItemController ic1 = gameObject.AddComponent<ItemController>();
        ic1.item = item1;
        ic1.sprite = sprites[1];
        ic1.coords = new Vector2(2, 1);
        allItens.Add(ic1);

        // Item
        Item item2 = new Item("Scraps", "Scraps Scraps", ItemType.MISCELLANEOUS, 1);
        ItemController ic2 = gameObject.AddComponent<ItemController>();
        ic2.item = item2;
        ic2.sprite = sprites[2];
        ic2.coords = new Vector2(3, 1);
        allItens.Add(ic2);

        // Item
        Item item3 = new Item("Health Potion", "Heal your wounds", ItemType.USABLE, 1);
        ItemController ic3 = gameObject.AddComponent<ItemController>();
        ic3.item = item3;
        ic3.sprite = sprites[1];
        ic3.coords = new Vector2(4, 1);
        allItens.Add(ic3);

        SortAllItens();
    }

    /**
     * Add an Item to the list
     */
    public void AddItem(ItemController ic) {
        allItens.Add(ic);
        SortAllItens();
    }

    /**
    * Add all Itens to the list
    */
    public void SortAllItens() {
        sortedItens.Clear();
        sortedItens.AddRange(allItens);
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

    /**
    * Get the position of the next empty slot
    */
    public Vector2 getEmptySlotPos() {
        int xPos = 1;
        int yPos = 1;
        bool isCoordsSet = false;
        Vector2 coords = new Vector2(xPos, yPos);

        InventoryController invControl = inventory.GetComponent<InventoryController>();
        for (int y = 1; y <= invControl.invetorySize.y; y++) {
            for (int x = 1; x <= invControl.invetorySize.x; x++) {
                Transform slot = inventory.transform.Find("slot_" + x + "_" + y);

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
}
