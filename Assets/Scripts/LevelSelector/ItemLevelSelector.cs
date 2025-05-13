using UnityEngine;

public class ItemLevelSelector : MonoBehaviour
{
    [SerializeField] private string levelName;
    private SpriteRenderer spriteRenderer;

    public string LevelName {  get { return levelName; } }
    
    

    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();

        if(PlayerPrefs.GetString("CurrentLevel", "") != levelName)
        {
            Color color=spriteRenderer.color;
            color.a = 0.3f;
            spriteRenderer.color=color;
            Destroy(GetComponent<PolygonCollider2D>());
        }
    }
}
