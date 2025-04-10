using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float desplazamientoX = 0f;
    public float desplazamientoY = 0f;
    public float velocidad = 2f;

    private Vector3 puntoInicio;
    private Vector3 puntoDestino;
    private bool yendoADestino = true;

    void Start()
    {
        puntoInicio = transform.position;

        puntoDestino = puntoInicio + new Vector3(desplazamientoX, desplazamientoY, 0f);
    }

    void Update()
    {
        Vector3 objetivo = yendoADestino ? puntoDestino : puntoInicio;

        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo) < 0.01f)
        {
            yendoADestino = !yendoADestino;
        }
    }
}
