using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCosmic : MonoBehaviour
{
    public static int WIN_COSMIC = 0, SCORE_COSMIC = 0;

    [SerializeField] Image[] starsCosmic;
    [SerializeField] Sprite onCosmic;
    [SerializeField] Sprite offCosmic;
    [SerializeField] Image repeatCosmic;
    [SerializeField] Sprite nextCosmicSprite;
    [SerializeField] Sprite repeatCosmicSprite;
    [SerializeField] Text labelCosmic;
    [SerializeField] Text labelScoreCosmic;


    void Start()
    {
        if(WIN_COSMIC==1)
        {
            if (SCORE_COSMIC >= 100) starsCosmic[2].sprite = onCosmic;
            if (SCORE_COSMIC >= 50) starsCosmic[1].sprite = onCosmic;
            if (SCORE_COSMIC >= 0) starsCosmic[0].sprite = onCosmic;
            repeatCosmic.sprite = nextCosmicSprite;
            labelScoreCosmic.text = SCORE_COSMIC.ToString();
            labelCosmic.text = "YOUR SCORE";
        } else
        {
            for (int cosmic = 0; cosmic < starsCosmic.Length; cosmic++) starsCosmic[cosmic].sprite = offCosmic;
            repeatCosmic.sprite = repeatCosmicSprite;
            labelScoreCosmic.text = "";
            labelCosmic.text = "YOU LOSE ALL STAR LIVES";
        }
    }

    public void endCosmic()
    {
        if(WIN_COSMIC==1)
        {
            PlayerPrefs.SetInt("levelCosmic", Mathf.Min(5, PlayerPrefs.GetInt("levelCosmic", 0) + 1));
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(4);
        }
        else
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
   
}
