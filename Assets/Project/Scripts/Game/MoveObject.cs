using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [Header("Speed variables")]
    public float minimumXSpeed;
    public float maximumXSpeed;
    public float minimumYSpeed; 
    public float maximumYSpeed;

    [Header("Gameplay variables")]
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
       
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(minimumXSpeed, maximumXSpeed), Random.Range(minimumYSpeed, maximumYSpeed));

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
