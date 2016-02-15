using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    [HideInInspector]
    public Node currentNote;
    public Node startingNode;

	public Player player;
    public List<Item> itensHeld = null;
    public InventoryDisplay invDisp;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;

    void Awake() {
        gm = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    void Start() {
        startingNode.Arrive();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1) && currentNote.GetComponent<Prop>() != null) {
            if (ivCanvas.gameObject.activeInHierarchy) {
                ivCanvas.Close();
                return;
            }
            if (obsCamera.gameObject.activeInHierarchy) {
                obsCamera.Close();
                return;
            }
            currentNote.GetComponent<Prop>().loc.Arrive();
        }
    }
}
