using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverandWonMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayAgain()
    {
       SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Game over");
        Application.Quit();
    }
}
