using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private string puzzleObject;
    [SerializeField]
    private List<Sprite> puzzleObjects;

    private Sprite selectedSprite;
    // Start is called before the first frame update
    void Start()
    {
        puzzleObject = WordManager.Instance.selectedWord;
        Debug.Log(puzzleObject);
        foreach (Sprite sprite in puzzleObjects)
        {
            if(sprite.name == puzzleObject)
            {
                selectedSprite = sprite;
            }
        }
        
        GetComponent<SpriteRenderer>().sprite = selectedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        puzzleObject = WordManager.Instance.selectedWord;
    }
}
