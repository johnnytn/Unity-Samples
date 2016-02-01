using UnityEngine;
using System.Collections;

public class Prop : Node {

    public Location loc;

    Interactables inter;

	MeshRenderer childMesh;

	Color previousColor;

	public Material outlinedMaterial;

	Material previousMaterial;

    void Start() {
        inter = GetComponent<Interactables>();
		childMesh = this.GetComponentInChildren<MeshRenderer>();
    }

	void OnMouseEnter(){	
		changeMaterial();
	}

	void OnMouseExit(){		
		childMesh.material = previousMaterial;
	}

	private void changeMaterial(){
		childMesh = this.GetComponentInChildren<MeshRenderer>();
		previousColor = childMesh.material.color;
		previousMaterial = childMesh.material;

		childMesh.material = outlinedMaterial;
		childMesh.material.color = previousColor;
	}


    public override void Arrive() {
        if (inter != null && inter.enabled) {
            inter.Interact();
            return;
        }
                base.Arrive();

        // make this object interactable if prerequisite os met
        if (inter != null) {
            Prerequisite pre = GetComponent<Prerequisite>();
            if (pre && !pre.Complete) {
                return;
            }
            col.enabled = true;
            inter.enabled = true;
        }
    }

    public override void Leave() {
        base.Leave();
        if (inter != null) {
            inter.enabled = false;
        }
    }
}
