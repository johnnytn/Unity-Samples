using UnityEngine;
using System.Collections.Generic;

public class Collector : Interactables {

    public Item item;

    /**
     * Collect an Item and add to the Player Inventory
     */
    public override void Interact() {
        Debug.Log("Adding item");
        List<Item> itens = GameManager.gm.player.itensHeld;
        if (itens == null) {
            itens = new List<Item>();
        }
        itens.Add(item);
        GameManager.gm.invDisp.UpdateDisplay();
    }

}
