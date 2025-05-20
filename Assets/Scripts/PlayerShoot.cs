using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private List<Bullet> bulletOptions;
    private Camera cam;
    private float timer;
    private Bullet currentBullet;
    private int currentBulletAmount;
    private bool isReloading;

    void Start()
    {
        ChangeBullet(PowerUpType.Pistol);
        GameObject cameraObject = GameObject.Find("Main Camera");
        if (cameraObject != null)
        {
            cam = cameraObject.GetComponent<Camera>(); 
        }
        UpdateText();
    }

    private void UpdateText()
    {
        BulletText.Instance.SetText(currentBulletAmount, currentBullet.maxBulletAmount);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Shoot();
        CheckReload();
    }

    private void CheckReload()
    {
        if (!isReloading&&Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(currentBullet.reloadDelay);
        isReloading = false;
        currentBulletAmount = currentBullet.maxBulletAmount;
        UpdateText();
    }


    void Shoot()
    {
        if (cam != null&&!isReloading)
        {
            timer += Time.deltaTime;
            if(Input.GetMouseButton(0)&& timer>=currentBullet.shootDelay&&currentBulletAmount>0)
            {
                Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - transform.position;
                GameObject bullet=Instantiate(currentBullet.prefab);
                bullet.transform.position = transform.position;
                bullet.GetComponent<BulletMovement>().SetDirection(direction.normalized);
                currentBulletAmount--;
                UpdateText();
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
                ChangeBullet(collision.gameObject.GetComponent<PowerUp>().Type);
            }
        }
    }

    private void ChangeBullet(PowerUpType type)
    {
        foreach(Bullet b in bulletOptions)
        {
            if(b.type == type)
            {
                currentBullet = b;
                currentBulletAmount = currentBullet.maxBulletAmount;
                UpdateText();
            }
        }
    }

}
