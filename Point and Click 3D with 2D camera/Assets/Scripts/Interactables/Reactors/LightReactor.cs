using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class LightReactor : StateReactor {

	public Color active;
	public Color inactive;
	Light light;

    protected override void Awake() {
        base.Awake();
        light = GetComponent<Light>();
        React();
    }

    public override void React() {
        //active/deactive light
		light.enabled = switcher.state;
		light.color = switcher.state ? active : inactive;
    }

}
