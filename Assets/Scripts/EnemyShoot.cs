using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float timer;
    [SerializeField] private float shootDelay;

    [SerializeField] private float range;

    private Transform target;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) <= range)
            {
                Vector2 direction = target.position - transform.position;
                transform.up = direction;
            }
            timer += Time.deltaTime;
            if (timer >= shootDelay)
            {
                if (Vector2.Distance(target.position, transform.position) <= range)
                {
                    Vector2 direction = target.position - transform.position;
                    GameObject obj = Instantiate(bulletPrefab);
                    obj.transform.position = transform.position;
                    obj.GetComponent<BulletMovement>().SetDirection(direction.normalized);
                    timer = 0;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
