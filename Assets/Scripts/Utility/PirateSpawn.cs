using System.Collections.Generic;
using UnityEngine;

public class PirateSpawn : MonoBehaviour
{
    [SerializeField] GameObject _cargoPrefab;

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            Instantiate(_cargoPrefab, transform.position, Quaternion.identity);
        }
        else //Was Cleaned Up on Scene Closure
        {
            return;
        }
    }
}