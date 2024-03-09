using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
   
   
    float radius = 20.0f;
    [SerializeField]
    float force = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    private void OnCollisionEnter(Collision other)
    {
        Vector3 playerPos=other.collider.transform.position;
        playerPos.y=transform.position.y;
        other.collider.attachedRigidbody.AddExplosionForce(force,transform.position,radius);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
