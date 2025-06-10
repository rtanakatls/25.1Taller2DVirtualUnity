using System.Collections.Generic;
using UnityEngine;

public enum BossPhase
{
    Phase0,
    Phase1,
    Phase2,
    Phase3,
    Phase4,
}

public class BossPhaseController : MonoBehaviour
{
    private static BossPhaseController instance;

    public static BossPhaseController Instance {  get { return instance; } }

    private BossPhase currentBossPhase;

    public BossPhase CurrenBossPhase { get { return currentBossPhase; } }

    [SerializeField] private GameObject shield;


    private List<MonoBehaviour> bossPhases;

    [SerializeField] private List<GameObject> enemies;
    
    

    private void Awake()
    {
        instance = this;
        bossPhases = new List<MonoBehaviour>();
        bossPhases.Add(GetComponent<BossPhase1>());
        bossPhases.Add(GetComponent<BossPhase2>());
        bossPhases.Add(GetComponent<BossPhase3>());
        bossPhases.Add(GetComponent<BossPhase4>());

        foreach(MonoBehaviour component in bossPhases)
        {
            component.enabled = false;
        }
    }

    public void EnableBoss()
    {
        currentBossPhase = BossPhase.Phase1;
        bossPhases[0].enabled = true;
    }

    public void CheckPhase1()
    {
        shield.SetActive(false);
        currentBossPhase = BossPhase.Phase2;
        bossPhases[0].enabled = false;
        bossPhases[1].enabled = true;
    }

    public void CheckPhase2(int life)
    {
        if (life <= 30)
        {
            currentBossPhase = BossPhase.Phase3;
            bossPhases[1].enabled = false;
            bossPhases[2].enabled = true;

            foreach(GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }
            shield.SetActive(true);
        }
    }

    public void CheckPhase3()
    {
        bool enemyAlive = false;

        foreach (GameObject enemy in enemies)
        {
            if(enemy!=null)
            {
                enemyAlive = true;
            }
        }
        if (!enemyAlive)
        {
            shield.SetActive(false);
            currentBossPhase = BossPhase.Phase4;
            bossPhases[2].enabled = false;
            bossPhases[3].enabled = true;
        }
    }

}
