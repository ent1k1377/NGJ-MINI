using UnityEngine;

[RequireComponent(typeof(PlayerGroundCollisionLVL1))]
public class PlayerGravityLVL1 : MonoBehaviour
{
    [SerializeField] private float _gravity = -10;

    private PlayerGroundCollisionLVL1 _playerCollision;
    private Vector2 velocity;
    private bool _isGround;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerGroundCollisionLVL1>();
    }

    private void Update()
    {
        if (_isGround)
            velocity.y = 0f;

        velocity.y += _gravity;
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnGroundCollided(bool isGround)
    {
        _isGround = isGround;
    }

    private void OnEnable()
    {
        _playerCollision.GroundCollided += OnGroundCollided;
    }

    private void OnDisable()
    {
        _playerCollision.GroundCollided -= OnGroundCollided;
    }
}
