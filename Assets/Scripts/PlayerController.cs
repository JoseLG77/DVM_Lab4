using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocity = 5f;
    private float fuerzaSalto = 8f;
    private int saltosDisponibles = 2;

    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    public HealthManager healthManager;
    public GameManager gameManager;
    public bool EstaColisionandoConObstaculo { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
        Vector3 position = transform.position;
        transform.position = new Vector3(velocidadX + position.x, position.y, position.z);

        if (Input.GetKeyDown(KeyCode.Space) && saltosDisponibles > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltosDisponibles--;
        }

        VerificarSiTocaSuelo();
    }

    void VerificarSiTocaSuelo()
    {
        Vector2 origen = new Vector2(transform.position.x, transform.position.y - circleCollider.radius - 0.05f);
        float distancia = 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.down, distancia);
        Debug.DrawRay(origen, Vector2.down * distancia, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Suelo") && rb.linearVelocity.y <= 0)
        {
            saltosDisponibles = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            if (healthManager != null)
            {
                healthManager.VerificarColisionConObstaculo(other.gameObject);
            }

            EstaColisionandoConObstaculo = true;
        }
        if (other.CompareTag("Goal"))
        {
            gameManager.TerminarNivel();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            EstaColisionandoConObstaculo = false;
        }
    }

    private void FixedUpdate()
    {

    }
}
