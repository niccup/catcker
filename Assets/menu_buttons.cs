using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_buttons : MonoBehaviour
{

    [SerializeField] private string gameSceneName;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
