using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int shieldLife;

    private void ChangeLife(int value)
    {
        life += value;
        if(BossPhaseController.Instance.CurrenBossPhase==BossPhase.Phase2)
        {
            BossPhaseController.Instance.CheckPhase2(life);
        }
        if (life <= 0)
        {
            Destroy(gameObject);
            BossController.Instance.CheckPhase2();

        }
    }

    private void ChangeShieldLife(int value)
    {
        shieldLife += value;
        if (shieldLife <= 0)
        {
            BossPhaseController.Instance.CheckPhase1();
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            switch(BossPhaseController.Instance.CurrenBossPhase)
            {
                case BossPhase.Phase1:
                    ChangeShieldLife(-1);
                    break;
                case BossPhase.Phase2:
                    ChangeLife(-1);
                    break;
                case BossPhase.Phase4:
                    ChangeLife(-1);
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

}
