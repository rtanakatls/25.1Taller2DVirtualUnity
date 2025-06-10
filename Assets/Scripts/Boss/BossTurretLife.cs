using UnityEngine;

public class BossTurretLife : MonoBehaviour
{
    [SerializeField] private int life;
    private BossTurretShoot bossTurretShoot;

    private void Awake()
    {
        bossTurretShoot=GetComponent<BossTurretShoot>();
    }

    private void ChangeLife(int value)
    {
        life += value;
        if(life<=0)
        {
            Destroy(gameObject);
            BossController.Instance.CheckPhase1();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (!bossTurretShoot.IsShooting)
            {
                ChangeLife(-1);
            }
            Destroy(collision.gameObject);
        }
    }

}
