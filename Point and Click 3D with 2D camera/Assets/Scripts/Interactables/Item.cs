using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

    // TODO find a way to generate the id automatic
    public int id;
    public string name;
    public string description;
    public ItemType type;
    public int amount;
    public int spritePos;
    public int[] coords;

    public Item() {

    }

    /**
    * Constructor
    */
    public Item(int id, string name, string description, ItemType type, int amount, int spritePos, int[] coords) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.amount = amount;
        this.spritePos = spritePos;
        this.coords = coords;
    }

    public override bool Equals(object obj) {
        Item item = (Item)obj;
        return this.id == item.id && this.name == item.name;
    }

}
