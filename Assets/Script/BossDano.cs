using UnityEngine;

public class BossDano : MonoBehaviour
{
    public GameObject[] listaDeBuracos;
    public int numeroAleatorio;
    public int numeroAtual;
    public GameObject prefabDoBuraco;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CriaBuracos()
    {
        numeroAleatorio = Random.Range(0, 7);
        numeroAtual = numeroAleatorio;
        Instantiate(prefabDoBuraco, listaDeBuracos[numeroAleatorio].transform.position, Quaternion.identity);


        numeroAleatorio = Random.Range(0, 7);
        if (numeroAleatorio == numeroAtual)
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[0].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[numeroAleatorio].transform.position, Quaternion.identity);
        }

        numeroAleatorio = Random.Range(0, 7);
        if (numeroAleatorio == numeroAtual)
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[1].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[2].transform.position, Quaternion.identity);
        }

        if (numeroAleatorio == numeroAtual)
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[3].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[4].transform.position, Quaternion.identity);
        }

        if (numeroAleatorio == numeroAtual)
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[5].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[6].transform.position, Quaternion.identity);
        }

        if (numeroAleatorio == numeroAtual)
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[7].transform.position, Quaternion.identity);
        }
       else
        {
            Instantiate(prefabDoBuraco, listaDeBuracos[8].transform.position, Quaternion.identity);
        }

    }
    
}
