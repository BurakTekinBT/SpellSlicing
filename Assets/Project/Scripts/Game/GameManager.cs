using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    [Header("UI Section")]
    [SerializeField] TextMeshProUGUI _displayText;
    [SerializeField] GameObject _winScreen;
    [SerializeField] GameObject _loseScreen;

    [Header("Random Selected Words")]
    public TextAsset textFile;
    public string displayWord;
    [HideInInspector] public string selectedWord;

    [Header("HP Section")]
    public GameObject hp;
    [HideInInspector] public int hpCount;
    #endregion

    #region Awake, Start, Contructor, Update
    void Start()
    {  
        SelectRandomWord();
        hpCount = hp.transform.childCount;
        displayWord = new string('_', selectedWord.Length);
        UpdateWordDisplay();
    }
    #endregion

    #region Public Funtions
    public void CheckGameEnd() //Is game end with successfully or failed.
    {
        Debug.Log("CheckGameEnd Test => Current Word :" + displayWord + " selected word : " + selectedWord);
        if (hpCount <= 0)
        {
            _loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        if (displayWord == selectedWord)
        {
            _winScreen.SetActive(true);
        }
    }
    public void UpdateWordDisplay() //Ekranda g�z�kecek olan kelime
    {
        _displayText.text = displayWord;
    }
          
    /* SelectRandomWord kendisine atanan metin belgesi �zerinden kelimeler se�er
             - str : alt sat�r sorunu ��zen kral de�i�ken
             - lines : Text dosyas� i�erisindeki eleman say�s� 
             - selectedWord : Text dosyas� i�erisinden rastgele bir eleman� tutar.
    */
    public string SelectRandomWord()
    {       
        if(textFile != null)
        {
            string _str = textFile.text;

            _str = _str.Replace("\n", "%");
            _str = _str.Replace("\r", "%");
            _str = _str.Replace("%%", "%");

            string[] _lines = _str.Split('%');         
            selectedWord = _lines[Random.Range(0, _lines.Length)];
            Debug.Log("Selected word from text file : |" + selectedWord + "|" + "Selected Word Length : " + selectedWord.Length);
        }
        else {
            Debug.LogError("Metin belgesi atanmam��");
        }
        return selectedWord;
    }
    public void LoseHP() //Hatal� harfe temas etti�imizde �al��acak ve hp nesnesinin i�indeki hp childlar�ndan birini yok edecek.
    {
        hpCount--;
        Transform lastChild = hp.transform.GetChild(hpCount);
        Destroy(lastChild.gameObject);      
    }
    #endregion
}
