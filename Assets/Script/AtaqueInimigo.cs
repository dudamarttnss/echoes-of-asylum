using UnityEngine;
using System.Collections;

public class AtaqueInimigo : MonoBehaviour
{

    public GameObject raioLaser;
    public GameObject player;
    public Transform posicaoDoPlayer;
    public Transform rotacaoDoPlayer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Transform posicaoAtualDoPlayer = player.transform;
            posicaoDoPlayer = posicaoAtualDoPlayer;
            Quaternion rotacaoDoPlayer = player.transform.rotation;

            // Chama a coroutine com esses valores
            StartCoroutine(TempoDeRecargaAtaqueLaser());
        }
    }

    public void AtaqueLaser()
    {
        
        Instantiate(raioLaser, posicaoDoPlayer, rotacaoDoPlayer);
    }

    IEnumerator TempoDeRecargaAtaqueLaser()
    {
        Debug.Log("inicia contagem");
        yield return new WaitForSeconds(3f); // Pause for 3 secondss
        Debug.Log("Coroutine resumed after 3 seconds!");
        AtaqueLaser();
        yield return null; // Pause until the next frame
        Debug.Log("Coroutine resumed on the next frame!");
    }
}
