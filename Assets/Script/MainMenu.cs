using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�thode pour charger la sc�ne de jeu
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_scene");
    }

    // M�thode pour quitter l'application
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Si vous �tes dans l'�diteur Unity
#else
        Application.Quit(); // Si vous exportez votre jeu
#endif
    }
}
