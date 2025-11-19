using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AplicadorDano : MonoBehaviour
{
    public int dano = 50;
    public float tempoAtaque = 1.0f;
    private float tempoUltimoAtaque = -999f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time - tempoUltimoAtaque < tempoAtaque) return;

        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph != null && !ph.vcDead)
        {
            tempoUltimoAtaque = Time.time;
            ph.TakeDamage(dano);
            
        }
    }
}
