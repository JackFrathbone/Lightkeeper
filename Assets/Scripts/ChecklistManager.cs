using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    [Header("Bool")]
    private bool _list1;
    private bool _list2;
    private bool _list3;
    private bool _list4;
    private bool _list5;
    private bool _list6;

    [Header("Data")]
    private int _cargoCollected = 0;

    [Header("References")]
    [SerializeField] GameObject _strike1;
    [SerializeField] GameObject _strike2;
    [SerializeField] GameObject _strike3;
    [SerializeField] GameObject _strike4;
    [SerializeField] GameObject _strike5;
    [SerializeField] GameObject _strike6;

    public void CollectCargo()
    {
        _cargoCollected++;

        if(_cargoCollected >= 5)
        {
            _list3 = true;
            _strike3.SetActive(true);
        }
    }
}
