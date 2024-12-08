using Mirror;
using UnityEngine;

public class Shooting : NetworkBehaviour
{
    public GameObject projectilePrefab; // Prefab asignado en el Inspector

    [Command] // Este método se ejecuta en el servidor
    void CmdFire()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);

        
        NetworkServer.Spawn(projectile);
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetButtonDown("Fire1")) 
        {
            CmdFire();
        }
    }
}
