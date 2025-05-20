using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else if (h > 0)
        {

            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }

        rb2d.linearVelocity = new Vector2(h, v).normalized * speed;
    }
}
