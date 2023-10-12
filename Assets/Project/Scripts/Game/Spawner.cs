using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Fields
    [Header("Target")]
    [SerializeField] private GameObject prefab;

    [Header("Gameplay")]
    public float minimumX;
    public float maximumX;

    private float time;
    public float startTime;

    [Header("Visuals")]
    public Sprite[] sprites;

    [Header("Spawn Letters")]
    public GameManager gameManager;
    public GameObject sliceManager;
    public string selectedw;
    private string selectedchar;
    int indexOfFoundLetter;

    char character;
    #endregion

    #region Awake, Start, Contructor, Update
    // Start is called before the first frame update
    void Start()
    {
        selectedw = gameManager.selectedWord;
    }
    void Update()
    {
        if (time <= 0)
        {
            Spawn();
            time = startTime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    #endregion

    #region Private Variables
    private void Spawn() //Spawner Method
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(Random.Range(minimumX,maximumX), transform.position.y);

        string str = gameManager.selectedWord;

        var uniqueCharacters = str.Distinct().ToList();

        //Debug.Log(uniqueCharacters[0].ToString());

        for (int i = 0; i < sprites.Length; i++)
        {
            //Debug.Log(sprites[i].name);
            for(int j = 0; j < uniqueCharacters.Count; j++)
            {
                if (sprites[i].name.ToLower() == uniqueCharacters[0].ToString())
                {
                    // Sprite bulundu
                    Debug.Log("Sprite bulundu: " + sprites[i].name + "indexi : " + i);
                    break;
                }
            }

        }

        //Generate random letter releated for selected word
        for (int i = 0; i < sprites.Length; i++)
        {
            for (int j =0; j<uniqueCharacters.Count; j++)
            {
                if (sprites[i].name.ToLower() == uniqueCharacters[j].ToString())
                {
                    Sprite notRandomSprite = sprites[Random.Range(0, sprites.Length)];

                    instance.GetComponent<SpriteRenderer>().sprite = notRandomSprite;
                }
            }
            
        }

        //Generate random letter 
        //Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        //instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
    #endregion
}
