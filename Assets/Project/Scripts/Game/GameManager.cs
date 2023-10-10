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
        UpdateWordDisplay();
    }

    /* CheckGameEnd : Oyunun bitip bitmedi�ini kontrol eder.
        - Kelime bulunduysa win ekkran� gelir e�er.
        - Kelime bulunamadan can say�s� 0 a d��erse lose ekran� gelir
    */
    public void CheckGameEnd()
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

    /*Bulunan kelimeyi ekrana yazd�r�r 
     */
    public void UpdateWordDisplay()
    {
        displayText.text = displayWord;
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

            string[] lines = str.Split('%');         
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
    }
}
