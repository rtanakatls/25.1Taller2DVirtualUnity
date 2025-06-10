using UnityEngine;

public class BossPhase1 : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void OnEnable()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
