using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    [SerializeField] Transform camera, player, barrel;
    private LineRenderer line;
    [SerializeField] LayerMask GrappleLayer;
    private Vector3 destination;
    [SerializeField] private float dist = 90.0f;
    private SpringJoint springJoint;

    private void Awake()
    {
        line= GetComponent<LineRenderer>();
        line.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Hook();
        }
        else if(Input.GetMouseButtonUp(0)) 
        {
            UnHook();
        }
    }
    private void LateUpdate()
    {
        Rope();
    }

    private void Hook()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, dist, GrappleLayer)) 
        {
            destination=hit.point;
            springJoint=player.gameObject.AddComponent<SpringJoint>();
            springJoint.autoConfigureConnectedAnchor= false;
            springJoint.connectedAnchor = destination;

            float playerDist= Vector3.Distance(player.position, destination);
            springJoint.maxDistance = playerDist * 0.75f;
            springJoint.minDistance = playerDist * 0.3f;

            springJoint.spring = 8.0f;
            springJoint.damper = 6.0f;
            springJoint.massScale= 5.0f;

            line.positionCount= 2;
            line.enabled=true;
        }
    }
    private void Rope()
    {
        if(!springJoint)
        {
            return;
        }
        line.SetPosition(0, barrel.position);
        line.SetPosition(1, destination);
    }
    private void UnHook()
    {
        line.positionCount= 0;
        line.enabled=false;
        Destroy(springJoint);
    }
}
