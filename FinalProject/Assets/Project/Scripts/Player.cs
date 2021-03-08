using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float walkingSpeed;
    public float jumpingSpeed;

    private Rigidbody2D playerRigidbody;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();

        height = gameObject.GetComponent<CapsuleCollider2D>().size.y;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log(otherCollider.gameObject.name);
        // Collect coins.
        if (otherCollider.gameObject.tag == "Coin")
        {
           
            Destroy(otherCollider.gameObject);

           
        }

     

   
    }
    void Update()
    {
        // TO MAKE THE PLAYER MOVE HORIZAONTALLY
        playerRigidbody.velocity = new Vector2(
                 Input.GetAxis("Horizontal") * walkingSpeed,             //GET AXIS RETURNS -1 TO 1
                 playerRigidbody.velocity.y
             );
        //TO MAKE THE PLAYER JUMP
       // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, ( height / 2) + 0.1f);
       // Debug.Log(hit.collider.name);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height / 2 - 0.01f), Vector2.down, 0.02f);

        if (hit.collider != null &&  Input.GetAxis("Jump") > 0)
        {
            playerRigidbody.velocity = new Vector2(
                    playerRigidbody.velocity.x,
                    jumpingSpeed
                );
        }
            
    }
}
