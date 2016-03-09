using UnityEngine;
using System.Collections;

public class PathReactor : StateReactor {

	//public Receiver receiver;
	public GameObject path;

	protected override void Awake() {
		base.Awake();
		React();
	}
	
	/**
    * Active/deactive light
    */
	public override void React() {		
		path.SetActive(switcher.state);
	}
}
