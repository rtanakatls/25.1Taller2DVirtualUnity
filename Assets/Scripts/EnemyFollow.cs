using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float range;

    private float timer;
    private float patrolDirection;
    [SerializeField] private float patrolTime;

    private void Awake()
    {
        patrolDirection = transform.localScale.x;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(target!= null)
        {
            Vector2 scale = transform.localScale;
            Vector2 direction = target.transform.position - transform.position;
            if (Vector2.Distance(transform.position, target.position) < range && scale.x > 0 && transform.position.x < target.transform.position.x)
            {
                rb2d.linearVelocity = direction.normalized * speed;
            }
            else if (Vector2.Distance(transform.position, target.position) < range && scale.x < 0 && transform.position.x > target.transform.position.x)
            {
                rb2d.linearVelocity = direction.normalized * speed;
            }
            else
            {
                rb2d.linearVelocity = Vector2.right * patrolDirection * speed;
                timer += Time.deltaTime;
                if (timer >= patrolTime)
                {
                    timer = 0;
                    patrolDirection *= -1;
                    scale.x = patrolDirection;
                    transform.localScale=scale; 
                }
            }
            
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
