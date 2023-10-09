using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slice : MonoBehaviour
{
    private string selectedWord;
    private string currentWord;
    private bool gameEnded = false;

    public GameManager gameManager;
    

    [Header("Slice Section")]
    public GameObject bladeTrailerPrefab;
    bool isCutting = false;
    CircleCollider2D circleCollider;
    GameObject currentBladeTrailer;
    private string slicedLetter;
 
    Rigidbody2D rb;
    Camera cam;

    void Start()
    {
        /* Main Variables */
        //currentWord = new string('_', selectedWord.Length);
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        selectedWord = gameManager.selectedWord;
        //currentWord = new string('_', selectedWord.Length);
    }

    // Update is called once per frame
    void Update()
    {
        isCuttingOrNotCutting();
    }

    void isCuttingOrNotCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCutting();
            isCutting = true;
            currentBladeTrailer = Instantiate(bladeTrailerPrefab, transform);
            circleCollider.enabled = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            //StopCutting();
            isCutting = false;
            currentBladeTrailer.transform.SetParent(null);
            Destroy(currentBladeTrailer, 2f);
            circleCollider.enabled = false;
        }

        if (isCutting)
        {
           //UpdateCut();
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }



    /* slicedLetter = Etkileþime geçilen nesnenin etiketi Cuttable ise onun spriteýnýn ismini tutar.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check are we hit the cuttable object
        if(collision.collider.tag == "Cuttable")
        {
            //If we sliced the cuttable object send it name to CheckLetter()
            slicedLetter = collision.transform.GetComponent<SpriteRenderer>().sprite.name.ToString();        
            CheckLetter(slicedLetter);
        }
    }
    public void CheckLetter(string input)
    {
        if (gameEnded)
            return;
        
        char guessedLetter = input.ToString().ToLower()[0];
        bool letterFound = false;

        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == guessedLetter)
            {
                gameManager.displayWord = gameManager.displayWord.Substring(0, i) + guessedLetter + gameManager.displayWord.Substring(i + 1);
                letterFound = true;
                Debug.Log("You found! : " + guessedLetter );
            }
        }

        if (!letterFound)
        {           
            gameManager.LoseHP();
            Camera.main.GetComponent<CameraShake>().Shake();
            Debug.Log("You SLICED wrong letter");
        }
       
        gameManager.UpdateWordDisplay(gameManager.displayWord);
        gameManager.CheckGameEnd(selectedWord);
    }
}
