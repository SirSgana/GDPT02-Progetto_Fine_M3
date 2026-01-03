using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeLV3 : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;
    private LifeController _life;

    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 1f);
    [SerializeField] private int _atkDamage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _life = GetComponent<LifeController>();
    }

    private void Update()
    {
        CheckHP();
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController playerLife = collision.gameObject.GetComponent<LifeController>();
        if (playerLife != null)
        {
            playerLife.TakeDamage(_atkDamage);
            _life.TakeDamage(_atkDamage);
            _anim.SetBool("IsDead" , true);
            CheckHP();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifeController playerLife = collision.gameObject.GetComponent<LifeController>();
        if (collision.CompareTag("Player"))
        {
            transform.localScale = targetScale;
            playerLife.TakeDamage(_atkDamage);
            _life.TakeDamage(_atkDamage);
            _anim.SetBool("InRange", true);
            Destroy(gameObject, 1f);
        }
    }

    private void CheckHP()
    {
        if (!_life.IsAlive())
        {
            Destroy(gameObject, 1f);
        }
    }
}
