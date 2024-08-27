using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{ 
    Vector2 movementinput;
    public float movementspeed = 0.1f;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public float jumpspeed = 5;
    public float gravity = 9.8f;
    public float Verticalspeed = 0;
    public void IAMovement(InputAction.CallbackContext context)
    {
        movementinput = context.ReadValue<Vector2>();
        
    }
    public void IAJump(InputAction.CallbackContext context)
    {
        if(context.started == true && GroundCheck() == true)
        {
            Verticalspeed = jumpspeed;
        }
    }
    public void IAInteract (InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            InteractionRayCast();
        }
    }
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(GroundCheck() == true && Verticalspeed <= 0)
        {
            Verticalspeed = 0;
        }
        else
        {
            Verticalspeed = Verticalspeed - gravity * Time.deltaTime;
        }

        transform.Translate(movementinput.x * movementspeed * Time.deltaTime, Verticalspeed * Time.deltaTime , movementinput.y * movementspeed * Time.deltaTime);
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1.1f);
    }
    public void InteractionRayCast()
    {
        Vector3 myPosition = transform.position;
        Vector3 CameraDirection = playerCamera.transform.forward;

        Ray InteractionRay = new Ray(transform.position, CameraDirection)


       RaycastaHit targetinfo;
            
            Physics.Raycast(InteractionRay, out targetinfo, 5f );
    }
}