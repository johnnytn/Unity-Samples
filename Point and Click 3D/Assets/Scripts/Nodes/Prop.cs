using UnityEngine;
using System.Collections;

public class Prop : Node {

    public Location loc;

    Interactables inter;

    void Start() {
        inter = GetComponent<Interactables>();
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
