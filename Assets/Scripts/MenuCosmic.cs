using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCosmic : MonoBehaviour
{
    public void quitCosmic() {
        Application.Quit();
    }
    public void openGameCosmic()
    {
        SceneManager.LoadSceneAsync(3);
    }

}
