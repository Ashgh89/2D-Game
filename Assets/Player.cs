using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float playerMoveSpeed = 4;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FlipPlayer();
        PlayerSlide();
    }

    void PlayerMove()
    {
        var playerMoveHorizontally = Input.GetAxis("Horizontal") * playerMoveSpeed;
        var playerMove = new Vector2(playerMoveHorizontally, 0);
        rb.velocity = playerMove;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
        
    }
    void FlipPlayer()
    {
        bool playerIsMovingHorizontally = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon; // If Player is moving

        if (playerIsMovingHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    void PlayerSlide()
    {
        bool playerHasHorizontalSpeed1 = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnimator.SetBool("Sliding", playerHasHorizontalSpeed1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            myAnimator.SetBool("Sliding", false);
        }

    }
}
