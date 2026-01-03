using UnityEngine;

public class PickupFireBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var orbit = collision.GetComponent<FireballOrbit>();
            
            if (orbit != null)
            {
                orbit.AcquireFireball();
                Destroy(gameObject);
            }
        }
    }
}
