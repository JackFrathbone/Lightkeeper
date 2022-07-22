using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    [Header("Bool")]
    private bool _list1 = false;
    private bool _list2 = false;
    private bool _list3 = false;
    private bool _list4 = false;
    private bool _list5 = false;
    private bool _list6 = false;

    [Header("Data")]
    private int _cargoCollected = 0;
    private int _boatCollisions = 0;
    private bool _tentacle1Touched = false;
    private bool _tentacle2Touched = false;
    private int _shipsDestroyed = 0;

    [Header("References")]
    [SerializeField] GameObject _strike1;
    [SerializeField] GameObject _strike2;
    [SerializeField] GameObject _strike3;
    [SerializeField] GameObject _strike4;
    [SerializeField] GameObject _strike5;
    [SerializeField] GameObject _strike6;


    public void BoatCollision()
    {
        _boatCollisions++;

        if (_boatCollisions >= 2)
        {
            _list1 = true;
            _strike1.SetActive(true);
        }
    }

    public void TouchTentacle(int i)
    {
        if (i == 1)
        {
            _tentacle1Touched = true;
        }
        else
        {
            _tentacle2Touched = true;
        }

        if(_tentacle1Touched && _tentacle2Touched)
        {
            _list2 = true;
            _strike2.SetActive(true);
        }
    }
    public void CollectCargo()
    {
        _cargoCollected++;

        if (_cargoCollected >= 5)
        {
            _list3 = true;
            _strike3.SetActive(true);
        }
    }

    public void CrashYacht()
    {
        _list4 = true;
        _strike4.SetActive(true);
    }

    public void CrashedShip()
    {
        _shipsDestroyed++;

        if (_shipsDestroyed >= 10)
        {
            _list6 = true;
            _strike6.SetActive(true);
        }
    }
}
