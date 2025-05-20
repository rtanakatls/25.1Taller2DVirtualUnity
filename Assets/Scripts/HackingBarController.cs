using UnityEngine;

public class HackingBarController : MonoBehaviour
{
    [SerializeField] private RectTransform checkingBarTransform;
    [SerializeField] private RectTransform targetBarTransform;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;

    private float timer;
    [SerializeField] private float travelTime;

    [SerializeField] private int factor;

    private HackingController hackingController;

    public void SetUp(HackingController hackingController)
    {
        this.hackingController = hackingController;
    }

    private void Update()
    {
        MoveCheckingBar();
        CheckBar();
    }

    private void MoveCheckingBar()
    {
        checkingBarTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, timer / travelTime);
        timer += Time.deltaTime * factor;
        if (timer >= travelTime || timer <= 0)
        {
            factor *= -1;
        }
    }

    private void CheckBar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (checkingBarTransform.anchoredPosition.y < targetBarTransform.anchoredPosition.y
                && checkingBarTransform.anchoredPosition.y > targetBarTransform.anchoredPosition.y - 100)
            {
                hackingController.Next();
            }
            else
            {
                Debug.Log("Está fuera");
            }
        }
    }

}
