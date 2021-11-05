using UnityEngine;

public class KeyboardInputLVL1 : MonoBehaviour
{
    [SerializeField] private PlayerJumpLVL1 _playerJump;
    [SerializeField] private PlayerMovementLVL1 _playerMovement;

    private void Update()
    {
        if (Input.GetKeyDown(GameOptions.Key))
            _playerJump.Jump();

        _playerMovement.Run(Vector2.right);
    }
}
