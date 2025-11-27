using UnityEngine;

[AddComponentMenu("Maria/scripts")]
public class inimigoArremessaCoisas : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform throwPoint; // Posição de onde o projétil sai
    public float throwForce = 10f; // Força do arremesso
    public float fireRate = 2f; // Tempo entre arremessos

    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Throw();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Throw()
    {
       Vector2 direcao = (player.position - throwPoint.position).normalized;

    int quantidadeProjeteis = 5; // número de projéteis
    float espalhamento = 10f;     // diferença de ângulo entre cada projétil

    for (int i = 0; i < quantidadeProjeteis; i++)
    {
        // cria o projétil
        GameObject proj = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);

        // calcula o ângulo base em direção ao player
        float anguloPlayer = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        // calcula o ângulo do projétil atual, centralizando o leque
        float anguloProj = anguloPlayer + espalhamento * (i - (quantidadeProjeteis - 1) / 2f);

        // converte o ângulo de volta para vetor 2D
        Vector2 direcaoProj = new Vector2(Mathf.Cos(anguloProj * Mathf.Deg2Rad), Mathf.Sin(anguloProj * Mathf.Deg2Rad));

        // aplica força ao projétil
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.AddForce(direcaoProj.normalized * throwForce, ForceMode2D.Impulse);
}





    }

}