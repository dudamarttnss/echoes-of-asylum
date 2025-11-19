using UnityEngine;

public class InimigoArremessador : MonoBehaviour
{
    public Transform player;             // Referência ao Player
    public Transform pontoLancamento;    // Onde o objeto é lançado
    public GameObject prefabPedra;       // Prefab da pedra ou objeto
    public float forcaHorizontal = 20f;  // Força pra frente
    public float forcaVertical = 8f;     // Força pra cima
    public float intervalo = 3f;         // Tempo entre arremessos

    private float proximoArremesso;

    void Update()
    {
        if (player == null) return;

        // Checa se é hora de arremessar novamente
        if (Time.time >= proximoArremesso)
        {
            ArremessarParabolico();
            proximoArremesso = Time.time + intervalo;
        }
    }

    void ArremessarParabolico()
    {
        // Cria a pedra
        GameObject pedra = Instantiate(prefabPedra, pontoLancamento.position, Quaternion.identity);
        Rigidbody rb = pedra.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Calcula direção para o player
            Vector3 direcao = (player.position - pontoLancamento.position).normalized;

            // Adiciona força horizontal (para frente)
            Vector3 forca = direcao * forcaHorizontal;

            // Adiciona força vertical (para cima)
            forca.y = forcaVertical;

            // Aplica a força de impulso
            rb.AddForce(forca, ForceMode.Impulse);
        }

        Debug.Log("Arremesso parabólico executado!");


        
       
    }
}

