using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.EventSystems; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;  
    public Button yellowButton;
    public Button redButton;
    public Button greenButton;
    public TextMeshProUGUI cronometroText;  

    private SpriteRenderer playerSpriteRenderer;
    private PlayerController playerController;

    private float tiempoTranscurrido = 0f;  
    private bool nivelTerminado = false;

    void Start()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerController = player.GetComponent<PlayerController>();

        yellowButton.onClick.AddListener(CambiarColorAmarillo);
        redButton.onClick.AddListener(CambiarColorRojo);
        greenButton.onClick.AddListener(CambiarColorVerde);
    }

    void Update()
    {
        if (!nivelTerminado)
        {
            tiempoTranscurrido += Time.deltaTime;  
            ActualizarTextoCronometro();
        }
    }

    void ActualizarTextoCronometro()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);

        cronometroText.text = string.Format("{0:00}:{1:00}", minutos, segundos);  
    }

    public void TerminarNivel()
    {
        nivelTerminado = true;

        PlayerPrefs.SetFloat("TiempoNivel", tiempoTranscurrido);

        SceneManager.LoadScene("Results");
    }

    void CambiarColorAmarillo()
    {
        if (!playerController.EstaColisionandoConObstaculo)
            playerSpriteRenderer.color = Color.yellow;
    }

    void CambiarColorRojo()
    {
        if (!playerController.EstaColisionandoConObstaculo)
            playerSpriteRenderer.color = Color.red;
    }

    void CambiarColorVerde()
    {
        if (!playerController.EstaColisionandoConObstaculo)
            playerSpriteRenderer.color = Color.green;
    }

}
