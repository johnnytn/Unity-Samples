using UnityEngine;
using System.Collections.Generic;

public class GameDB : MonoBehaviour {

    public static List<ItemController> itemList = new List<ItemController>();
    public Sprite[] sprites;

    // Use this for initialization
    void Awake() {
        // Item
        Item item = new Item("Sword", "sharp weapon", ItemType.EQUIPMENT);
        ItemController ic = new ItemController();
        ic.item = item;
        ic.sprite = sprites[0];
        itemList.Add(ic);

        // Item
        Item item1 = new Item("Health Potion", "Heal your wounds", ItemType.CONSUMABLE);
        ItemController ic1 = new ItemController();
        ic1.item = item1;
        ic1.sprite = sprites[1];
        itemList.Add(ic1);

        // Item
        Item item2 = new Item("Scraps", "Scraps Scraps", ItemType.MISCELLANEOUS);
        ItemController ic2 = new ItemController();
        ic2.item = item2;
        ic2.sprite = sprites[2];
        itemList.Add(ic2);
    }

    // Update is called once per frame
    void Update() {

    }
}
