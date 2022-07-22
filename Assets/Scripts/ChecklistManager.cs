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
    private int _yachtsDestroyed = 0;
    private int _shipsDestroyed = 0;

    [Header("References")]
    [SerializeField] GameObject _strike1;
    [SerializeField] GameObject _strike2;
    [SerializeField] GameObject _strike3;
    [SerializeField] GameObject _strike4;
    [SerializeField] GameObject _strike5;
    [SerializeField] GameObject _strike6;

    [SerializeField] Dialogue _dialogue1;
    [SerializeField] Dialogue _dialogue2;
    [SerializeField] Dialogue _dialogue3;
    [SerializeField] Dialogue _dialogue4;
    [SerializeField] Dialogue _dialogue5;
    [SerializeField] Dialogue _dialogue6;
    [SerializeField] Dialogue _dialogueEnd;

    [SerializeField] DialogueManager _dialogueManager;

    public void BoatCollision()
    {
        _boatCollisions++;

        if (_boatCollisions >= 4 && !_list1)
        {
            _list1 = true;

            if (CheckFinish())
            {
                return;
            }

            _dialogueManager.RunDialogue(_dialogue1);
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

        if (_tentacle1Touched && _tentacle2Touched && !_list2)
        {
            _list2 = true;

            if (CheckFinish())
            {
                return;
            }

            _dialogueManager.RunDialogue(_dialogue2);
            _strike2.SetActive(true);
        }
    }
    public void CollectCargo()
    {
        _cargoCollected++;

        if (_cargoCollected >= 5 && !_list3)
        {
            _list3 = true;

            if (CheckFinish())
            {
                return;
            }

            _dialogueManager.RunDialogue(_dialogue3);
            _strike3.SetActive(true);
        }
    }

    public void CrashYacht()
    {
        _yachtsDestroyed++;

        if (_yachtsDestroyed >= 3 && !_list4)
        {
            _list4 = true;

            if (CheckFinish())
            {
                return;
            }

            _dialogueManager.RunDialogue(_dialogue4);
            _strike4.SetActive(true);
        }
    }

    public void CrashedShip()
    {
        _shipsDestroyed++;

        if (_shipsDestroyed >= 10 && !_list6)
        {
            _list6 = true;

            if (CheckFinish())
            {
                return;
            }

            _dialogueManager.RunDialogue(_dialogue6);
            _strike6.SetActive(true);
        }
    }


    private bool CheckFinish()
    {
        if (_list1 && _list2 && _list3 && _list4 && _list6)
        {
            _dialogueManager.RunDialogue(_dialogueEnd);

            return true;
        }

        return false;
    }
}
