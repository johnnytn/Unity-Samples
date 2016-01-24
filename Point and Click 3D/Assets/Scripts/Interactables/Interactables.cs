using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Prop))]
public abstract class Interactables : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.enabled = false;
	}

    // Deafult object interaction
    public virtual void Interact() {
        Debug.Log("interacting with" + name);
    }
	
}
