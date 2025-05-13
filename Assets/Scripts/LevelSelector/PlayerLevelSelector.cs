using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelSelector : MonoBehaviour
{
    public static Vector2 position;

    private string levelName="";

    public static void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", position.y);
    }

    private void Awake()
    {
        Vector2 position = new Vector2(PlayerPrefs.GetFloat("PlayerPositionX", 0), PlayerPrefs.GetFloat("PlayerPositionY", 0));
        transform.position = position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && levelName != "" )
        {
            position = transform.position;
            SceneManager.LoadScene(levelName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemLevelSelector"))
        {
            levelName = collision.gameObject.GetComponent<ItemLevelSelector>().LevelName;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemLevelSelector"))
        {
            levelName = "";
        }
    }

}
