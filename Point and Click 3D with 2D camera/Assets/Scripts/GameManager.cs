using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager gm = null;

    [HideInInspector]
    public Node currentNote;
    public Node startingNode;

    public Player player;    
    public InventoryDisplay invDisp;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    
    // Cursor Icon
    public Texture2D cursorTexture;

    void Awake() {
        if (gm == null) {
            gm = this;
        } else if (gm != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

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
