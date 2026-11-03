using UnityEngine;

public class BalaExplosivaBehaviour : MonoBehaviour
{
    [SerializeField] private float velocidadBala = 8f;
    [SerializeField] private float radioExplosion = 3f;
    [SerializeField] private LayerMask capaEnemigos;

    void Update()
    {
        transform.Translate(Vector3.right * velocidadBala * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Explotar();
        }
    }

    private void Explotar()
    {
        Collider2D[] enemigosAfectados = Physics2D.OverlapCircleAll(transform.position, radioExplosion, capaEnemigos);
        
        foreach (Collider2D enemigo in enemigosAfectados)
        {
            Destroy(enemigo.gameObject);
        }

        Destroy(gameObject);
    }
}