using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

    public IEnumerator wait() {
        //Do whatever you need done here before waiting

        yield return new WaitForSeconds(2f);

        //do stuff after the 2 seconds
    }
}
