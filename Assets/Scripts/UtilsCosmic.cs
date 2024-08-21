using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilsCosmic : MonoBehaviour
{
    public static void openSettings()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public static void GoHome()
    {
        SceneManager.LoadSceneAsync(menu_cosmic);
    }

    private static int menu_cosmic = 1;
}
