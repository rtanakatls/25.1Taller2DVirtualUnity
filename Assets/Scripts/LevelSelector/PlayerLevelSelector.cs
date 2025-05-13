using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelSelector : MonoBehaviour
{
    private string levelName="";


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && levelName != "" )
        {
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
