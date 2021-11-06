using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderExample : MonoBehaviour
{
    [SerializeField] private string _nameScene;

    private bool _isLoading;

    private static FaderExample _instance;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (!_isLoading)
            StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        _isLoading = true;

        bool waitFading = true;
        FaderLVL1.Instance.FadeIn(() => waitFading = false);

        while (waitFading)
            yield return null;

        var async = SceneManager.LoadSceneAsync(_nameScene);
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
