using UnityEngine;

public class LighthouseController : MonoBehaviour
{
    [Header("References")]
    private Light _light;

    [Header("Settings")]
    private bool _active;
    private Rigidbody _targetBoat;

    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        ToggleLighthouse(true);
    }

    private void FixedUpdate()
    {
        if(_targetBoat != null && _active)
        {
            Vector3 dir = (transform.position - _targetBoat.transform.position).normalized;
            dir = new Vector3(0f, 0f, dir.z);
            _targetBoat.AddForce(-dir * 5f, ForceMode.Force);
            //_targetBoat.AddExplosionForce(25f, transform.position, 100f, 0f ,ForceMode.Acceleration);
        }
    }

    private void OnMouseDown()
    {

        if (_active)
        {
            ToggleLighthouse(false);
        }
        else
        {
            ToggleLighthouse(true);
        }
    }

    private void ToggleLighthouse(bool lightToggle)
    {
        _active = lightToggle;
        _light.enabled = lightToggle;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Boat")
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
