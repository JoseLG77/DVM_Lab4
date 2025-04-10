using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto;  

    void Start()
    {
        float tiempoNivel = PlayerPrefs.GetFloat("TiempoNivel", 0f);

        int minutos = Mathf.FloorToInt(tiempoNivel / 60);
        int segundos = Mathf.FloorToInt(tiempoNivel % 60);

        tiempoTexto.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);
    }
}
