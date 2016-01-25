using UnityEngine;
using System.Collections;

public abstract class StateReactor : MonoBehaviour {

    public Switcher switcher;

    protected virtual void Awake() {
        switcher.Change += React;
    }

    public virtual void React() {
        Debug.Log("Reacting");
    }
}
