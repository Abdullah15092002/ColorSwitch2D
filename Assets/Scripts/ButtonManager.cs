using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public void OnButtonClicked() {
        gameManager.StartGame();
    }
}
