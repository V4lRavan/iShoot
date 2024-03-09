using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : Gun
{
    //Essentials
    [SerializeField]
     NavMeshAgent agent;
    [SerializeField]
     Transform player;
    [SerializeField]
     LayerMask groundLayer, playerLayer;

    //Patrol
    [SerializeField]
    Vector3 walkingPoint;
    bool isWpSet;
    [SerializeField]
    float range;

    //Attack player
    [SerializeField]
    float attackInterval;
    bool isAttacked;

    //States
    [SerializeField] float enemyRange, enemyAttackRange;
    [SerializeField] bool isPlayerInEnemyRange, isPlayerInAttackRange;
    
    //Enemy stats
    float health=100;

    int bl;
    
    private void Awake()
    {
        player = GameObject.Find("FinalPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
    
    }


    // Start is called before the first frame update
    void Start()
    {
        bl = LayerMask.NameToLayer("BulletLayer");
    }

    // Update is called once per frame
    private void Update()
    {
        isPlayerInEnemyRange = Physics.CheckSphere(transform.position, enemyRange, playerLayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, enemyAttackRange, playerLayer);

        if (!isPlayerInEnemyRange && !isPlayerInEnemyRange) Patrol();
        if (isPlayerInEnemyRange&&!isPlayerInAttackRange) SeekPlayer(); 
        if (isPlayerInEnemyRange && isPlayerInAttackRange) AttackPlayer();
    }


    private void Patrol()
    {
        if(!isWpSet)FindWalkingPoint();

        if(isWpSet)
            agent.SetDestination(walkingPoint);

        Vector3 distanceToWalkingPoint=transform.position-walkingPoint;

        //reached the walking point
        if (distanceToWalkingPoint.magnitude < 1f) 
            isWpSet= false;
    }


    private void FindWalkingPoint()
    {
        //Calculation to find the random point in the range
        float randX= Random.Range(-range, range);
        float randZ = Random.Range(-range, range);

        walkingPoint= new Vector3(transform.position.x+randX,transform.position.y,transform.position.z+randZ);

        //Checking if the random point found is on the ground
        if (Physics.Raycast(walkingPoint, -transform.up, 2f, groundLayer));
        isWpSet= true;

    }

    private void SeekPlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Enemies don't move when attacking player
        agent.SetDestination(transform.position);
        Vector3 lookAtPos = player.position;
        lookAtPos.y = transform.position.y;
        transform.LookAt(lookAtPos);

        if(!isAttacked)
        {
            //Attacking functionality goes below 
            Shoot();
            isAttacked= true;
            Invoke(nameof(AttackReset), attackInterval);
        }
    }

    private void AttackReset()
    {
        isAttacked= false;
    }

    private void DamageDealtToEnemy(float damage)
    {
        health-= damage;
        if (health <= 0) Invoke(nameof(EnemyDeath), 1.0f);
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer==bl)
        {
            DamageDealtToEnemy(50);
        }
    }
}
