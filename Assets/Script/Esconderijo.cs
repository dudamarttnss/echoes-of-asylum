using UnityEngine;

public class Esconderijo : MonoBehaviour
{
    private bool playerPodeEsconder = false;
    private GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D rb;
    


    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou é o jogador (use Tags para isso)
        if (other.CompareTag("Player"))
        {
            playerPodeEsconder = true;
            player = other.gameObject;
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            Debug.Log("Pressione E para se esconder.");

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o objeto que saiu é o jogador
        if (other.CompareTag("Player"))
        {
            playerPodeEsconder = false;
            // Se o jogador sair do trigger, garanta que ele volte a ser visível
            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.enabled = true;
            }
            Debug.Log("Você saiu do esconderijo.");
        }
    }

    void Update()
    {
        // Verifica se o jogador pode se esconder e se a tecla de interação (ex: E) foi pressionada
        if (playerPodeEsconder && Input.GetKeyDown(KeyCode.E))
        {
            EsconderJogador();
        

        }
        // Opcional: Adicionar uma forma de sair do esconderijo (ex: pressionar E novamente ou mover)
        // O exemplo abaixo usa a mesma tecla para alternar visibilidade
        if (Input.GetKeyDown(KeyCode.E) && playerSpriteRenderer != null && !playerPodeEsconder)
        {
            SairDoEsconderijo();
            
        }
    }

    void EsconderJogador()
    {
        // Torna o sprite do jogador invisível
        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.enabled = false;
            
            // Desativar movimento do jogador ou outras lógicas de jogo podem ser adicionadas aqui
        }
    }

    void SairDoEsconderijo()
    {
        // Torna o sprite do jogador visível novamente
        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.enabled = true;
            // Reativar movimento do jogador ou outras lógicas de jogo podem ser adicionadas aqui
        }
    }
}
