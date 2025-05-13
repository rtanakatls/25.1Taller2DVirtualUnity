using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string levelSelectorSceneName;
    [SerializeField] private Button playButton;
    [SerializeField] private Button continueButton;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            continueButton.interactable = false;
        }

        playButton.onClick.AddListener(OnPlayButtonClicked);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("SaveData", 1);
        PlayerPrefs.SetString("CurrentLevel", "Level1Scene");
        LoadScene();
    }

    private void OnContinueButtonClicked()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(levelSelectorSceneName);
    }



}
