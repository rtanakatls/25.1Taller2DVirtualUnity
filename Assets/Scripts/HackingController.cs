using System.Collections.Generic;
using UnityEngine;

public class HackingController : MonoBehaviour
{
    [SerializeField] private List<HackingBarController> controllers;
    private int currentHackingBarIndex = 0;
    
    void Awake()
    {
        foreach(HackingBarController controller in controllers)
        {
            controller.SetUp(this);
            controller.enabled = false;
        }
        controllers[currentHackingBarIndex].enabled = true;
    }


    public void Next()
    {
        controllers[currentHackingBarIndex].enabled = false;
        currentHackingBarIndex++;
        if (currentHackingBarIndex < controllers.Count)
        {
            controllers[currentHackingBarIndex].enabled = true;
        }
        
    }
}
