using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class LightReactor : StateReactor {

    public Color active;
    public Color inactive;
    Light lightScource;

    protected override void Awake() {
        base.Awake();
        lightScource = GetComponent<Light>();
        React();
    }
   
    public override void React() {
        //active/deactive light
        lightScource.enabled = switcher.state;
        lightScource.color = switcher.state ? active : inactive;
    }

}
