using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene("Game");
    }

    void CerrarJuego()
    {
        Application.Quit();  
    }
}


