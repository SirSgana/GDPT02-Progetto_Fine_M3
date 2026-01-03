using UnityEngine;

public class FireballOrbit : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;

    [SerializeField] private Vector3 centerOffset = new Vector3(0f, 0.8f, 1f);
    [SerializeField] private float radius = 0f;                 // raggio orbita
    [SerializeField] private float degreesPerSecond = 0f;     // velocità orbita

    [SerializeField] private float shootSpeed = 5f; //forza di esplulsione

    private Transform fireball;
    private float angleDeg;

    private bool isOrbiting = false;
    private Vector2 shootDirection;

    private void Update()
    {
        if (fireball == null) return;

        if (isOrbiting)
        {
            //Input per lo sparo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EjectFireball();      //Funzione per l'espulsione della fireball
            }
            OrbitFireball();           //Funzione per la rotazione attorno al player
        }
        else
        {
            fireball.position += (Vector3)(shootDirection * shootSpeed * Time.deltaTime);
        }

    }


    private void OrbitFireball()
    {
        angleDeg += degreesPerSecond * Time.deltaTime;                                //Avanza l'angolo
        
        Vector3 center = transform.position + centerOffset;                           //Centro sopra il player

        float rad = angleDeg * Mathf.Deg2Rad; 

        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;    //posizione sull'orbita

        fireball.position = center + offset;
    }

    private void EjectFireball()
    {
        Vector3 center = transform.position + centerOffset;
        shootDirection = (fireball.position - center).normalized;     //calcolo direzione

        isOrbiting = false;
        fireball.parent = null;                                       //Scollega la fireball dal Player
        Destroy(fireball.gameObject, 5f);
    }


    public void AcquireFireball()
    {
        if (fireball != null) return;

        fireball = Instantiate(fireballPrefab).transform;
        isOrbiting = true;
        angleDeg = 0f;
    }
}





















//[SerializeField] private GameObject fireballPrefab;
//[SerializeField] private Vector2 offsetCenter = new Vector2(0f, 0.8f);
//[SerializeField] private float radius = 0.35f;
//[SerializeField] private float degreesPerSecond = 180f;

//private Transform fireball;
//private float angle;

//public bool HasFireball => fireball != null;

//private void Update()
//{
//    if (fireball == null) return;

//    angle += degreesPerSecond * Time.deltaTime;
//    float rad = angle * Mathf.Deg2Rad;

//    Vector3 center = transform.position + (Vector3)offsetCenter;
//    Vector3 pos = center + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;

//    fireball.position = pos;
//    fireball.rotation = Quaternion.Euler(0f, 0f, angle);
//}

//public void AcquireFireball()
//{
//    if (HasFireball) return;

//    if(fireballPrefab == null)
//    {
//        Debug.LogError("FireballOrbit: non assegnato nell'inspector");
//        return;
//    }

//    GameObject go = Instantiate(fireballPrefab);

//    fireball = go.transform;
