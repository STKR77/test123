using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{ 
    Vector2 movementinput;
    public float movementspeed = 0.1f;
    public float jumpspeed = 1f;
    public float gravity = 9.8f;
    public float Verticalspeed = 0;
    public void IAMovement(InputAction.CallbackContext context)
    {
        movementinput = context.ReadValue<Vector2>();
        
    }

    public void IAJump (InputAction.CallbackContext context) 
    {
     if(context.started == true)
      {
        Debug.Log("started");
      }
     if (context.performed == true)
      {
        Debug.Log("performed");
      }
     if (context.canceled == true)
      {
         Debug.Log("cancelled");
      }
    }
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(GroundCheck() == true)
        {
            Verticalspeed = 0;
        }
        else
        {
            Verticalspeed = (Verticalspeed - gravity) * Time.deltaTime;
        }

        transform.Translate(movementinput.x * movementspeed * Time.deltaTime, Verticalspeed , movementinput.y * movementspeed * Time.deltaTime);
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1);
    }
}