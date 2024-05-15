using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Méthode pour charger la scène de jeu
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_scene");
    }

    // Méthode pour quitter l'application
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Si vous êtes dans l'éditeur Unity
#else
        Application.Quit(); // Si vous exportez votre jeu
#endif
    }
}
