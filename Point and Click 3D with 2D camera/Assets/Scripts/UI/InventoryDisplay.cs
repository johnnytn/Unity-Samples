using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    Text displayText;

    void Start() {
        displayText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay() {
        List<Item> itens = GameManager.gm.player.itensHeld;
        string displayName = (itens != null && itens.Count > 0) ? itens[itens.Count - 1].name : "none";
                displayText.text = "Item Held: " + displayName;
    }

}
