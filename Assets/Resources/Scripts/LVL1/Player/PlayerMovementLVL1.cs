using UnityEngine;

[RequireComponent(typeof(Animator))]
class PlayerMovementLVL1 : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}