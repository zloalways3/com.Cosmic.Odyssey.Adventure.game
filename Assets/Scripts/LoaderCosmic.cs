using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderCosmic : MonoBehaviour
{
    [SerializeField] ProgressBarCosmic progressBarCosmic;
    float CosmicTimer = 0;

    void Update()
    {
        if(Time.timeSinceLevelLoad>=CosmicTimer)
        {
            CosmicTimer = CosmicTimer +  0.03f;
            progressBarCosmic.BarValue+=1;
        }
        if(progressBarCosmic.BarValue==100)
        {
            SceneManager.LoadScene(1);
        }
    }
}
