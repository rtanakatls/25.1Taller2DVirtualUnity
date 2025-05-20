using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    private int maxLife;

    private void Awake()
    {
        maxLife = life;
    }

    private void Start()
    {
        LifeBar.Instance.SetUp(life);
    }

    private void ChangeLife(int value)
    {
        life += value;
        if (life > maxLife)
        {
            life = maxLife;
        }
        LifeBar.Instance.UpdateLifeBar(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ChangeLife(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Health"))
        {
            ChangeLife(5);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }

}
