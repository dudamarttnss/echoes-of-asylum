using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent < SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        speedX = Input.GetAxisRaw("Horizontal") * movSpeed; //// movimentar na 
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        var direcao = new Vector2(speedX, speedY).normalized;
        rb.linearVelocity = direcao * movSpeed * Time.fixedDeltaTime;
        animator.SetFloat("speed", direcao.magnitude);
        if (direcao.magnitude != 0)
        {
            spriteRenderer.flipX = speedX < 0;

        }
        else
        {

        }

    }
    
   
    

}
