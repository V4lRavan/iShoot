using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float xSens;
    [SerializeField] float ySens;

    [SerializeField] Transform camera;
    [SerializeField] Transform player;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible= false;
        xRotation= transform.eulerAngles.x;
        yRotation= transform.eulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * ySens;

        yRotation += mouseX;
        xRotation-= mouseY;
        xRotation= Mathf.Clamp(xRotation, -90f, 90f);

       player.rotation=Quaternion.Euler(0, yRotation, 0);
       camera.localRotation=Quaternion.Euler(xRotation,0, 0);
    }
}
