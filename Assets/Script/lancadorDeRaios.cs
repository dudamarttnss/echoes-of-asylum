using Unity.Mathematics;
using UnityEngine;

public class lancadorDeRaios : MonoBehaviour
{

    public Raio raio;
    public int quantidadeDeRaios = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void lancarRaios(float anguloZ)
    {
        Quaternion Direcao = Quaternion.AngleAxis(anguloZ, Vector3.forward);
        Instantiate(raio, transform.position, Direcao);
    }


    public void lancarVariosRaios()
    {
        for (int i = 0; i < quantidadeDeRaios; i++)
        {
            // float aleatorio = UnityEngine.Random.Range(0, 360);
            // lancarRaios(aleatorio);
            float anguloIndividual = 180/quantidadeDeRaios;
            lancarRaios(anguloIndividual*i+ 90);
        }
    }

}
