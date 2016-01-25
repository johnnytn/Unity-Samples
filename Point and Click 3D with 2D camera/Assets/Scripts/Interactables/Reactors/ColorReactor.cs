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

    public override void React() {
        //change the color of an color reactor
        mesh.material.color = switcher.state ? active : inactive;
    }

}
