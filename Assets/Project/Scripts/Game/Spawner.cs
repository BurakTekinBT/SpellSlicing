using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    public List<Sprite> newSpriteList;
    public List<char> uniqueCharacters;

    [Header("Spawn Letters")]
    public string selectedWord;
    
    #endregion

    #region Awake, Start, Contructor, Update
    void Start()
    {
        selectedWord = WordManager.Instance.selectedWord;
        AddToNewList();
        

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

    #region Private Methods

    private void Spawn() //Spawner Method
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2((transform.position.x + (Random.Range(minimumX,maximumX))), maximumY);

        string str = WordManager.Instance.selectedWord;

        uniqueCharacters = str.Distinct().ToList();
        AddToNewList();

        /*foreach(char sp in uniqueCharacters)
        {
            for (int i =0; i< spriteList.Count; i++)
            {
                if (spriteList[i].name == sp.ToString())
                {
                    AddToNewList(spriteList[i]);
                }
            }
        }*/

        for (int i = 0; i < spriteList.Count; i++)
        {
            
            for (int j = 0; j < uniqueCharacters.Count; j++)
            {
                if (spriteList[i].name.ToLower() == uniqueCharacters[j].ToString())
                {
                    Sprite randomSprite = spriteList[Random.Range(0, spriteList.Count)];
                    Sprite randomSprite2 = newSpriteList[Random.Range(0, newSpriteList.Count)];
                    instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
                    instance.GetComponent<SpriteRenderer>().sprite = randomSprite2;
                }
            }

        }

        //Generate random letter 
        //Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        //instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    public void AddToNewList()
    {
        foreach (char sp in uniqueCharacters)
        {
            for (int i = 0; i < spriteList.Count; i++)
            {
                if (spriteList[i].name == sp.ToString() && !newSpriteList.Contains(spriteList[i]))
                {
                    newSpriteList.Add(spriteList[i]);
                }
            }
        }

        //newSpriteList.Add(sprite);
        //Debug.Log("Spirte name : " + sprite.name + "sprite index :  " + newSpriteList[2] + "new sprite array : " + newSpriteList);
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

        foreach (Sprite c in newSpriteList)
        {
            if (c.name == guessedLetter.ToString())
            {
                newSpriteList.Remove(c);
            }
        }


    }

    #endregion
}
