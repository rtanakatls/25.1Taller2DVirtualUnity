using UnityEngine;

public class BossPhase3 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    private Transform target;

    private void OnEnable()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;

            rb2d.linearVelocity = direction.normalized * speed;
        }

        BossPhaseController.Instance.CheckPhase3();
    }

}
