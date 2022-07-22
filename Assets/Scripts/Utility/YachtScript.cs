using UnityEngine;

public class YachtScript : MonoBehaviour
{
    [Header("References")]
    private ChecklistManager _checklistManager;

    private void Start()
    {
        _checklistManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChecklistManager>();
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            _checklistManager.CrashYacht();
            Destroy(gameObject);
        }
        else //Was Cleaned Up on Scene Closure
        {
            return;
        }
    }
}
