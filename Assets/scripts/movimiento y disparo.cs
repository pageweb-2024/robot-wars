using UnityEngine;
using Mirror;

public class RobotMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public Transform gunLeft;   // Transform del brazo izquierdo (pistola)
    public Transform gunRight;  // Transform del brazo derecho (pistola)
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    private void Update()
    {
        // Asegurarse de que solo el jugador local controle el movimiento y disparos.
        if (!isLocalPlayer)
            return;

        // Movimiento con las teclas A, W, S, D
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Disparo con clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            CmdShoot();
        }
    }

    [Command] // Método llamado desde el cliente, ejecutado en el servidor
    void CmdShoot()
    {
        // Disparo del arma izquierda
        GameObject bulletLeft = Instantiate(bulletPrefab, gunLeft.position, gunLeft.rotation);
        bulletLeft.GetComponent<Rigidbody>().velocity = gunLeft.forward * bulletSpeed;
        NetworkServer.Spawn(bulletLeft);

        // Disparo del arma derecha
        GameObject bulletRight = Instantiate(bulletPrefab, gunRight.position, gunRight.rotation);
        bulletRight.GetComponent<Rigidbody>().velocity = gunRight.forward * bulletSpeed;
        NetworkServer.Spawn(bulletRight);
    }
}
