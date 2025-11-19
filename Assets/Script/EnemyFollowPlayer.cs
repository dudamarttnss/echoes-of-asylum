using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float velocidade = 3f;
    public float distanciaDetectarPlayer = 5f;  
    public float distanciaMinimaAtaque = 1.5f;   
    public float tempoPerseguindoMax = 30f;
    // public Raio raio;

    private Transform player;
    private Rigidbody2D rb;
    private AplicadorDano ataque;
    

    private bool perseguindo = false;
    private float tempoPerseguindo = 0f;

    void Start()
    {
        GameObject jogadorObj = GameObject.FindGameObjectWithTag("Player");
        if (jogadorObj != null)
        {
            player = jogadorObj.transform;
        }

        rb = GetComponent<Rigidbody2D>();
        ataque = GetComponent<AplicadorDano>();
    }
    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        // Inicia perseguição apenas uma vez
        if (!perseguindo && distancia <= distanciaDetectarPlayer)
        {
            perseguindo = true;
        }

        if (perseguindo)
        {
            tempoPerseguindo += Time.deltaTime;

            if (tempoPerseguindo <= tempoPerseguindoMax)
            {
                if (distancia > distanciaMinimaAtaque)
                {
                    Vector2 direcao = (player.position - transform.position).normalized;
                    rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);
                }

                if (player.position.x > transform.position.x)
                    transform.localScale = new Vector3(1, 1, 1);
                else
                    transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                perseguindo = false;
                Debug.Log("Inimigo parou de perseguir o player.");
                Destroy(gameObject); // inimigo morre depois dos 30s
            }
        }
    }
 }
