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
    public GameObject inventory;
    // Cursor Icon
    public Texture2D cursorTexture;

   // public List<ItemController> allItens = new List<ItemController>();
  //  public List<ItemController> sortedItens = new List<ItemController>();
   // public Sprite[] sprites;

    void Awake() {
        PrepareGameManager();
        inventory.GetComponent<InventoryController>().PrepareInventory();
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    void Start() {
        startingNode.Arrive();
    }

    // Update is called once per frame
    void Update() {
        CloseInspectors();
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
    private void PrepareGameManager() {
        if (gm == null) {
            gm = this;
        } else if (gm != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
