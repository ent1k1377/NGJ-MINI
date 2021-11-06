using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionLVL1 : MonoBehaviour
{
    public event UnityAction PlayerDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyLVL1 _enemy))
            PlayerDied?.Invoke();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyLVL1 _enemy))
            PlayerDied?.Invoke();
    }
}
