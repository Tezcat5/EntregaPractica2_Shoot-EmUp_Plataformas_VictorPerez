using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float posicionX;
    [SerializeField] private float velocidadParallax;
    private Transform camaraPrincipal;

    void Start()
    {
        camaraPrincipal = Camera.main.transform;
        posicionX = transform.position.x;
    }

    void Update()
    {
        float distanciaRecorrida = camaraPrincipal.transform.position.x * velocidadParallax;
        transform.position = new Vector3(posicionX + distanciaRecorrida, transform.position.y, transform.position.z);
    }
}