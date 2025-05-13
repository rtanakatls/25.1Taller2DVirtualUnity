using UnityEngine;

public class ItemLevelSelector : MonoBehaviour
{
    [SerializeField] private string levelName;

    public string LevelName {  get { return levelName; } }
}
