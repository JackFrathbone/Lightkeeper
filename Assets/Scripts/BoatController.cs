using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [Header("References")]
    private List<Transform> _travelPoints = new List<Transform>();
    private int _currentTravelPoint;
    private BoatSpawner boatSpawner;

    private Rigidbody _boatRB;

    [Header("Settings")]
    [SerializeField] float _speed;
    [SerializeField] float _maxVelocity;
    private bool _moving;
    private bool _setDirection;
    private bool _startWest;

    private void Start()
    {
        _boatRB = GetComponent<Rigidbody>();
    }

    public void SetRoute(GameObject route, BoatSpawner parentRef)
    {
        boatSpawner = parentRef;

        int randomBool = Random.Range(0, 2);

        if(randomBool == 0)
        {
            _startWest = true;
        }
        else
        {
            _startWest = false;
        }

        foreach(Transform child in route.transform)
        {
            _travelPoints.Add(child);
        }

        //Reverse list if started in the east
        if (!_startWest)
        {
            _travelPoints.Reverse();
        }

        transform.position = _travelPoints[0].position;
        _currentTravelPoint = 0;

        _moving = true;
    }

    private void FixedUpdate()
    {
        if (!_moving)
        {
            return;
        }

        if (_moving && !_setDirection)
        {
            Vector3 direction = _travelPoints[_currentTravelPoint].position - _boatRB.position;
            direction /= Time.fixedDeltaTime;
            direction = Vector3.ClampMagnitude(direction, _speed);
            _boatRB.velocity = direction;

            _setDirection = true;
        }

        else if(_moving && _setDirection)
        {
            if (_startWest)
            {
                if (this.transform.position.x >= _travelPoints[_currentTravelPoint].position.x)
                {
                    if (_currentTravelPoint + 1 < _travelPoints.Count)
                    {
                        _currentTravelPoint++;
                        _setDirection = false;
                    }
                    else
                    {
                        _moving = false;
                        boatSpawner.RemoveBoat();
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                if (this.transform.position.x <= _travelPoints[_currentTravelPoint].position.x)
                {
                    if (_currentTravelPoint + 1 < _travelPoints.Count)
                    {
                        _currentTravelPoint++;
                        _setDirection = false;
                    }
                    else
                    {
                        _moving = false;
                        boatSpawner.RemoveBoat();
                        Destroy(gameObject);
                    }
                }
            }
    
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            boatSpawner.RemoveBoat();
            Destroy(gameObject);
        }
    }
}
