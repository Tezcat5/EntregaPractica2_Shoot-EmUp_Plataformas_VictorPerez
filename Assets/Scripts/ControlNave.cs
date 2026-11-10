using UnityEngine;

public class ControlNave : MonoBehaviour
{
    [SerializeField] private float velocidad = 6f;

    void Update()
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
}