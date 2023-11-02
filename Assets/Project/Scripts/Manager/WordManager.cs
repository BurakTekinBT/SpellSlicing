using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WordManager : MonoBehaviour
{
    [HideInInspector] public string selectedWord;
    
    public TextAsset textFile;
    public static WordManager Instance;

    private void Awake()
    {
        Instance = this;
        SelectRandomWord();
    }

    void Start()
    {
       
    }

    /* SelectRandomWord : Select Random Word from releate text file
            - lines : Text dosyasý içerisindeki eleman sayýsý 
            - selectedWord : Select Random Word from releate text file as a variable
   */
    public string SelectRandomWord()
    {
        if (textFile != null)
        {
            //Solution for the counted /n
            string _str = textFile.text;

            _str = _str.Replace("\n", "%");
            _str = _str.Replace("\r", "%");
            _str = _str.Replace("%%", "%");

            string[] _lines = _str.Split('%');
            selectedWord = _lines[Random.Range(0, _lines.Length)];
            Debug.Log("Selected word from text file : |" + selectedWord + "|" + "Selected Word Length : " + selectedWord.Length);
        }
        else
        {
            Debug.LogError("Metin belgesi atanmamýþ");
        }
        return selectedWord;
    }


}
