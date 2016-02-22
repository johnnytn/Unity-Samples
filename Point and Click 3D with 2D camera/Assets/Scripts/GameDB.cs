using UnityEngine;
using System.Collections.Generic;

public class GameDB : MonoBehaviour {

    public static List<ItemController> allItens = new List<ItemController>();
    public static List<ItemController> sortedItens = new List<ItemController>();
    public Sprite[] sprites;

    // Use this for initialization
    void Awake() {
        PrepareItens();
    }
        
    /**
    * Prepare the Item list, creating Itens and populating a List
    */
    private void PrepareItens() {
        // Item
        Item item = new Item("Sword", "sharp weapon", ItemType.EQUIPMENT);
        ItemController ic = gameObject.AddComponent<ItemController>();
        ic.item = item;
        ic.sprite = sprites[0];
        allItens.Add(ic);

        // Item
        Item item1 = new Item("Health Potion", "Heal your wounds", ItemType.USABLE);
        ItemController ic1 = gameObject.AddComponent<ItemController>();
        ic1.item = item1;
        ic1.sprite = sprites[1];
        allItens.Add(ic1);

        // Item
        Item item2 = new Item("Scraps", "Scraps Scraps", ItemType.MISCELLANEOUS);
        ItemController ic2 = gameObject.AddComponent<ItemController>();
        ic2.item = item2;
        ic2.sprite = sprites[2];
        allItens.Add(ic2);

        SortAllItens();
    }
        
    /**
    * Add all Itens to the list
    */
    public void SortAllItens() {
        sortedItens.Clear();
        foreach (ItemController i in allItens) {
            sortedItens.Add(i);
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
}
