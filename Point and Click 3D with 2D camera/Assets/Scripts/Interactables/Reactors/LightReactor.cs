using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightReactor : StateReactor {

    public bool activeLight;
    public Color active;
    public Color inactive;
    Light lightScource;

    protected override void Awake() {
        base.Awake();
        lightScource = GetComponent<Light>();
        React();
    }

    /**
    * Active/deactive light
    */
    public override void React() {
        lightScource.enabled = activeLight ? activeLight : switcher.state;
        lightScource.color = switcher.state ? active : inactive;
    }

}
