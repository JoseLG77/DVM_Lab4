using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsSceneManager : MonoBehaviour
{
    public Button volverAlMenuButton;  
    public Button volverAJugarButton;  

    void Start()
    {

        volverAlMenuButton.onClick.AddListener(IrAlMenu);
        volverAJugarButton.onClick.AddListener(VolverAJugar);
    }

    void IrAlMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    void VolverAJugar()
    {
        SceneManager.LoadScene("Game");  
    }
}
