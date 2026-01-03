using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLv3 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var _anim = collision.GetComponent<PlayerAnimParamHandler>();
            
            if (_anim != null)
            {
                _anim = collision.GetComponentInParent<PlayerAnimParamHandler>();
                _anim.SetLevel3(true);
            }
            Destroy(gameObject);
        }
    }
}
