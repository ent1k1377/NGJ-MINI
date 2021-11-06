using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private bool _isLoading;

    private static SceneTransition _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Restart()
    {
        if (!_isLoading)
            StartCoroutine(LoadSceneRoutine(SceneManager.GetActiveScene().name));
    }

    public void LoadScene(string sceneName)
    {
        if (!_isLoading)
            StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        _isLoading = true;

        bool waitFading = true;
        FaderLVL1.Instance.FadeIn(() => waitFading = false);

        while (waitFading)
            yield return null;

        var async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
            yield return null;

        async.allowSceneActivation = true;

        waitFading = true;
        FaderLVL1.Instance.FadeOut(() => waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        _isLoading = false;
    }
}
