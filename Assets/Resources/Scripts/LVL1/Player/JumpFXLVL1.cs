using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpFXLVL1 : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private PlayerGroundCollisionLVL1 _playerGroundCollision;

    private bool _isGround = false;

    private Animator _animator;
    private bool _isRun;
    private bool _isJumpUp;
    private bool _isJumpDown;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(Transform jumper, float duration)
    {
        if (_isGround)
            StartCoroutine(AnimationByTime(jumper, duration));
    }

    private IEnumerator AnimationByTime(Transform jumper, float duration)
    {
        _animator.SetBool(nameof(_isRun), false);

        float expiredSeconds = 0f;
        float progress = 0f;

        Vector2 startPosition = jumper.position;
        float jumperPositionY = jumper.position.y;

        while (progress < 1)
        {
            if (_isGround && jumper.position.y > jumperPositionY)
            {
                _animator.SetBool(nameof(_isRun), true);
                _animator.SetBool(nameof(_isJumpUp), false);
                _animator.SetBool(nameof(_isJumpDown), false);
                yield break;
            }

            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            jumper.position = new Vector2(jumper.position.x, startPosition.y + _yAnimation.Evaluate(progress));

            if (!_isGround && jumper.position.y < jumperPositionY)
            {
                _animator.SetBool(nameof(_isJumpUp), true);
                _animator.SetBool(nameof(_isJumpDown), false);
            }
            else if (!_isGround && jumper.position.y > jumperPositionY)
            {
                _animator.SetBool(nameof(_isJumpUp), false);
                _animator.SetBool(nameof(_isJumpDown), true);
            }

            jumperPositionY = jumper.position.y;
     
            yield return null;
        }
        _animator.SetBool(nameof(_isRun), true);
    }

    private void OnGroundCollided(bool isGround)
    {
        _isGround = isGround;
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
