using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 1f;

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
        if (transform.position.x >= 117)
        {
            movingSpeed = 0f;
        }
    }
}