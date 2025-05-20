using UnityEngine;
using TMPro;

public class BulletText : MonoBehaviour
{
    private static BulletText instance;

    public static BulletText Instance {  get { return instance; } }

    private TextMeshProUGUI bulletText;

    private void Awake()
    {
        instance = this;
        bulletText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(int value, int maxValue)
    {
        bulletText.text = $"{value}/{maxValue}";
    }
}
