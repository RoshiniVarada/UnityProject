using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float walkingSpeed;
    public float jumpingSpeed;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TO MAKE THE PLAYER MOVE HORIZAONTALLY
        playerRigidbody.velocity = new Vector2(
                 Input.GetAxis("Horizontal") * walkingSpeed,             //GET AXIS RETURNS -1 TO 1
                 playerRigidbody.velocity.y
             );
        //TO MAKE THE PLAYER JUMP
        if (Input.GetAxis("Jump") > 0)
        {
            playerRigidbody.velocity = new Vector2(
                    playerRigidbody.velocity.x,
                    jumpingSpeed
                );
        }
            
    }
}
