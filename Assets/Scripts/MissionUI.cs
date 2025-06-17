using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private List<ItemLevelSelector> items;
    private TextMeshProUGUI missionText;

    private void Awake()
    {
        missionText=GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        string text = "";
        foreach (ItemLevelSelector itemLevelSelector in items)
        {
            if (itemLevelSelector.IsActive)
            {
                text = itemLevelSelector.MissionText;
            }
        }

        if(text!="")
        {
            missionText.text = $"Misión actual: {text}";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
