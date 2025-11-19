using UnityEngine;

public class gatinhoSeguirPlayer : MonoBehaviour
{
    public float velocidade = 3f;
    public float distanciaMinima = 0.5f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        // Se estiver muito perto, não move
        if (distancia <= distanciaMinima) return;

        // Move em direção ao player
        Vector2 direcao = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direcao * velocidade * Time.fixedDeltaTime);

        // Vira o gatinho para o lado certo
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
