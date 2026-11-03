using UnityEngine;

public class ControlNave : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;

    void Update()
    {
        float moverX = Input.GetAxis("Horizontal");
        float moverY = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(moverX, moverY) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
    }
}