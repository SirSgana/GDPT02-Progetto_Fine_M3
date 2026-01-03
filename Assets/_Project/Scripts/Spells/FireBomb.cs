using UnityEngine;


public class FireBomb : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private Vector3 targetScale = new Vector3(5f, 5f, 1f);
    private bool exploding = false;
    private CircleCollider2D _circleCollider2D;
    private FireballOrbit _fireballOrbit;
    private LifeController _lifeController;


    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _fireballOrbit = GetComponent<FireballOrbit>();
        _lifeController = GetComponent<LifeController>();
    }

    private void Update()
    {
        if (!exploding) return;

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploding) return;

        if (collision.gameObject.TryGetComponent<Enemy>(out var Enemy))
        {
            exploding = true;
            _circleCollider2D.isTrigger = true;
            Destroy(gameObject, 1f);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_lifeController = collision.gameObject.GetComponent<LifeController>())
            {
                _lifeController.TakeDamage(damage);
                if (!_lifeController.IsAlive())
                {
                    Destroy(collision.gameObject, 1f);
                }
            }
        }
    }


}


















//Versione base transizione istantanea
//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.gameObject.TryGetComponent<Enemy>(out var Enemy)) //consente di prendere le funzioni ed il componente Enemy
//    {
//        transform.localScale = new Vector3(5f, 5f, 5f);
//        Destroy(gameObject, 2f);
//    }
//}