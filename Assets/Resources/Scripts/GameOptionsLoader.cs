using UnityEngine;

public class GameOptionsLoader : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    private void Awake()
    {
        GameOptions.Key = _key;
    }
}
