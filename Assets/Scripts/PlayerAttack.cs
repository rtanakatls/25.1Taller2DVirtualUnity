using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    private Animator animator;

    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyLayerMask;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("MeleeAttack");
        }
    }

    private void ExecuteAttack()
    {
        Collider2D[] colliders= Physics2D.OverlapCircleAll(attackPoint.position, attackRadius,enemyLayerMask);
        foreach(Collider2D collider in colliders)
        {
            EnemyLife enemyLife= collider.gameObject.GetComponent<EnemyLife>();
            if(enemyLife != null)
            {
                enemyLife.TakeDamage(1,transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
