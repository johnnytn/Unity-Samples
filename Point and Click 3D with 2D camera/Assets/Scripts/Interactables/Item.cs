using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

    public string name;
    public string description;
    public ItemType type;
    public int amount;

    public Item() {

    }

    public Item(string name, string description, ItemType type, int amount) {
        this.name = name;
        this.description = description;
        this.type = type;
        this.amount = amount;
    }
}
