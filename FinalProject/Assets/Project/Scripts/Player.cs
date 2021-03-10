﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void CollectCoinHandler();

    public event CollectCoinHandler OnCoinCollected;

    [Header("Movement")]
    public float walkingSpeed;
    public float jumpingSpeed;

    [Header("Visuals")]
    public GameObject container;
    public float powerupScale = 1.3f;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private float width;
    private float height;

    private bool dead;
    public bool Dead { get { return dead; } }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();

        width = gameObject.GetComponent<CapsuleCollider2D>().size.x;
        height = gameObject.GetComponent<CapsuleCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            // TO MAKE THE PLAYER MOVE HORIZAONTALLY
            playerRigidbody.velocity = new Vector2(
                 Input.GetAxis("Horizontal") * walkingSpeed,             //GET AXIS RETURNS -1 TO 1
                 playerRigidbody.velocity.y
             );

            // Point the player towards the right direction.
            if (Input.GetAxis("Horizontal") > 0)
            {
                container.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                container.transform.localScale = new Vector3(-1, 1, 1);
            }

            //TO MAKE THE PLAYER JUMP
            // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, ( height / 2) + 0.1f);
            // Debug.Log(hit.collider.name);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height / 2 - 0.01f), Vector2.down, 0.02f);

            if (hit.collider != null && Input.GetAxis("Jump") > 0)
            {
                playerRigidbody.velocity = new Vector2(
                        playerRigidbody.velocity.x,
                        jumpingSpeed
                    );
            }

            // Set the player's animation.
            playerAnimator.SetBool("Run", Mathf.Abs(playerRigidbody.velocity.x) > 0);
            playerAnimator.SetBool("Jump", hit.collider == null);
        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log(otherCollider.gameObject.name);
        // Collects coin
        if (otherCollider.gameObject.tag == "Coin")
        {
            if (OnCoinCollected != null)
            {
                OnCoinCollected();
            }
            //count coins
            Destroy(otherCollider.gameObject);

        }
        if (otherCollider.gameObject.tag == "Enemy")
        {
            Hurt();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy collisions
        if (collision.gameObject.tag == "Enemy")
        {
            RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x - width / 2, transform.position.y - height / 2 - 0.01f), Vector2.down, 0.02f);
            RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x + width / 2, transform.position.y - height / 2 - 0.01f), Vector2.down, 0.02f);
            RaycastHit2D centerHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height / 2 - 0.01f), Vector2.down, 0.02f);

            if ((leftHit.collider != null && leftHit.collider.gameObject == collision.gameObject) ||
                (rightHit.collider != null && rightHit.collider.gameObject == collision.gameObject) ||
                (centerHit.collider != null && centerHit.collider.gameObject == collision.gameObject))
            {

                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy.hittable)
                {
                    enemy.OnHit(gameObject);

                    playerRigidbody.velocity = new Vector2(
                        0,
                        jumpingSpeed
                    );
                }
                else
                {
                    Hurt();
                }
            }
            else
            {
                Hurt();
            }
        }
    }

    void Hurt()
    {

        GetComponent<Collider2D>().enabled = false;
        playerRigidbody.velocity = new Vector2(
            0,
            jumpingSpeed
        );

        dead = true;

        Destroy(gameObject, 3f);

    }

}
