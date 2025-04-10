using UnityEngine;
using UnityEngine.Events;


public class ColorController : MonoBehaviour
{
    public Color[] coloresDisponibles = { Color.yellow, Color.red, Color.green };
    public int colorActual = 0;

    public UnityEvent<Color> OnColorChanged;
    private SpriteRenderer spriteRenderer;
    private PlayerController player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerController>();
        CambiarColor(0); 
    }

    public void CambiarColorIzquierda()
    {
        if (!player.EstaColisionandoConObstaculo)
        {
            colorActual = (colorActual - 1 + coloresDisponibles.Length) % coloresDisponibles.Length;
            CambiarColor(colorActual);
        }
    }

    public void CambiarColorDerecha()
    {
        if (!player.EstaColisionandoConObstaculo)
        {
            colorActual = (colorActual + 1) % coloresDisponibles.Length;
            CambiarColor(colorActual);
        }
    }

    void CambiarColor(int index)
    {
        Color nuevoColor = coloresDisponibles[index];
        spriteRenderer.color = nuevoColor;

        if (OnColorChanged != null)
            OnColorChanged.Invoke(nuevoColor);
    }
}

