using UnityEngine;

public class PlayerCosmic : MonoBehaviour
{
    [SerializeField] AudioSource collectCosmic;
    [SerializeField] AudioSource hitCosmic;

    [SerializeField] GameCosmic gameCosmic;
    private float posCosmic = 0;
    public float Pos { get { return posCosmic; } set { posCosmic = value;
            posCosmic = Mathf.Min(posCosmic, 2.49f);
            posCosmic = Mathf.Max(posCosmic, -2.49f);
        } }

    void Update()
    {
        transform.position = new Vector3 (posCosmic, transform.position.y*1, transform.position.z*1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Heart")
        {
            if(PlayerPrefs.GetInt("soundsCosmic", 1) == 1) collectCosmic.Play();
            gameCosmic.countCosmic++;
            Destroy(collision.gameObject);  
        } else
        {
            if(PlayerPrefs.GetInt("soundsCosmic", 1) == 1) hitCosmic.Play();
            gameCosmic.attack();
            Destroy(collision.gameObject);
        }
    }
}
