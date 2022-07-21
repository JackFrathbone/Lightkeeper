using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int _maxBoatsSpawned;
    private int _boatsSpawned;

    [Header("References")]
    [SerializeField] GameObject _boatPrefab;
    [SerializeField] List<GameObject> _Routes = new List<GameObject>();

    private float _timer;
    private float _timerTarget;

    private void Start()
    {
        _timerTarget = 5f;
    }

    private void Update()
    {
        _timer += 1 * Time.deltaTime;

        if(_timer > _timerTarget)
        {
            SetTimerTarget();
            SpawnBoat();
        }
    }

    private void SetTimerTarget()
    {
        _timer = 0;
        _timerTarget = Random.Range(10f, 30f);
    }

    private void SpawnBoat()
    {
        if(_boatsSpawned < _maxBoatsSpawned)
        {
            BoatController boatController = Instantiate(_boatPrefab, transform.position, Quaternion.identity, transform).GetComponent<BoatController>();
            boatController.SetRoute(_Routes[Random.Range(0, _Routes.Count)], this);
            _boatsSpawned++;
        }
        else
        {
            return;
        }
    }

    public void RemoveBoat()
    {
        _boatsSpawned--;
    }
}
