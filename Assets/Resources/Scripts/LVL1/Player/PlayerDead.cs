using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerDead : MonoBehaviour
{
    [SerializeField] private Canvas _canvasAfterLosing;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private Animator _animator;
    private bool _isDead;

    public PlayerCollisionLVL1 _playerCollision;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnPlayerDied()
    {

        //Sequence sequence = DOTween.Sequence();
        //sequence.Append(transform.DOMove((Vector2)transform.position - new Vector2(1, -5), 1f)).OnComplete(() => 
        //{ _rigidbody.velocity = new Vector2(0, 0); });
        //_collider.isTrigger = true;
        _isDead = true;
        _animator.SetBool(nameof(_isDead), _isDead);
        _canvasAfterLosing.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _playerCollision.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerCollision.PlayerDied -= OnPlayerDied;
    }
}
