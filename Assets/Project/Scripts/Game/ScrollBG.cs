using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBG : MonoBehaviour
{
    [SerializeField] private float _slideSpeed;
    [SerializeField] Vector2 _startposition;
    float leftpos;
    float width;
    float dif;
    private void Start()
    {
        leftpos = transform.position.x;
        width = transform.GetComponent<RawImage>().texture.width;
        dif = -width + leftpos;
    }
    void Update()
    {
        
        transform.position = new Vector2(transform.position.x - _slideSpeed * Time.deltaTime, transform.position.y);

        Debug.Log("width : " + width + " did : " + dif);
        if (transform.position.x < dif)
        {
            Debug.Log("Sýnýf aþýldý");
        }
        
    }
}
