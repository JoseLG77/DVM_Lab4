using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float desplazamientoX = 0f;
    public float desplazamientoY = 0f;
    public float velocidad = 2f;

    private Vector3 puntoInicio;
    private Vector3 puntoDestino;
    private bool yendoADestino = true;
    private bool estaDetenido = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        puntoInicio = transform.position;
        puntoDestino = puntoInicio + new Vector3(desplazamientoX, desplazamientoY, 0f);
        spriteRenderer = GetComponent<SpriteRenderer>();

        ColorController playerColor = FindFirstObjectByType<ColorController>();
        if (playerColor != null)
        {
            playerColor.OnColorChanged.AddListener(ManejarCambioColor);
        }
    }

    void Update()
    {
        if (estaDetenido) return;

        Vector3 objetivo = yendoADestino ? puntoDestino : puntoInicio;
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo) < 0.01f)
        {
            yendoADestino = !yendoADestino;
        }
    }

    void ManejarCambioColor(Color colorJugador)
    {
        estaDetenido = (spriteRenderer.color == colorJugador);
    }
}
