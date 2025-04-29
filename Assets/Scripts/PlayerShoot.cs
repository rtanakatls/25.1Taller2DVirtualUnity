using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Camera cam;

    void Start()
    {
        GameObject cameraObject = GameObject.Find("Main Camera");
        if (cameraObject != null)
        {
            cam = cameraObject.GetComponent<Camera>(); 
        }
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (cam != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - transform.position;
                GameObject bullet=Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.GetComponent<BulletMovement>().SetDirection(direction.normalized);
            }            
        }
    }
}
