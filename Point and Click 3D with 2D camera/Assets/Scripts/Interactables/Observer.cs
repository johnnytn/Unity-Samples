using UnityEngine;
using System.Collections;

public class Observer : Interactables {

    public override void Interact() {
        GameObject item = Instantiate(gameObject);
        item.transform.SetParent(GameManager.gm.obsCamera.rig);
        item.transform.localPosition = Vector3.zero;
        item.transform.GetChild(0).localPosition = Vector3.zero;
        GameManager.gm.obsCamera.model = item.transform;
        GameManager.gm.obsCamera.gameObject.SetActive(true);
    }

}
