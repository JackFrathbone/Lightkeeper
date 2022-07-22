using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _beam;
    private Camera _cam;

    [Header("Data")]
    private bool _mouseDown;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (_mouseDown)
        {
            var pos = _cam.WorldToScreenPoint(_beam.gameObject.transform.position);
            var dir = (Input.mousePosition - pos);
            var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
            _beam.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _beam.transform.localEulerAngles = new Vector3(90f, 180f, _beam.transform.localEulerAngles.z);
        }
    }
    private void OnMouseDown()
    {
        _mouseDown = true;
    }

    private void OnMouseUp()
    {
        _mouseDown = false;
    }
}
