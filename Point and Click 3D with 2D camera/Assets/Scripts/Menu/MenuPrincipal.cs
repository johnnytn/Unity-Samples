using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuPrincipal : Menu {

    public Canvas quitMenu;
    public Button newGameButton;
    public Button continueButton;
    public Button exitButton;

    void Awake() {
        if (continueButton != null) {
            continueButton.gameObject.SetActive(JsonPersistence.saveFileExists());
        }
    }

    // Use this for initialization
    void Start() {
        quitMenu.enabled = false;
    }

    /** 
    * Open quit menu
    */
    public void QuitMenu() {
        quitMenu.enabled = true;
        newGameButton.enabled = false;
        exitButton.enabled = false;
    }

    /** 
    * Close quit menu
    */
    public void CloseQuitMenu() {
        quitMenu.enabled = false;
        newGameButton.enabled = true;
        exitButton.enabled = true;
    }

    /** 
    * Exit the game
    */
    public override void Exit() {
        Application.Quit();
    }

}
