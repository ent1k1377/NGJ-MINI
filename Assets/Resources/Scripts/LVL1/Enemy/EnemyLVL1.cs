using UnityEngine;
using UnityEngine.Events;

public class EnemyLVL1 : MonoBehaviour
{
    [SerializeField] private PlayerDead _playerDead;

    public event UnityAction PlayerDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerLVL1 _player))
            PlayerDied?.Invoke();
    }
}
