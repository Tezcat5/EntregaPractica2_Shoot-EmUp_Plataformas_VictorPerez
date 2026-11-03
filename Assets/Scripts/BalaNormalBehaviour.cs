using UnityEngine;

public class BalaNormalBehaviour : MonoBehaviour
{
    [SerializeField] private float velocidadBala = 15f;
    [SerializeField] private float tiempoVida = 3f;

    void Update()
    {
        transform.Translate(Vector3.right * velocidadBala * Time.deltaTime);
        tiempoVida -= Time.deltaTime;
        if (tiempoVida <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}