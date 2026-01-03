using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimParamHandler : MonoBehaviour
{
    private Animator _anim;
    private PlayerMovement _movement;


    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        AnimationMove();
    }

    private void AnimationMove()
    {
        Vector2 movement = _movement.Direction;

        if (movement != Vector2.zero)
        {
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("MoveX", movement.x);
            _anim.SetFloat("MoveY", movement.y);
        }
        else { _anim.SetBool("IsMoving", false); }
    }

    public void SetLevel2(bool value)
    {
        _anim.SetBool("Level2", value);
    }
    public void SetLevel3(bool value)
    {
        _anim.SetBool("Level3", value);
    }
}
