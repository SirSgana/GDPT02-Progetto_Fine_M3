using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _mousePos;
    private float _timer;
    private Animator _anim;
    public GameObject Bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;

    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _anim = GetComponentInParent<Animator>();
    }


    void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = _mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
        if(!canFire)
        {
            _timer += Time.deltaTime;
            if(_timer > timeBetweenFiring)
            {
                canFire = true;
                _timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            _anim.SetBool("IsAttacking", true);
            canFire = false;
            Instantiate(Bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    public void FinishAttack()
    {
        _anim.SetBool("IsAttacking", false);
    }
}
