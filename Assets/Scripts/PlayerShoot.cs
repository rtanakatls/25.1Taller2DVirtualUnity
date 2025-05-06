using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Camera cam;
    private float timer;
    [SerializeField] private float shootDelay;

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
            timer += Time.deltaTime;
            if(Input.GetMouseButton(0)&& timer>=shootDelay)
            {
                Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - transform.position;
                GameObject bullet=Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.GetComponent<BulletMovement>().SetDirection(direction.normalized);
                timer = 0;
            }            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            if (collision.gameObject.GetComponent<PowerUp>())
            {
                switch (collision.gameObject.GetComponent<PowerUp>().Type)
                {
                    case PowerUpType.Pistol:
                        shootDelay = 0.2f;
                        break;
                    case PowerUpType.MachineGun:
                        shootDelay = 0.05f;
                        break;
                }
            }
        }
    }

}
