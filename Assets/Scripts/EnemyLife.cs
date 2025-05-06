using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life;
    private Rigidbody2D rb2d;
    [SerializeField] private float knockbackForce;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int value, Transform attackSource)
    {
        Vector2 direction = attackSource.position - transform.position;
        if ((direction.x < 0 && transform.localScale.x > 0) || (direction.x > 0 && transform.localScale.x < 0))
        {

            ChangeLife(-life);
        }
        else
        {
            ChangeLife(-value);
            rb2d.AddForce(-direction.normalized * knockbackForce, ForceMode2D.Impulse);
        }
    }

}
