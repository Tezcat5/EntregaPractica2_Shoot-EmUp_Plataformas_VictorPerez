using UnityEngine;

public class LimitesPantalla : MonoBehaviour
{
    private Camera camaraPrincipal;
    private float mitadAnchoBarco;
    private float mitadAltoBarco;

    void Start()
    {
        camaraPrincipal = Camera.main;
        SpriteRenderer rendererBarco = GetComponent<SpriteRenderer>();
        
        if (rendererBarco != null)
        {
            mitadAnchoBarco = rendererBarco.bounds.extents.x;
            mitadAltoBarco = rendererBarco.bounds.extents.y;
        }
    }

    void Update()
    {
        Vector3 posicionBarco = transform.position;
        Vector3 limiteInferiorIzquierda = camaraPrincipal.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 limiteSuperiorDerecha = camaraPrincipal.ViewportToWorldPoint(new Vector3(1, 1, 0));

        posicionBarco.x = Mathf.Clamp(posicionBarco.x, limiteInferiorIzquierda.x + mitadAnchoBarco, limiteSuperiorDerecha.x - mitadAnchoBarco);
        posicionBarco.y = Mathf.Clamp(posicionBarco.y, limiteInferiorIzquierda.y + mitadAltoBarco, limiteSuperiorDerecha.y - mitadAltoBarco);

        transform.position = posicionBarco;
    }
}