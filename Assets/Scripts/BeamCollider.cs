using UnityEngine;

public class BeamCollider : MonoBehaviour
{
    [Header("Settings")]
    private Rigidbody _targetBoat;

    private void FixedUpdate()
    {
        if (_targetBoat != null)
        {
            _targetBoat.AddExplosionForce(100f, transform.position, 100f, 0f, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat")
        {
            _targetBoat = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boat")
        {
            _targetBoat = null;
        }
    }
}
