using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float health;
    public int damage;
    public int speed;
    public float chaseRange;
    public float pushForce;
    public int attackSpeed;
    public int attackRange;
    public Animator animator;
    public PlayerHealth playerHealth;
    [SerializeField] public Transform player;

   


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            animator.SetBool("isMoving", false);

            if (distanceToPlayer <= chaseRange)
            {
                ChasePlayer();
               
            }
        }
       

    }

    void ChasePlayer()
    {

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            AnimateMovement(direction);
        }
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            bool isMoving = direction != Vector3.zero;

            // Establece el parámetro "isMoving" en el valor calculado
            animator.SetBool("isMoving", isMoving);


        }
        
    }
}


