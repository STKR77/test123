using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{ 
    Vector2 movementinput;
    public float movementspeed = 0.1f;
    public void IAMovement(InputAction.CallbackContext context)
    {
        movementinput = context.ReadValue<Vector2>();

    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementinput.x * movementspeed * Time.deltaTime, 0, movementinput.y * movementspeed * Time.deltaTime);
       
    }



}