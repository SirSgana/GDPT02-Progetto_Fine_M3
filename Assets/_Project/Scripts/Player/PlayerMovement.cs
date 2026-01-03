using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private LifeController _life;
    private Animator _anim;
    public Vector2 Direction { get; private set; }


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _life = GetComponent<LifeController>();
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        CheckHP();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Direction * (moveSpeed * Time.fixedDeltaTime));
    }

    private void CheckHP()
    {
        if(!_life.IsAlive())
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _anim.SetBool("IsDead", true);
            Invoke(nameof(ReloadScene), 1.2f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
