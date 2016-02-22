using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Loading load;    

    public Canvas quitMenu;
    public Button startButton;
    public Button exitButton;

    // Use this for initialization
    void Start() {        
        quitMenu = quitMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    /** 
    * Open quit menu
    */
    public void QuitMenu() {
        quitMenu.enabled = true;
        startButton.enabled = false;
        exitButton.enabled = false;
    }

    /** 
    * Close quit menu
    */
    public void CloseQuitMenu() {
        quitMenu.enabled = false;
        startButton.enabled = true;
        exitButton.enabled = true;
    }
        
    /** 
    * Load a level
    */
    public void LoadLevel(int level) {        
        load.LoadingScene(level);
    }

    /** 
    * Exit the game
    */
    public void Exit() {
        Application.Quit();
    }

}
