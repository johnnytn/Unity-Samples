using UnityEngine;
using System.Collections;

public class Prop : Node {

    public Location loc;
    Interactables inter;

    // Object material variables
    MeshRenderer childMesh;
    Color previousColor;
    public Material outlinedMaterial;
    //Material previousMaterial;

    // Cursor variables
    //public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start() {
        inter = GetComponent<Interactables>();
        childMesh = this.GetComponentInChildren<MeshRenderer>();
    }

    void OnMouseEnter() {
        changeMouseIcon();
        //changeMaterial();
    }

    void OnMouseExit() {
        // Remove the cursor icon
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        // Restore the last material
        // childMesh.material = previousMaterial;
    }

    private void changeMouseIcon() {
        if (inter.enabled) {
            // Change the cursor icon
            Cursor.SetCursor(GameManager.gm.interactCursor, hotSpot, cursorMode);
        } else {
            Cursor.SetCursor(GameManager.gm.moveCursor, hotSpot, cursorMode);
        }
    }

    /** 
    * Arrive in the node
    */
    public override void Arrive() {
        if (inter != null && inter.enabled) {
            inter.Interact();
            return;
        }
        base.Arrive();

        // Make this object interactable if prerequisite is met
        if (inter != null) {
            Prerequisite pre = GetComponent<Prerequisite>();
            if (pre && !inter.inspectObject && !pre.Complete) {
                return;
            }

            col.enabled = true;
            inter.enabled = true;
            changeMouseIcon();
        }
    }

    /** 
    * Leave the node
    */
    public override void Leave() {
        base.Leave();
        if (inter != null) {
            inter.enabled = false;
        }
    }

    /** 
    * Change the prop material
    */
    private void changeMaterial() {
        childMesh = this.GetComponentInChildren<MeshRenderer>();
        previousColor = childMesh.material.color;
        //previousMaterial = childMesh.material;

        childMesh.material = outlinedMaterial;
        childMesh.material.color = previousColor;
    }

}
