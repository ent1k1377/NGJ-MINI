using UnityEngine;

[RequireComponent(typeof(JumpFXLVL1))]
public class PlayerJumpLVL1 : MonoBehaviour
{
    [SerializeField] private JumpFXLVL1 _jumpFX;
    [SerializeField] [Range(0, 5)] private float _duration;

    private void Awake()
    {
        _jumpFX = GetComponent<JumpFXLVL1>();
    }

    public void Jump()
    {
        _jumpFX.PlayAnimation(transform, _duration);
    }
}
