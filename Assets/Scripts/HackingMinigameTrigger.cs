using UnityEngine;

public class HackingMinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    private bool isPlayerInContact;

    private void EnableMinigame()
    {
        minigame.SetActive(true);   
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if(isPlayerInContact&&Input.GetKeyDown(KeyCode.E))
        {
            EnableMinigame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = false;
        }

    }
}
