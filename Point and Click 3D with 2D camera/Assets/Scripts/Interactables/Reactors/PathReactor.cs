using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PathReactor : StateReactor {

    //public Receiver receiver;
    public GameObject path;

    protected override void Awake() {
        base.Awake();
        React();
        //StartCoroutine(DelayedReact());
    }

    /**
    * Active/deactive a path
    */
    public override void React() {
        BoxCollider collider = this.GetComponent<BoxCollider>();
        collider.enabled = switcher.state;
        path.SetActive(switcher.state);
    }

    IEnumerator DelayedReact() {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1f);
        React();
    }
}
