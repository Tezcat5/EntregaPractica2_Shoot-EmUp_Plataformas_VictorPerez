using UnityEngine;

public class ControlNave : MonoBehaviour
{
    [SerializeField] private float velocidad = 6f;
    [SerializeField] private GameObject proyectilNormalPrefab;
    [SerializeField] private GameObject proyectilExplosivoPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float velocidadProyectil = 12f;
    [SerializeField] private float cadenciaDisparo = 0.2f;
    private float tiempoUltimoDisparo = 0f;
    [SerializeField] private float energiaActual = 0f;
    [SerializeField] private float energiaMaxima = 100f;
    [SerializeField] private float cargaPorDisparoNormal = 10f;

    void Update()
    {
        MovimientoNave();
        GestionarDisparo();
    }

    void MovimientoNave()
    {
        float moverX = 0f;
        float moverY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moverY = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moverY = -1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moverX = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moverX = 1f;

        Vector2 movimiento = new Vector2(moverX, moverY).normalized * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
    }

    void GestionarDisparo()
    {
        if (Time.time >= tiempoUltimoDisparo + cadenciaDisparo)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                DispararNormal();
                tiempoUltimoDisparo = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.F) && energiaActual >= energiaMaxima)
            {
                DispararExplosivo();
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    void DispararNormal()
    {
        if (proyectilNormalPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(proyectilNormalPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(velocidadProyectil, 0f);
            }

            energiaActual += cargaPorDisparoNormal;
            energiaActual = Mathf.Clamp(energiaActual, 0f, energiaMaxima);
        }
    }

    void DispararExplosivo()
    {
        if (proyectilExplosivoPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(proyectilExplosivoPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(velocidadProyectil * 1.2f, 0f);
            }

            energiaActual = 0f;
        }
    }
}