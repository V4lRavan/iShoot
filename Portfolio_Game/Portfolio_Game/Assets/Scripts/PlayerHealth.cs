using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    GameObject player;
    [SerializeField]
    int health=100;
    int bl;
    // Start is called before the first frame update
    private void Update()
    {
        HealthBar();
    }
    private void Start()
    {
        bl = LayerMask.NameToLayer("BulletLayer");
    }
    public void HealthBar()
    {
        slider.value = health;
    }

    private void PlayerDeath(int damage)
    {
        health -=damage;
        if (health <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer==bl)
        {
            PlayerDeath(10);
        }
    }

}
