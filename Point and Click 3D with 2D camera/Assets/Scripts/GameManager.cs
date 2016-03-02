using UnityEngine;
using System.Collections.Generic;

public class GameManager : Util {

    public static GameManager gm = null;

    [HideInInspector]
    public Node currentNote;
    public Node startingNode;

    public Player player;
    public InventoryDisplay invDisp;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public Loading load;
    public InventoryController invControl;
    public GameObject settings;
   
    // Cursor Icon
    public Texture2D interactCursor;
    public Texture2D moveCursor;
    

    void Awake() {
        PrepareGameManager();
    }

    void Start() {
        startingNode.Arrive();
    }

    // Update is called once per frame
    void Update() {
        CloseInspectors();
    }

    void OnLevelWasLoaded(int level) {
        getStartingLocation();
        getPlayer();
        startingNode.Arrive();
        Debug.Log("preparando");
    }

    /**
    * Close UI elements used to inspect objects
    */
    private void CloseInspectors() {
        if (Input.GetMouseButtonDown(1) && currentNote != null && currentNote.GetComponent<Prop>() != null) {
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

    /**
    * Prepare GM before the game starts
    */
    public void PrepareGameManager() {
        if (gm == null) {
            gm = this;
        } else if (gm != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        getStartingLocation();
        getPlayer();
        invControl.PrepareInventory();        
    }

    public void ActiveDeactiveGameObjects(bool active) {
        ivCanvas.gameObject.SetActive(active);
        obsCamera.gameObject.SetActive(active);
        invDisp.gameObject.SetActive(active);
        invControl.gameObject.SetActive(active);

    }

}
