using UnityEngine;

public class SistemaDisparoBarco : MonoBehaviour
{
    [SerializeField] private GameObject prefabBalaNormal;
    [SerializeField] private GameObject prefabBalaExplosiva;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float tiempoEntreDisparos = 0.15f;
    [SerializeField] private float cooldownExplosivo = 2f;

    private float siguienteDisparoNormal = 0f;
    private float siguienteDisparoExplosivo = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= siguienteDisparoNormal)
        {
            DispararRafaga();
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.time >= siguienteDisparoExplosivo)
        {
            DispararExplosivo();
        }
    }

    private void DispararRafaga()
    {
        siguienteDisparoNormal = Time.time + tiempoEntreDisparos;
        Instantiate(prefabBalaNormal, puntoDisparo.position, Quaternion.identity);
    }

    private void DispararExplosivo()
    {
        siguienteDisparoExplosivo = Time.time + cooldownExplosivo;
        Instantiate(prefabBalaExplosiva, puntoDisparo.position, Quaternion.identity);
    }
}