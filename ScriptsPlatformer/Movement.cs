using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class Movement : MonoBehaviour
{
    [Space]
    [Header("Stats")]
    public float speed = 10;
    public Rigidbody2D rb;
    public Animator animator;
    public float dashSpeed = 10;
    public LayerMask foregroundLayer;
    [SerializeField]
    private float dashCooldownTime = 0.1f;
    private float dashTimer;
    [SerializeField]
    private float dashDistance;
    bool islookingRight = true;
    private float trueGravity;
    [SerializeField]
    float jumpForce = 6;
    Vector2 globDir;
    public CapsuleCollider2D capsuleCollider;




    void Start()
    {
        // Get Virtual Camera Noise Profile
      
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        trueGravity = rb.gravityScale;
    }
    void Update()
    {
        Jump();
        Shoot();
        Dash();


        
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(xRaw, yRaw);
        globDir = dir.normalized;
        Walk(dir);





    }

    private void Walk(Vector2 dir)
    {
        
        rb.velocity = new Vector2(dir.x * Time.fixedDeltaTime*speed, rb.velocity.y);
        if (dir.x != 0)
        {
            animator.SetBool("Running", true);
        }
        else animator.SetBool("Running", false);

        
        if(islookingRight && dir.x<0 ||!islookingRight && dir.x > 0)
        {
            islookingRight = !islookingRight;
            transform.Rotate(0f, 180f, 0f);
        }

       
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("ShootTrigger");
        }
    }

    void Jump()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 addingSpeed = new Vector2(0f, jumpForce);
                rb.velocity += addingSpeed;
            }
        }

    }

    void Dash()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, globDir,dashDistance,foregroundLayer.value);


        if (Time.time > dashTimer)
        {
            float distance = Vector2.Distance(hit.point, transform.position);


            if (Input.GetKeyDown(KeyCode.Z) && hit.collider == null)
            {

                rb.position += globDir * dashSpeed;
                dashTimer = Time.time + dashCooldownTime;
                Debug.Log("SHOW" + distance);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Z) && distance <= dashDistance)
                {

                    rb.position += globDir * (distance - 0.3f);
                    dashTimer = Time.time + dashCooldownTime;
                    Debug.Log("SHOW DIST" + distance);

                }
            }
        }
 
    }

   
    
}