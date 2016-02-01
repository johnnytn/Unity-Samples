using UnityEngine;
using System.Collections;

public class Collector : Interactables {

	public Item myItem;

	public override void Interact ()
	{
		GameManager.gm.itemHeld = myItem;
	}

}
