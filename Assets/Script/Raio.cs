using UnityEngine;


public class Raio : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        rb.linearVelocity = transform.right * speed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        
        
    }
    


}
