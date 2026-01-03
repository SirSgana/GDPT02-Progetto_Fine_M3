using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script creato per far comunicare la funzione FinishAttack con l'Animator che è suo Padre.
//Altrimenti non comunicano nonostante il GetComponentInParent.
public class AnimEventReceiver : MonoBehaviour
{
    public Gun gun;

    public void FinishAttack()
    {
        gun.FinishAttack();
    }
}
