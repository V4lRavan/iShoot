using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] string nextLevel;

    private void  OnCollisionEnter(Collision other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(nextLevel);
    }

}
