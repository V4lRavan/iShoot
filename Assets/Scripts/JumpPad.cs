using UnityEngine;

public class JumpPad : MonoBehaviour
{
    float radius = 20.0f;
    [SerializeField]
    float force = 500.0f;
 
    private void OnCollisionEnter(Collision other)
    {
        Vector3 playerPos=other.collider.transform.position;
        playerPos.y=transform.position.y;
        other.collider.attachedRigidbody.AddExplosionForce(force,transform.position,radius);
    }
}
