using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Prop))]
public abstract class Interactables : MonoBehaviour {

    public bool inspectObject;
    public string message;
    [HideInInspector]
    public bool interact;

    // Use this for initialization
    void Start() {
        this.enabled = false;
    }

    /**
    *Deafult object interaction
    */
    public virtual void Interact() {
        Prerequisite pre = GetComponent<Prerequisite>();
        if (pre && !pre.Complete) {
            Debug.Log(message);
            interact = false;
            return;
        }
        interact = true;
    }

}
