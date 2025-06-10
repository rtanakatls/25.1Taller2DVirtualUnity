using System.Collections;
using UnityEngine;

public class BossTurretShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBulletAmount;
    [SerializeField] private float shootDelay;
    [SerializeField] private float reloadDelay;
    private bool isShooting;

    private Transform target;

    private SpriteRenderer spriteRenderer;

    public bool IsShooting {  get { return isShooting; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
        }
        StartCoroutine(ShootLoop());
    }

    private IEnumerator ShootLoop()
    {
        while(true)
        {
            isShooting = true;
            spriteRenderer.color= Color.red;
            for(int i=1;i<=maxBulletAmount;i++)
            {
                GameObject bullet=Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                Vector2 direction=target.position - transform.position;
                bullet.GetComponent<BulletMovement>().SetDirection(direction.normalized);
                yield return new WaitForSeconds(shootDelay);
            }

            isShooting = false;
            spriteRenderer.color = Color.gray;
            yield return new WaitForSeconds(reloadDelay);
        }
    }



    



}
