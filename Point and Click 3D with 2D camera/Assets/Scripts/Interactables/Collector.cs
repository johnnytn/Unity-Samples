using UnityEngine;
using System.Collections.Generic;

public class Collector : Interactables {

    public Item item;
    public Sprite sprite;
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
        ic.sprite = this.sprite;
        ic.canDragItem = this.canDragItem;
        ic.coords = GameManager.gm.invControl.getEmptySlotPos();

        return ic;
    }

}
