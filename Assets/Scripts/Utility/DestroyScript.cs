using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _timeToDestroy;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
