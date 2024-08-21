using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsCosmic : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    void Start()
    {
        int levelsCosmic = PlayerPrefs.GetInt("currentCosmic", 0);
        for (int it1cyber = 0; it1cyber < buttons.Length; it1cyber++) buttons[it1cyber].interactable = it1cyber <= levelsCosmic;
    }

    public void openGame1()
    {
        openCosmicGame(0);
        SceneManager.LoadSceneAsync(4);
    }
    public void openGame2()
    {
        openCosmicGame(1);
        SceneManager.LoadSceneAsync(4);
    }
    public void openGame3()
    {
        openCosmicGame(2);
        SceneManager.LoadSceneAsync(4);
    }
    public void openGame4()
    {
        openCosmicGame(3);
        SceneManager.LoadSceneAsync(4);
    }
    public void openGame5()
    {
        openCosmicGame(4);
        SceneManager.LoadSceneAsync(4);
    }
    public void openGame6()
    {
        openCosmicGame(5);
        SceneManager.LoadSceneAsync(4);
    }

    private void openCosmicGame(int level)
    {
        PlayerPrefs.SetInt("levelCosmic", level);
        PlayerPrefs.Save();

    }
}
