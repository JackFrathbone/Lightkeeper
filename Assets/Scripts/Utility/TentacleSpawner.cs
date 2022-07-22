using UnityEngine;

public class TentacleSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _tentacle;
    private GameObject _spawnedTentacle;

    [Header("Data")]
    private bool _tentacleSpawned;
    private float _timer;
    private float _timerGoal;

    private void Start()
    {
        _timerGoal = Random.Range(5f, 15f);
    }

    private void Update()
    {
        _timer += 1 * Time.deltaTime;

        if(_timer > _timerGoal)
        {
            _timer = 0;
            if (_tentacleSpawned)
            {
                _tentacleSpawned = false;
                _spawnedTentacle.GetComponentInChildren<Animator>().SetTrigger("PopDown");
                Destroy(_spawnedTentacle, 1f);
            }
            else
            {
                _tentacleSpawned = true;
                _spawnedTentacle = Instantiate(_tentacle, transform.position, Quaternion.identity);
            }
        }
    }
}
