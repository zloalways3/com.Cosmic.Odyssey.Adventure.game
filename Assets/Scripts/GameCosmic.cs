using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCosmic : MonoBehaviour
{
    private bool leftCosmic;
    private bool rightCosmic;
    [SerializeField] PlayerCosmic playerScriptCosmic;
    [SerializeField] Text scoreTextCosmic;
    [SerializeField] GameObject heartPrefabCosmic;
    [SerializeField] GameObject bombPrefabCosmic;
    float timeCosmic = 90;
    public int countCosmic = 0;
    float timerSpawnCosmic = 0;
    private bool invalCosmic = true;
    private float speedCosmic = 0.15f;
    int lives = 3;
    [SerializeField] Text timerCosmic;
    [SerializeField] GameObject[] heartsCosmic;
    [SerializeField] AudioSource musicCosmic;

    void Start()
    {
        timeCosmic = 60 + PlayerPrefs.GetInt("levelCosmic", 0) * 20;
        if (PlayerPrefs.GetInt("musicCosmic", 1) == 1) musicCosmic.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(invalCosmic)
        {
            timeCosmic -= Time.deltaTime;
            if (timeCosmic <= 0) endCosmic();
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);
            }
            if (Time.timeSinceLevelLoad > timerSpawnCosmic)
            {
                timerSpawnCosmic += Random.Range(0.3f, 1.2f);
                int randomCosmic = Random.Range(-10, 25);
                GameObject heartCosmic = Instantiate(randomCosmic >= 0 ? heartPrefabCosmic : bombPrefabCosmic, transform, true);
                heartCosmic.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), 6, 0);
            }
            timerCosmic.text = ((int)timeCosmic / 60).ToString("D2") + ":" + ((int)timeCosmic % 60).ToString("D2");
            for (int itcosmic = 0; itcosmic < heartsCosmic.Length; itcosmic++) heartsCosmic[itcosmic].SetActive(itcosmic < lives);
            scoreTextCosmic.text = $"SCORE: {countCosmic}";
            if (leftCosmic)
            {
                playerScriptCosmic.Pos -= speedCosmic;
            }
            else if (rightCosmic)
            {
                playerScriptCosmic.Pos += speedCosmic;
            }
        }
    }

    public void levelDownCosmic()
    {
        leftCosmic = true;
        rightCosmic = false;
    }
    public void levelUpCosmic()
    {
        leftCosmic = false;
    }

    public void rightDownCosmic()
    {
        rightCosmic = true;
        leftCosmic = false;
    }
    public void rightUpCosmic() { 
        rightCosmic = false;
    }

    public void endCosmic()
    {
        invalCosmic = false;
        if (lives == 0) EndCosmic.WIN_COSMIC = 0;
        else EndCosmic.WIN_COSMIC = 1;
        int currentCosmic = PlayerPrefs.GetInt("currentCosmic", 0);
        int levelCosmic = PlayerPrefs.GetInt("levelCosmic", 0);
        if(lives>0)
        {
            if(currentCosmic==levelCosmic)
            {
                currentCosmic++;
                currentCosmic = Mathf.Min(5, currentCosmic);
                PlayerPrefs.SetInt("currentCosmic", currentCosmic);
                PlayerPrefs.Save();
            }
        }
        goEndCosmic();
    }

    private void goEndCosmic()
    {
        EndCosmic.SCORE_COSMIC = countCosmic;
        SceneManager.LoadScene(5);
    }


    public void attack()
    {
        lives--;
        if(lives<=0)
        {
            endCosmic();
        }
    }

}
