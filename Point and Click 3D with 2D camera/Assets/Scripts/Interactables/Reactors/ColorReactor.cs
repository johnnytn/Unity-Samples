using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ColorReactor : StateReactor {

    public Color active;
    public Color inactive;
    MeshRenderer mesh;

    protected override void Awake() {
        base.Awake();
        mesh = GetComponent<MeshRenderer>();
        React();
    }

    /**
    * Change the color of a reactor
    */
    public override void React() {
        mesh.material.color = switcher.state ? active : inactive;
    }

}
