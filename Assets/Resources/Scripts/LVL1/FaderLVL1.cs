using System;
using UnityEngine;
using UnityEngine.Events;

public class FaderLVL1 : MonoBehaviour
{
    [SerializeField] static private GameObject _fadedCanvas;
    
    private Animator _animator;
    private bool _faded;

    private static FaderLVL1 _instance;
    private event UnityAction _fadedInCallback;
    private event UnityAction _fadedOutCallback;

    public static FaderLVL1 Instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<FaderLVL1>("Prefabs/Fader");
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    public bool IsFading { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeIn(UnityAction fadedInCallback)
    {
        if (!IsFading)
        {
            IsFading = true;
            _fadedInCallback = fadedInCallback;

            _faded = true;
            _animator.SetBool(nameof(_faded), _faded);
        }
    }

    public void FadeOut(UnityAction fadedCallback)
    {
        if (!IsFading)
        {
            IsFading = true;
            _fadedOutCallback = fadedCallback;

            _faded = false;
            _animator.SetBool(nameof(_faded), _faded);
        }
    }

    private void HandleFadeInAnimationOver()
    {
        _fadedInCallback?.Invoke();
        _fadedInCallback = null;
        IsFading = false;
    }

    private void HandleFadeOutAnimationOver()
    {
        _fadedOutCallback?.Invoke();
        _fadedOutCallback = null;
        IsFading = false;
    }
}
