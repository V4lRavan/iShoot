using UnityEngine;

public class WallRun : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Transform player;
    [SerializeField]
    LayerMask wall;
    [SerializeField]
    float force, maxTime, maxSpeed;
    bool isWallLeft, isWallRight;
    bool isRunning;
    [SerializeField]
    float maxTilt, camTilt;




    private void Inputs()
    {
        if (Input.GetKey(KeyCode.W) && isWallLeft) WallRunning();
        if (Input.GetKey(KeyCode.W) && isWallRight) WallRunning();
    }


    private void WallRunning()
    {
        rb.useGravity = false;
        isRunning = true;

        if(rb.velocity.magnitude<=maxSpeed)
        {
            rb.AddForce(player.forward * force / 5 * Time.deltaTime);

            //making the character stay on the wall
            if(isWallLeft)
            {
                rb.AddForce(-player.right * force / 5 * Time.deltaTime);
            }
            else
            {
                rb.AddForce(player.right * force / 5 * Time.deltaTime);
            }
        }  
    }

    private void WallCheck()
    {
        isWallLeft = Physics.Raycast(transform.position, -player.right, 1.0f, wall);
        isWallRight = Physics.Raycast(transform.position, player.right, 1.0f, wall);
        //exiting wallrun
        if (!isWallLeft && !isWallRight) StopRunning();
        
    }

    private void StopRunning()
    {
        isRunning = false;
        rb.useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        WallCheck();
    }
}
