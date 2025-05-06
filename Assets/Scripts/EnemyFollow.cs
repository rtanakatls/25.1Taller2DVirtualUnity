using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;

    private void Awake()
    {
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
            if (scale.x > 0 && transform.position.x < target.transform.position.x)
            {
                rb2d.linearVelocity = direction.normalized * speed;
            }
            else if(scale.x < 0 && transform.position.x > target.transform.position.x)
            {
                rb2d.linearVelocity = direction.normalized * speed;
            }
            else
            {
                rb2d.linearVelocity = Vector2.zero;
            }
            
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }

}
