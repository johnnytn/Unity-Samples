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
    // Cursor Icon
    public Texture2D cursorTexture;

    // public List<ItemController> allItens = new List<ItemController>();
    //  public List<ItemController> sortedItens = new List<ItemController>();
    // public Sprite[] sprites;

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

    /**
    * Get Player
    */
    private void getPlayer() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {
            player = obj.GetComponent<Player>();
        }
    }

    /**
    * Get the Starting Node location
    */
    private void getStartingLocation() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Location")) {
            if (obj.GetComponent<Location>().startingNode) {
                startingNode = obj.GetComponent<Location>();
            }
        }
    }
    /**
   * Get the Inventory Display
   */
    private void getInventoryDisplay() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Inventory Display")) {
            invDisp = obj.GetComponent<InventoryDisplay>();
        }
    }

    /**
   * Get the IV Canvas
   */
    private void getIVCanvas() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("IV Canvas")) {
            ivCanvas = obj.GetComponent<IVCanvas>();
        }
    }

    /**
    * Get the Observer Cam
    */
    private void getObserverCam() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Observer Cam")) {
            obsCamera = obj.GetComponent<ObsCamera>();
        }
    }

    /**
    * Get Inventory
    */
    private void getInventory() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Inventory")) {
            invControl = obj.GetComponent<InventoryController>();
        }
    }

    public void ActiveDeactiveGameObjects(bool active) {
        ivCanvas.gameObject.SetActive(active);
        obsCamera.gameObject.SetActive(active);
        invDisp.gameObject.SetActive(active);
        invControl.gameObject.SetActive(active);

    }

}
