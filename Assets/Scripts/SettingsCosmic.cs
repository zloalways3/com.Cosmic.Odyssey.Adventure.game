using UnityEngine;

public class SettingsCosmic : MonoBehaviour
{

    [SerializeField] UISwitcherCosmic.UISwitcherCosmic soundsCosmic;
    [SerializeField] UISwitcherCosmic.UISwitcherCosmic musiccosmic;

    // Start is called before the first frame update
    void Start()
    {
        soundsCosmic.isOn = PlayerPrefs.GetInt("soundsCosmic", 1) == 1;
        musiccosmic.isOn = PlayerPrefs.GetInt("musicCosmic", 1) == 1;

    }

    public void soundsChangeCosmic(bool change)
    {
        PlayerPrefs.SetInt("soundsCosmic", soundsCosmic.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void musicChangeCosmic(bool change)
    {
        PlayerPrefs.SetInt("musicCosmic", musiccosmic.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
