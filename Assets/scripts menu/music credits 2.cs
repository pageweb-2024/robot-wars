using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicController : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CreditsScene") // Cambia "CreditsScene" por el nombre de tu escena
        {
            // Configura m�sica para los cr�ditos
            PlayCreditsMusic();
        }
        else
        {
            // Det�n m�sica o cambia a otra m�sica seg�n la escena
            StopCreditsMusic();
        }
    }

    private void PlayCreditsMusic()
    {
        // L�gica para iniciar la m�sica de cr�ditos
    }

    private void StopCreditsMusic()
    {
        // L�gica para detener la m�sica de cr�ditos
    }
}
