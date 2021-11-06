using UnityEngine;
using UnityEngine.Events;

public class PlayerGroundCollisionLVL1 : MonoBehaviour
{
    public event UnityAction<bool> GroundCollided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out GroundLVL1 ground))
            GroundCollided?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out GroundLVL1 ground))
            GroundCollided?.Invoke(false);
    }
}
