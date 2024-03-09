using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    // bullet force
    [SerializeField]
    float bullForce;
    //stats for the gun
    [SerializeField]
    float shootingTime, shotSpeed, shotTime;
    [SerializeField]
    int magSize, bulletsPerClick;
    [SerializeField]
    bool isButtonHeld;
    AudioSource gunShot;
    bool isShooting, isBullReady;

    [SerializeField]
    Transform attackPos;
    [SerializeField]
    bool allowInvoke= true;

    private void Awake()
    {
        isBullReady= true;
        gunShot= GetComponent<AudioSource>();
    }

    protected void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
      //cheing if allowed to hold the shooting button down and then assigning the button
    
         isShooting=Input.GetKey(KeyCode.Mouse0); 

        //if ready to shoot and is shooting and not reloading and bullet amount is more than zero set shot amount to zero and shoot
        if (isShooting &&isBullReady) 
        {
            Shoot();
        }
    }

     protected void Shoot()
     {
       isBullReady= false;

        //finding the direction 
        Vector3 dir =attackPos.forward;

        //making the actual bullet
        GameObject projectile = Instantiate(bullet, attackPos.position, attackPos.rotation);//storing the instantiated bullet in projectile
        //making the bullet rotate relative to shooting dir
        projectile.transform.forward = dir.normalized;
        //adding force
        projectile.GetComponent<Rigidbody>().AddForce(dir.normalized*bullForce,ForceMode.Impulse);
        if(gunShot!= null)
        gunShot.Play();

        //resetting shot 
        if (allowInvoke)
        {
            Invoke("ResetShot", shotTime);
            allowInvoke = false;
        }

     }

    private void ResetShot()
    {
        isBullReady= true;
        allowInvoke=true;
    }
}
