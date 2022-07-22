using UnityEngine;

public class SeaMine : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boat")
        {
            Destroy(gameObject);
        }
    }
}
