using UnityEngine;
using System.Collections.Generic;
using LitJson;

public class Collectable : Interactables {

    public Item item;
    public int spritePos;
    public bool canDragItem;

    /**
     * Collect an Item and add to the Player Inventory
     */
    public override void Interact() {
        GameManager gm = GameManager.gm;
        // Last item picked
        gm.player.itensHeld = item;

        // Create the IC and add it to the inventory
        ItemController ic = createItemController();
        gm.invControl.AddItem(ic);
        gm.invControl.CreateAndRecreatetInvetory();

        // Display Item name in UI
        gm.invDisp.UpdateDisplay();
        // Reset the cursor icon before detroy the Item
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        this.gameObject.SetActive(false);
    }

    private ItemController createItemController() {
        ItemController ic = gameObject.AddComponent<ItemController>();
        ic.item = this.item;
        ic.item.spritePos = this.spritePos;
        ic.canDragItem = this.canDragItem;
        Vector2 coords = GameManager.gm.invControl.getEmptySlotPos();
        ic.item.coords = new int[] { (int)coords.x, (int)coords.y };

        return ic;
    }

}
