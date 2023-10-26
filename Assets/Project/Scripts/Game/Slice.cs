using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slice : MonoBehaviour
{
    [Header("")]
    private string selectedWord;
    private bool gameEnded = false;

    public GameManager gameManager;
    public Spawner spawner;
    [Header("Slice Section")]
    public GameObject bladeTrailerPrefab;
    bool isCutting = false;
    CircleCollider2D circleCollider;
    GameObject currentBladeTrailer;
    private string slicedLetter;
    bool IsSlicing;
    Rigidbody2D rb;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        selectedWord = gameManager.selectedWord;
    }

    // Update is called once per frame
    void Update()
    {
        isCuttingOrNotCutting();
    }

    IEnumerator spawnTimeTrail()
    {
        if (!IsSlicing)
        {
            IsSlicing = true;
            yield return new WaitForSeconds(.11f);
            currentBladeTrailer = Instantiate(bladeTrailerPrefab, transform);
            IsSlicing = false;
        }     
    }

    void isCuttingOrNotCutting()
    {

        if (isCutting)
        {
            //UpdateCut();
           
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(currentBladeTrailer != null)
            {
                Destroy(currentBladeTrailer);
            }
            
            //StartCutting();
            isCutting = true;
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
            //currentBladeTrailer = Instantiate(bladeTrailerPrefab, transform);
            StartCoroutine(spawnTimeTrail());
            circleCollider.enabled = true;
            
        }

        else if (Input.GetMouseButtonUp(0))
        {
            //StopCutting();
            isCutting = false;
            //currentBladeTrailer.transform.SetParent(null);
            Destroy(currentBladeTrailer, 2f);
            circleCollider.enabled = false;
        }

   
    }

    /* slicedLetter = Etkileþime geçilen nesnenin etiketi Cuttable ise onun spriteýnýn ismini tutar.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check are we hit the cuttable object
        if (collision.collider.tag == "Cuttable")
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
        
        char guessedLetter = input.ToLower()[0];
        bool letterFound = false;

        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == guessedLetter)
            {
                gameManager.displayWord = gameManager.displayWord.Substring(0, i) + guessedLetter + gameManager.displayWord.Substring(i + 1);
                letterFound = true;
                
                Debug.Log("You found! : " + guessedLetter );
                gameManager.UpdateWordDisplay();
                gameManager.CheckGameEnd();
                spawner.RemoveFromList(guessedLetter);
            }
        }

        if (!letterFound)
        {           
            gameManager.LoseHP();
            Camera.main.GetComponent<CameraShake>().Shake();
            Debug.Log("You SLICED wrong letter");
            gameManager.CheckGameEnd();
        }
       
    }
}
