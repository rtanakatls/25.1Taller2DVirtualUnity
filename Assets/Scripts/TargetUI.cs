using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    [SerializeField] private List<ItemLevelSelector> items;

    [SerializeField] private Camera cam;
    private Transform target;
    [SerializeField] private Vector2 margins;
    private Vector2 size;
    private RectTransform rectTransform;
    void Awake()
    {
        rectTransform=GetComponent<RectTransform>();
        size = rectTransform.sizeDelta;
    }

    private void Start()
    {
        foreach (ItemLevelSelector itemLevelSelector in items)
        {
            if (itemLevelSelector.IsActive)
            {
                target = itemLevelSelector.transform;
            }
        }

        if (target== null)
        {
            gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if(target==null)
        {
            return;
        }


        Vector2 position = cam.WorldToScreenPoint(target.position);

        position.x = Mathf.Clamp(position.x, 0 + margins.x + size.x / 2, Screen.width - margins.x - size.x / 2);
        position.y = Mathf.Clamp(position.y, 0 + margins.y + size.y / 2, Screen.height - margins.y - size.y / 2);
        transform.position = position;
    }
}
