using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTest : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetString("CurrentLevel", nextLevel);
            PlayerLevelSelector.SavePlayerPosition();
            SceneManager.LoadScene("LevelSelectorScene");
        }
    }
}
