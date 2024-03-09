using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBul();
    }
    private void DestroyBul()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyBul", 6);
    }
}
