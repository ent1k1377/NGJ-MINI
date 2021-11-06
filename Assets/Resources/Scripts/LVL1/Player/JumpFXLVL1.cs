using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpFXLVL1 : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private PlayerGroundCollisionLVL1 _playerGroundCollision;

    private Coroutine _coroutineJump;
    private bool _isGround = false;

    private float _timeIntervalBetweenJump = 0.1f;
    private float _timePassed;

    private float _minTimeJump = 0.3f;
    private float _currentTimeJump;

    private Animator _animator;
    private bool _isRun;
    private bool _isJumpUp;
    private bool _isJumpDown;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _timePassed = _timeIntervalBetweenJump;
    }

    private void Update()
    {
        if (_isGround)
        {
            SetParametrsAnimator(isRun: true);
            _timePassed += Time.deltaTime;
        }
        else
            _currentTimeJump += Time.deltaTime;
    }

    public void PlayAnimation(Transform jumper, float duration)
    {
        if (_isGround && _timePassed >= _timeIntervalBetweenJump && _coroutineJump == null)
            _coroutineJump = StartCoroutine(AnimationByTime(jumper, duration));
    }

    public void StopCoroutine()
    {
        if (_coroutineJump != null && _currentTimeJump > _minTimeJump)
        {
            StopCoroutine(_coroutineJump);
            _coroutineJump = null;
            SetParametrsAnimator(isJumpUp:true);
        }
    }

    private void SetParametrsAnimator(bool isRun = false, bool isJumpUp = false, bool isJumpDown = false)
    {
        _animator.SetBool(nameof(_isRun), isRun);
        _animator.SetBool(nameof(_isJumpUp), isJumpUp);
        _animator.SetBool(nameof(_isJumpDown), isJumpDown);
    }

    private IEnumerator AnimationByTime(Transform jumper, float duration)
    {
        SetParametrsAnimator(isJumpUp: true);

        float expiredSeconds = 0f;
        float progress = 0f;

        Vector2 startPosition = jumper.position;
        float jumperPositionY = jumper.position.y;

        while (progress < 1)
        {
            if (_isGround && jumper.position.y > jumperPositionY)
            {
                SetParametrsAnimator(isRun:true);
                yield break;
            }

            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            jumper.position = new Vector2(jumper.position.x, startPosition.y + _yAnimation.Evaluate(progress));

            if (!_isGround && jumper.position.y < jumperPositionY)
            {
                SetParametrsAnimator(isJumpUp:true);
            }
            else if (!_isGround && jumper.position.y > jumperPositionY)
            {
                SetParametrsAnimator(isJumpDown: true);
            }

            jumperPositionY = jumper.position.y;
     
            yield return null;
        }
        SetParametrsAnimator(isRun: true);
    }

    private void OnGroundCollided(bool isGround)
    {
        _isGround = isGround;

        if (!_isGround)
            _timePassed = 0f;
        else
            _currentTimeJump = 0f;
    }

    private void OnEnable()
    {
        _playerGroundCollision.GroundCollided += OnGroundCollided;
    }

    private void OnDisable()
    {
        _playerGroundCollision.GroundCollided -= OnGroundCollided;
    }
}
