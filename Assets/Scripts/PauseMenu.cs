using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] static bool isPaused = false;

    [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused) 
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();

            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused= true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

   public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
