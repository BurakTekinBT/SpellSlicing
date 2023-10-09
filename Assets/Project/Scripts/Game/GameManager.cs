using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Section")]
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    [Header("Random Selected Words")]
    public TextAsset textFile;
    public string[] lines;
    private string randomLine;
    public string displayWord;
    [HideInInspector] public string selectedWord;

    [Header("HP Section")]
    public GameObject hp;
    [HideInInspector] public int hpCount;

    void Start()
    {  
        SelectRandomWord();
        hpCount = hp.transform.childCount;
        displayWord = new string('_', selectedWord.Length);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTextOnScreen();
    }

    void DisplayTextOnScreen()
    {
        displayText.text = displayWord;
    }

    /* CheckGameEnd : Oyunun bitip bitmedi�ini kontrol eder.
         - str : alt sat�r sorunu ��zen kral de�i�ken
         - lines : Text dosyas� i�erisindeki eleman say�s� 
         - selectedWord : Text dosyas� i�erisinden rastgele bir eleman� tutar.
    */
    public void CheckGameEnd(string selectedWord)
    {
        Debug.Log("CheckGameEnd Test => Current Word :" + displayWord + " selected word : " + selectedWord);
        if (hpCount <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        if (displayWord == selectedWord)
        {
            winScreen.SetActive(true);
        }
    }

    public void UpdateWordDisplay(string currentWord)
    {
        displayText.text = currentWord;
        displayWord = currentWord;
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
            string str = textFile.text;

            str = str.Replace("\n", "%");
            str = str.Replace("\r", "%");
            str = str.Replace("%%", "%");

            lines = str.Split('%');         
            selectedWord = lines[Random.Range(0, lines.Length)];
            Debug.Log("Selected word from text file : |" + selectedWord + "|" + "Selected Word Length : " + selectedWord.Length);
        }
        else {
            Debug.LogError("Metin belgesi atanmam��");
        }
        return selectedWord;
    }

    /* LoseHP(), Hatal� harfe temas etti�imizde �a���acak ve ekrandaki kalplerden birini yok edecek.
      lastChild = hp nesnesinin i�indeki hp childlar�n� tutar. 
     */
    public void LoseHP()
    {
        hpCount--;
        Transform lastChild = hp.transform.GetChild(hpCount);
        Destroy(lastChild.gameObject);
        
        Debug.Log(hpCount);
    }
}
