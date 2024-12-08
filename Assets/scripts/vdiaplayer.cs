using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class vdiaplayer : NetworkBehaviour
{
    [SyncVar] // Sincroniza la vida entre el servidor y los clientes
    public float vida = 100;

    public Image barradevida;

    void Update()
    {
        if (isLocalPlayer) // Solo actualiza la barra de vida en el cliente local
        {
            vida = Mathf.Clamp(vida, 0, 100);
            barradevida.fillAmount = vida / 100;
        }
    }

    // Método para cambiar la vida desde el servidor
    [Command]
    public void CmdCambiarVida(float cantidad)
    {
        // Solo el servidor puede cambiar la vida
        vida += cantidad;
        vida = Mathf.Clamp(vida, 0, 100);
    }

    // Método que se puede invocar en el servidor para recuperar vida
    public void CambiarVida(float cantidad)
    {
        if (isServer)
        {
            vida += cantidad;
            vida = Mathf.Clamp(vida, 0, 100);
        }
        else
        {
            CmdCambiarVida(cantidad); // Llamada al comando si no es el servidor
        }
    }
}
