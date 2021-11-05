using UnityEngine;

public class PlayerJumpLVL1 : MonoBehaviour
{
    [SerializeField] private JumpFX _jumpFX;
    [SerializeField] [Range(0, 1)] private float _duration;

    public void Jump()
    {
        _jumpFX.PlayAnimation(transform, _duration);
    }
}
