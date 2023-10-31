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
    public TextMeshProUGUI _displayText;
    [SerializeField] GameObject _winScreen;
    [SerializeField] GameObject _loseScreen;

    [Header("Random Selected Words")]
    public string displayWord;
    private string selectedWord;

    [Header("HP Section")]
    public GameObject hp;
    [HideInInspector] public int hpCount;
    #endregion

    #region Awake, Start, Contructor, Update
    void Start()
    {
        selectedWord = WordManager.Instance.selectedWord;
        hpCount = HPManager.Instance.hpCount;
        displayWord = new string('_', selectedWord.Length);
        UpdateWordDisplay();
    }
    #endregion

    public void CheckGameEnd() //Is game end with successfully or failed.
    {
        Debug.Log("CheckGameEnd Test => Current Word :" + displayWord + " selected word : " + selectedWord);
        if (HPManager.Instance.hpCount <= 0)
        {
            _loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        if (displayWord == selectedWord)
        {
            _winScreen.SetActive(true);
        }
    }
    public void UpdateWordDisplay() //Ekranda gözükecek olan kelime
    {
        _displayText.text = displayWord;
    }

}
