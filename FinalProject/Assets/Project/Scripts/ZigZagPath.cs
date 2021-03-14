using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagPath : MonoBehaviour
{
    public float walkingSpeed; 
    public float walkingDuration;
    public GameObject Container;

    private Rigidbody2D objectRigidBody;
    private float walkingTimer;
    private bool walkingRight;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidBody = gameObject.GetComponent<Rigidbody2D>();

        walkingTimer = walkingDuration;
        walkingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Make timer work for moving object in opp direction after certain time 
        walkingTimer -= Time.deltaTime;
        if (walkingTimer <= 0.0f)
        {
            walkingTimer = walkingDuration;

            walkingRight = !walkingRight;
        }

        //Update Velocity 
        objectRigidBody.velocity = new Vector2 (
            walkingSpeed * (walkingRight ? 1 : -1),
            objectRigidBody.velocity.y
            );
        Container.transform.localScale = new Vector3(walkingRight ? -1 : 1, 1, 1);
    }
}
