using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 2f;
    public Animator animator;
    public static PlayerController Instance;
    public PlayerSoundEffect walkSoundEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput= Input.GetAxisRaw("Horizontal");
        float verticalInput= Input.GetAxisRaw("Vertical");
     
        Vector3 direction = new Vector3(horizontalInput,verticalInput).normalized;
        WalkSound();
        AnimateMovement(direction);
        transform.position += direction * speed * Time.fixedDeltaTime;


    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.x > 0)
            {
                animator.SetBool("isMovingRight", true );
                animator.SetBool("isMovingLeft", false);
                

            }
            else if (direction.x < 0)
            {
                animator.SetBool("isMovingLeft", true);
                animator.SetBool("isMovingRight", false);
                
               

            }
            else
            {
                animator.SetBool("isMovingRight", false );
                animator.SetBool("isMovingLeft", false);
              
            }
            
            
        }
        
    }

    private void WalkSound()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            walkSoundEffect.PlayAudio();
         
        }
        else
        {
          walkSoundEffect.StopAudio();
        }
    }
            
       
    
}
