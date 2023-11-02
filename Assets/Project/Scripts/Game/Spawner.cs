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
    public List<Sprite> spriteList;
    public List<Sprite> newSpriteList;
    public List<char> uniqueCharacters;

    [Header("Spawn Letters")]
    public string selectedWord;

    bool isUniqueListCreated = false;
    
    #endregion

    #region Awake, Start, Contructor, Update
    void Start()
    {
        selectedWord = WordManager.Instance.selectedWord;
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

    #region Methods

    private void Spawn() //Spawner Method
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2((transform.position.x + (Random.Range(minimumX,maximumX))), maximumY);

        string str = WordManager.Instance.selectedWord;

        uniqueCharacters = str.Distinct().ToList();
        if (!isUniqueListCreated)
        {
            AddToNewList();
            
        }

        if(Random.Range(0f, 1f) >= 0.2f)
        {
            Sprite randomSprite = spriteList[Random.Range(0, spriteList.Count)];
            instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
        }
        else
        {
            Sprite randomSprite2 = newSpriteList[Random.Range(0, newSpriteList.Count)];
            instance.GetComponent<SpriteRenderer>().sprite = randomSprite2;
        }
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
        isUniqueListCreated = true;
    }
   public void RemoveFromList(char guessedLetter)
    {

        foreach (Sprite c in newSpriteList)
        {
            if (c.name == guessedLetter.ToString())
            {
                if (spriteList.Contains(c))
                {
                    spriteList.Remove(c);
                }
                newSpriteList.Remove(c);
            }
            else
            {
                Debug.Log("None");
            }
        }
    }
    #endregion
}
