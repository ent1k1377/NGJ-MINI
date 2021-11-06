using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private Canvas _canvasAfterLosing;

    public PlayerCollisionLVL1 _playerCollision;

    private void OnPlayerDied()
    {
        _canvasAfterLosing.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _playerCollision.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerCollision.PlayerDied -= OnPlayerDied;
    }
}
