using UnityEngine;

public class LimitesPantalla : MonoBehaviour
{
    private Camera camaraPrincipal;
    private float mitadAnchoSprite;
    private float mitadAltoSprite;

    void Start()
    {
        camaraPrincipal = Camera.main;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            mitadAnchoSprite = spriteRenderer.bounds.extents.x;
            mitadAltoSprite = spriteRenderer.bounds.extents.y;
        }
    }

    void LateUpdate()
    {
        if (camaraPrincipal == null) return;

        Vector3 esquinaInferiorIzquierda = camaraPrincipal.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 esquinaSuperiorDerecha = camaraPrincipal.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        float minX = esquinaInferiorIzquierda.x + mitadAnchoSprite;
        float maxX = esquinaSuperiorDerecha.x - mitadAnchoSprite;
        float minY = esquinaInferiorIzquierda.y + mitadAltoSprite;
        float maxY = esquinaSuperiorDerecha.y - mitadAltoSprite;

        Vector3 posicion = transform.position;
        posicion.x = Mathf.Clamp(posicion.x, minX, maxX);
        posicion.y = Mathf.Clamp(posicion.y, minY, maxY);
        transform.position = posicion;
    }
}