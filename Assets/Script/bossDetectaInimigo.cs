using UnityEngine;

public class bossDetectaInimigo : MonoBehaviour
{
    public Transform player;              // referência ao player
    public float detectionDistance = 5f;  // distância máxima para detectar

    private bool playerDetected = false;
    private Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        // Calcula a distância entre inimigo e player
        float distance = Vector2.Distance(transform.position, player.position);

        // Verifica se o player está dentro da distância de detecção
        if (distance <= detectionDistance)
        {
            if (!playerDetected)
            {
                playerDetected = true;

                Debug.Log("Player detectado!");
                animator.Play("ataqueRaiosUm");
            }
        }
        else
        {
            if (playerDetected)
            {
                playerDetected = false;
                Debug.Log("Player fora de alcance!");
                animator.Play("PareAGORA");
            }
        }
    }

    // Método para checar externamente se o player está detectado
    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}
