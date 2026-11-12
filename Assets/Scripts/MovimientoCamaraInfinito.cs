using UnityEngine;

public class MovimientoCamaraInfinito : MonoBehaviour
{
    [SerializeField] private float velocidadScroll = 2f;

    void Update()
    {
        transform.Translate(Vector3.right * velocidadScroll * Time.deltaTime);
    }
}