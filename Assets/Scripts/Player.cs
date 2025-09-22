using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    //we can modify from the inspectorr
    public float speed = 6f;

    public GameObject startPanel;

    public DummyHit dummy;



    Rigidbody2D rigidbody2D;

    float horizontalX = 0f;

    int jumps = 0;
    bool started = false;   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();

        if (startPanel)

        {

            startPanel.SetActive(true);
            Time.timeScale = 0f; // paused until Start

        }


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

        // Read the horizontal value from the input (-1, 0, or  1)
        horizontalX = c.ReadValue<Vector2>().x;

        // if the input is canceled, the player is not moving
        if (c.canceled)
        {
            horizontalX = 0f;
        }
    }


    // Input:Gameplay / Start (Enter)
    public void OnStart(InputAction.CallbackContext c)
    {

        if (c.performed && !started)
        {
            started = true;
            if (startPanel) startPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void onJump(InputAction.CallbackContext c)
    {
        if (c.performed && jumps < 2)
        {
            //jump
            rigidbody2D.AddForce(Vector2.up * 400f);
            jumps++;
        }
    }

    // Reset jumps when touching Ground
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
            jumps = 0;
    }



    public void OnMelee(InputAction.CallbackContext c)

    {
                        // Calculate distance between player and dummy, if less than 2 units allow hit
        if (c.performed && Vector2.Distance(transform.position, dummy.transform.position) < 2f)

            dummy.TriggerHit();
    }
}
