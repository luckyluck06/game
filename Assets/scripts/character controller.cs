using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10;


    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private int canJump;
    private int countJump;

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        
        float crtMove = Input.GetAxis("Horizontal")*speed;
        rb.velocity = new Vector2(crtMove, rb.velocity.y);
        animator.SetFloat("speed", crtMove);
        sr = GetComponent<SpriteRenderer>();

        bool crtJump = Input.GetButtonDown("Jump") && canJump > 0;
        if(crtJump)
        {
            Debug.Log("Jump");
            rb.velocity=new Vector2(rb.velocity.x, jumpForce);
            countJump++;
            canJump--;
        }

        sr.flipX = rb.velocity.x > 0;
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        { 
            canJump=2;
        }




    }

}
