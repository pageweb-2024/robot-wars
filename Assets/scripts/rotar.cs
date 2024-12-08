using UnityEngine;

public class RotacionHorizontal : MonoBehaviour
{
    public float sensibilidadMouse = 100f;

    void Update()
    {
        // Obt�n el movimiento horizontal del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        // Aplica la rotaci�n en el eje Y
        transform.Rotate(0f, mouseX, 0f);
    }
}
