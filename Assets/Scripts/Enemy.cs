using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public int health;
    public int damage;
    public int speed;
    public float chaseRange;
    public float pushForce;
    public int attackSpeed;
    public int attackRange;
    public PlayerHealth playerHealth;
    [SerializeField] public Transform player;

   


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

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
        }
        
    }
    public void TakeDamage(int damage)
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
}


