using UnityEngine;

public class Cargo : MonoBehaviour
{
    [Header("References")]
    private ChecklistManager _checklistManager;

    private void Start()
    {
        _checklistManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChecklistManager>();
        Destroy(gameObject, 5f);
    }

    private void OnMouseDown()
    {
        _checklistManager.CollectCargo();
        Destroy(gameObject);
    }
}
