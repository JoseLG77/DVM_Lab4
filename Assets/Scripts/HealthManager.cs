using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int vida = 10;
    public TextMeshProUGUI healthText;
    public SpriteRenderer playerSprite;

    void Start()
    {
        ActualizarTextoVida();
    }

    public void VerificarColisionConObstaculo(GameObject obstaculo)
    {
        SpriteRenderer obstaculoSprite = obstaculo.GetComponent<SpriteRenderer>();

        if (obstaculoSprite != null && obstaculoSprite.color != playerSprite.color)
        {
            vida--;
            ActualizarTextoVida();

            if (vida <= 0)
            {
                ReiniciarNivel();
            }
        }
    }

    void ActualizarTextoVida()
    {
        if (healthText != null)
        {
            healthText.text = vida.ToString();
        }
    }

    void ReiniciarNivel()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.TerminarNivel();  
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
