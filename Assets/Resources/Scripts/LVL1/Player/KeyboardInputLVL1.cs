using UnityEngine;

[RequireComponent(typeof(PlayerJumpLVL1), typeof(PlayerMovementLVL1))]
public class KeyboardInputLVL1 : MonoBehaviour
{
    [SerializeField] private PlayerJumpLVL1 _playerJump;
    [SerializeField] private PlayerMovementLVL1 _playerMovement;

    private void Awake()
    {
        _playerJump = GetComponent<PlayerJumpLVL1>();
        _playerMovement = GetComponent<PlayerMovementLVL1>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameOptions.Key))
            _playerJump.Jump();

        _playerMovement.Run(Vector2.right);
    }
}
