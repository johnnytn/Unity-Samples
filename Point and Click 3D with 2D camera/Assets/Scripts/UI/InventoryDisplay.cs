using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public void UpdateDisplay() {
        this.gameObject.SetActive(true);
        List<Item> itens = GameManager.gm.player.itensHeld;
        string displayName = (itens != null && itens.Count > 0) ? itens[itens.Count - 1].name : "none";
        GetComponent<Text>().text = "Obtained: " + displayName;
        StartCoroutine(wait());
    }

     /**
     *  Disable display item name after the 2 seconds
     */
    IEnumerator wait() {        
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

}
