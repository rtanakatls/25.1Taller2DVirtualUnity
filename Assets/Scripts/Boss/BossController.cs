using UnityEngine;

public class BossController : MonoBehaviour
{
    private static BossController instance;

    public static BossController Instance {  get { return instance; } }

    [SerializeField] private int currentTurretAmount;

    private void Awake()
    {
        instance = this;
    }


    public void CheckPhase1()
    {
        currentTurretAmount--;
        if (currentTurretAmount <= 0)
        {
            BossPhaseController.Instance.EnableBoss();
        }
    }

}
