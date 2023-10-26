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
    public float maximumY;

    private float time;
    public float startTime;

    [Header("Visuals")]
    //public Sprite[] sprites;
    public List<Sprite> spriteList;

    [Header("Spawn Letters")]
    public GameManager gameManager;
    public GameObject sliceManager;
    public string selectedw;
    #endregion

    #region Awake, Start, Contructor, Update
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
        instance.transform.position = new Vector2((transform.position.x + (Random.Range(minimumX,maximumX))), maximumY);

        string str = gameManager.selectedWord;

        var uniqueCharacters = str.Distinct().ToList();

        for (int i = 0; i < spriteList.Count; i++)
        {
            for (int j = 0; j < uniqueCharacters.Count; j++)
            {
                if (spriteList[i].name.ToLower() == uniqueCharacters[j].ToString())
                {
                    Sprite randomSprite = spriteList[Random.Range(0, spriteList.Count)];
                    Debug.Log(uniqueCharacters.Count);
                    instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
                }
            }

        }

        //Çalýþýyot
        /*
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
            
        }*/

        //Generate random letter 
        //Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        //instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

   public void RemoveFromList(char guessedLetter)
    {

        foreach(Sprite c in spriteList)
        {
            if(c.name == guessedLetter.ToString())
            {
                spriteList.Remove(c);
            }
        }
    }

    #endregion
}
