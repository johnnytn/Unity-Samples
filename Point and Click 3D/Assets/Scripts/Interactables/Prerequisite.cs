using UnityEngine;
using System.Collections;

public class Prerequisite : MonoBehaviour {

    public Switcher watchSwitcher;
    public bool nodeAcess;

    public bool Complete {
        get { return watchSwitcher.state; }
    }

}
