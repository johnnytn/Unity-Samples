using UnityEngine;
using System.Collections.Generic;
using LitJson;

public class Collector : Interactables {

    public Item item;
    public int spritePos;
    public bool canDragItem;

    /**
     * Collect an Item and add to the Player Inventory
     */
    public override void Interact() {
        GameManager gm = GameManager.gm;
        List<Item> itens = gm.player.itensHeld;
        itens = new List<Item>();
        ItemController ic = createItemController();
        itens.Add(item);
        gm.invControl.AddItem(ic);
        gm.invControl.CreateAndRecreatetInvetory();

        // Display Item name in UI
        gm.invDisp.UpdateDisplay();
        GameObject.Destroy(this.gameObject, 0.1f);
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
