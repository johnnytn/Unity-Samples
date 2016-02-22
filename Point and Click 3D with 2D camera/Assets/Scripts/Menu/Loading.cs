using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    public GameObject loadingImage;
    private Slider loadingBar;
    private AsyncOperation async;

    void Awake() {
        if (loadingImage != null) {
            loadingBar = loadingImage.GetComponentInChildren<Slider>();
        }
    }

    /**
    * Load a Scene
    */
    public void LoadingScene(int level) {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(level));
    }

    /**
    * Load a Scene displaying a loading bar
    */
    IEnumerator LoadLevelWithBar(int level) {
        async = SceneManager.LoadSceneAsync(level);

        while (!async.isDone) {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
