using UnityEngine;

public class Cargo : MonoBehaviour
{
    [Header("References")]
    private ChecklistManager _checklistManager;

    private void Start()
    {
        _checklistManager = GameObject.FindGameObjectWithTag("GameControlle").GetComponent<ChecklistManager>();
    }

    private void OnMouseDown()
    {
        _checklistManager.CollectCargo();
        Destroy(gameObject);
    }
}
