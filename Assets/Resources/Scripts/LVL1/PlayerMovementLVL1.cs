using UnityEngine;

class PlayerMovementLVL1 : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Run(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}