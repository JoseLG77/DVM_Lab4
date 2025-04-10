using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Button startButton;  
    public Button quitButton;   

    void Start()
    {
        startButton.onClick.AddListener(CargarJuego);
        quitButton.onClick.AddListener(CerrarJuego);
    }

    void CargarJuego()
    {
        Application.LoadLevel("Game");  
    }

    void CerrarJuego()
    {
        Application.Quit();  
    }
}


