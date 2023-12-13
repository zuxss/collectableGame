using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float health;
    public int damage;
    public float speed;
    public float chaseRange;
    public float pushForce;
    public int attackSpeed;
    public int attackRange;
    public Animator animator;
    public Animator playerHit;
    public PlayerHealth playerHealth;
    public AudioSource audioSource;
    [SerializeField] public Transform player;
 
    bool sound = false;


    public void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        playerHit = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.enabled = true;


    }

    


    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
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
            walkSound();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplica el daño al jugador
            DealDamage(collision.gameObject);
        }


    }

    private void DealDamage(GameObject player)
    {

        if (playerHealth != null)
        {
            playerHit.SetTrigger("isHit");
            playerHealth.TakeDamage(damage);

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

       

    public void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
           

            animator.SetBool("isWalkingRight",direction.x > 0 );
            animator.SetBool("isWalkingLeft", direction.x < 0);
            

        }

    }

    void walkSound()
    {
        if (!sound)
        {   
            sound = true;
            audioSource.Play();
            Invoke("stopWalkSound", 1f);
        }
        
        
    }
    
    void stopWalkSound()
    {
        sound = false;
        
    }
}


