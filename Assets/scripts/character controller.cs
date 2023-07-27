using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private GameObject collider;
    [SerializeField] private float attackDuration = 0.1f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private int canJump;
    private int countJump;

    private bool oldAttack = false;
    private float attackTime = 0.0f;
    private float startScaleX = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        startScaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float crtMove = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(crtMove, rb.velocity.y);
        animator.SetFloat("speed", crtMove);

        bool crtJump = Input.GetButtonDown("Jump") && canJump > 0;
        if (crtJump)
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            countJump++;
            canJump--;
        }


        Vector3 scale = transform.localScale;
        float flipFactor = rb.velocity.x > 0 ? -1 : 1;
        scale.x = flipFactor * startScaleX;
        transform.localScale = scale;


        if (Input.GetButtonDown("Fire2") && !oldAttack && attackTime <= 0)
        {
            animator.SetBool("Attack", true);
            collider.SetActive(true);
            attackTime = attackDuration;
        }

        if (attackTime <= 0)
        {
            collider.SetActive(false);
            animator.SetBool("Attack", false);
        }

        attackTime -= Time.deltaTime;
        oldAttack = Input.GetButtonDown("Fire2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = 2;
        }

        if (other.TryGetComponent(out EnnemiPatrol enemy))
        {
            Debug.Log("Tet");
        }
    }

}
