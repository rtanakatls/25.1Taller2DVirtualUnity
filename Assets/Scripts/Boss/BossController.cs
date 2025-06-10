using UnityEngine;

public class BossController : MonoBehaviour
{
    private static BossController instance;

    public static BossController Instance {  get { return instance; } }

    [SerializeField] private int currentTurretAmount;

    [SerializeField] private GameObject exit;

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

    public void CheckPhase2()
    {
        exit.SetActive(true);
    }

}
