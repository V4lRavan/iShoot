using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void  OnCollisionEnter(Collision other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(nextLevel);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
