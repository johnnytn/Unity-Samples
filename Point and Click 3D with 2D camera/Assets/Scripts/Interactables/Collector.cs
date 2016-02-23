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
        gm.AddItem(ic);
        GameObject.Destroy(this.gameObject, 0.1f);

        // Display Item name in UI
        gm.invDisp.UpdateDisplay();
    }

    private ItemController createItemController() {
        ItemController ic = gameObject.AddComponent<ItemController>();
        ic.item = this.item;
        ic.sprite = this.sprite;
        ic.canDragItem = this.canDragItem;
        return ic;
    }

}
