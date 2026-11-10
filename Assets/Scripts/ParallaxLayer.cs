using UnityEngine;

/// <summary>
/// Capa de fondo con parallax y bucle infinito sin costuras.
/// Crea en tiempo de ejecución una copia de la capa colocada justo a su derecha y las recoloca
/// cuando la cámara ha avanzado un ancho completo.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxLayer : MonoBehaviour
{
    [Tooltip("0 = fija en el mundo (capa cercana, se mueve rápido en pantalla). 1 = pegada a la cámara (capa lejanísima, no se mueve en pantalla).")]
    [Range(0f, 1f)]
    [SerializeField] private float seguimientoCamara = 0.5f;
    [SerializeField] private Camera camara;

    private Transform copia;
    private float inicioX;   // posición X base de la capa (se desplaza de ancho en ancho)
    private float ancho;     // ancho de la capa en unidades de mundo

    private void Awake()
    {
        if (camara == null) camara = Camera.main;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        ancho = sr.bounds.size.x;
        inicioX = transform.position.x;

        // Copia visual para cubrir el hueco a la derecha.
        GameObject go = new GameObject(name + "_Copia");
        go.transform.SetParent(transform.parent, false);
        go.transform.localScale = transform.localScale;
        SpriteRenderer c = go.AddComponent<SpriteRenderer>();
        c.sprite = sr.sprite;
        c.sharedMaterial = sr.sharedMaterial;
        c.color = sr.color;
        c.flipX = sr.flipX;
        c.flipY = sr.flipY;
        c.sortingLayerID = sr.sortingLayerID;
        c.sortingOrder = sr.sortingOrder;
        copia = go.transform;
    }

    private void LateUpdate()
    {
        if (camara == null) return;

        float camX = camara.transform.position.x;
        float sinParallax = camX * (1f - seguimientoCamara); // desplazamiento "sin mover" de la capa
        float conParallax = camX * seguimientoCamara;        // desplazamiento que sigue a la cámara

        // Reposicionamos la base cuando la capa se ha desplazado un ancho completo respecto a la cámara.
        if (sinParallax > inicioX + ancho) inicioX += ancho;
        else if (sinParallax < inicioX - ancho) inicioX -= ancho;

        Vector3 pos = transform.position;
        pos.x = inicioX + conParallax;
        transform.position = pos;

        Vector3 posCopia = pos;
        posCopia.x += ancho;
        copia.position = posCopia;
    }
}
