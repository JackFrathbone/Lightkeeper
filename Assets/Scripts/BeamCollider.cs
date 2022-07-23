using UnityEngine;

public class BeamCollider : MonoBehaviour
{
    [Header("Settings")]
    private Rigidbody _targetBoat;

    private void FixedUpdate()
    {
        if (_targetBoat != null)
        {
            Vector3 dir = (transform.position - _targetBoat.transform.position).normalized;
            dir = new Vector3(0f, 0f, dir.z);
            _targetBoat.AddForce(-dir * 15f, ForceMode.Force);
            //_targetBoat.AddExplosionForce(100f, transform.position, 100f, 0f, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat")
        {
            _targetBoat = other.gameObject.GetComponent<Rigidbody>();

            if (_targetBoat.GetComponent<BoatController>() != null)
            {
                _targetBoat.GetComponent<BoatController>().EnableExclamation();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boat")
        {
            if (_targetBoat.GetComponent<BoatController>() != null)
            {
                _targetBoat.GetComponent<BoatController>().DisableExclamation();
            }

            _targetBoat = null;
        }
    }
}
