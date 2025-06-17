using UnityEngine;

public class ItemLevelSelector : MonoBehaviour
{
    [SerializeField] private string levelName;
    private SpriteRenderer spriteRenderer;
    private bool isActive;


    public bool IsActive {  get { return isActive; } }
    public string LevelName {  get { return levelName; } }
    
    

    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        isActive = true;
        if(PlayerPrefs.GetString("CurrentLevel", "") != levelName)
        {
            isActive = false;
            Color color=spriteRenderer.color;
            color.a = 0.3f;
            spriteRenderer.color=color;
            Destroy(GetComponent<PolygonCollider2D>());
        }
    }
}
