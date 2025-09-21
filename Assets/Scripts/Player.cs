using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{

    //we can modify from the inspectorr
    public float speed = 40f;


    Rigidbody2D rigidbody2D;

    float horizontalX = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
    }





    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        //get actual velocity of the player
        Vector2 currentVelocity = rigidbody2D.linearVelocity;

        //change only the horizontal part of the velocity based on player input
        currentVelocity.x = horizontalX * speed;

        // apply the new velocity to the rigidbody2D of the player
        rigidbody2D.linearVelocity = currentVelocity;   
    }


    // input:Gameplay / Move
    public void OnMove(InputAction.CallbackContext c)
    {

        // Read the horizontal value from the input (-1, 0, or 1)..
        horizontalX = c.ReadValue<Vector2>().x;

        // if the input is canceled, the player is not moving
        if (c.canceled)
        {
            horizontalX = 0f;
        }
    }

}
