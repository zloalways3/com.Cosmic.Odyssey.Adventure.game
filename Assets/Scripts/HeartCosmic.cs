using UnityEngine;

public class HeartCosmic : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D bodyCosmic;
    [SerializeField] Sprite[] bombsCosmic;
    void Start()
    {
        bodyCosmic = GetComponent<Rigidbody2D>();
        if(bombsCosmic.Length>0)
        {
            SpriteRenderer rendererCosmic = GetComponent<SpriteRenderer>();
            rendererCosmic.sprite = bombsCosmic[Random.Range(0,bombsCosmic.Length)];
        }
        gameObject.transform.eulerAngles = new Vector3(0,0, Random.Range(0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        bodyCosmic.velocity = new Vector2(0,-2f);
        if(transform.position.y<-10f)
        {
            Destroy(gameObject);
        }
    }
}
