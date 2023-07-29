using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemiPatrol : MonoBehaviour

{
    public float speed;
    public Transform[] waypoints;
    public int lifes = 1;
    public bool loadandscreen = false;
    public float timeToDie = 0.3f;

    private Transform target;
    private int destPoint = 0;
    private bool isDead=false;
    private Animator animator;

   


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
        target = waypoints[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
           timeToDie -= Time.deltaTime;
            if (timeToDie < 0)
            {
                Die();
            }
            return;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }


    public void Hit()
    {
        lifes--;
        if (lifes ==0)
        {
            isDead=true;
            animator.SetBool("Dead", true);



        }

    }
    public void Die()
    {
        gameObject.SetActive(false);
        if (loadandscreen)
         SceneManager.LoadScene("end menu");


    }
    /* public void OnCollisionEnter2D(Collision2D col)
     {
          gameObject.SetActive(false);
     }*/
}
