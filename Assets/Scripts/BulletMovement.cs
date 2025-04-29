using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Move()
    {
        rb2d.linearVelocity = direction.normalized * speed;
    }
}
