using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int saude = 100;
    public int saudeAtual;
    public bool vcDead { get; private set; }

    void Awake()
    {
        saudeAtual = saude;
        vcDead = false;
    }


    public void TakeDamage(int amount)
    {
        if (vcDead) return;
        saudeAtual -= amount;
        saudeAtual = Mathf.Max(saudeAtual, 0);
        Debug.Log($"Player took {amount} damage. HP = {saudeAtual}/{saude}");
        if (saudeAtual <= 0) Morte();
    }

    void Morte()
    {
        vcDead = true;
        Debug.Log("Mara morreu.");
        gameObject.SetActive(false);
       
    }
}
