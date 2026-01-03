using UnityEngine;

public class BulletHero : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float force;
    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;

    private LifeController _lifeController;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 direction = _mousePos - transform.position;
        
        Vector3 rotation = transform.position - _mousePos;
        
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, rot -90);

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    

















    //private Rigidbody2D _rb;
    //private Vector2 directionBullet;
    //[SerializeField] float moveSpeed = 5f;

    //private void Awake()
    //{
    //    _rb = GetComponent<Rigidbody2D>();
    //}

    //private void Start()
    //{
    //    Destroy(gameObject, 5f);
    //}

    //private void Update()
    //{
    //    _rb.MovePosition(_rb.position + directionBullet * (moveSpeed * Time.fixedDeltaTime));
    //}

    //public void SetUpDirection(Vector2 direction)
    //{
    //    directionBullet = direction;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.TryGetComponent<Enemy>(out var Enemy)) //consente di prendere le funzioni ed il componente Enemy
    //    {
    //        Destroy(gameObject);
    //    }
    //    Destroy(gameObject);
    //}
}
