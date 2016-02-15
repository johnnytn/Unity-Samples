using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    public Slider loadingBar;
    public GameObject loadingImage;
    private AsyncOperation async;

    //  Load a scene 
    public void LoadingScene(int level) {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(level));
    }

    // Load a scene displaying a loading bar
    IEnumerator LoadLevelWithBar(int level) {
        async = SceneManager.LoadSceneAsync(level);

        while (!async.isDone) {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
