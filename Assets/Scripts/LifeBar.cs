using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private static LifeBar instance;

    public static LifeBar Instance { get { return instance; } } 

    private float maxValue;
    private Image image;

    private void Awake()
    {
        instance = this;
        image = GetComponent<Image>();
    }

    public void SetUp(float value)
    {
        maxValue = value;
        UpdateLifeBar(value);
    }

    public void UpdateLifeBar(float value)
    {
        image.fillAmount = value / maxValue;
    }

}
