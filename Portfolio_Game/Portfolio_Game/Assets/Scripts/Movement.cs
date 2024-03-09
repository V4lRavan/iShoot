using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float x, y;
    [SerializeField] Transform orientation;
    [SerializeField] float moveSpeed;
    
    Vector3 movementDirection;
    // ground check
    [SerializeField] float height;
    [SerializeField] LayerMask GroundLayer;
    bool isGrounded;

    //jumping
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    bool jumpAvailable=true;
    [SerializeField] KeyCode jump = KeyCode.Space;

 [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, GroundLayer);

        Inputs();
        SpeedLimit();

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
       
        if(x==0 && y==0&&isGrounded)
        {
            rb.velocity= new Vector3(0,rb.velocity.y,0);
        }
        //jumping
      if(Input.GetKey(jump)&&jumpAvailable&&isGrounded)
        {
            jumpAvailable= false;
            Jump();
            //continouos jump when holding the button
            Invoke(nameof(jumpReset),jumpCooldown);
        }    
    }
    private void Move()
    {
        //the process of calculating the movement direction
        movementDirection = orientation.forward * y + orientation.right * x;

        rb.AddForce(movementDirection.normalized*moveSpeed*10f,ForceMode.Force);
    }

    private void SpeedLimit()
    {
        Vector3 initVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //velocity is limited when applicable 
        if(initVel.magnitude>moveSpeed) 
        {
            Vector3 limitedVel= initVel.normalized*moveSpeed;
            rb.velocity=new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        }
    }    

    private void Jump()
    {
        rb.velocity=new Vector3(rb.velocity.x,0f,rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpSound.Play();
    }    

    private void jumpReset()
    {
        jumpAvailable = true;
    }    
}
