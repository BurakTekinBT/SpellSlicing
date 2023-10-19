using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [Header("HP")]
    public GameObject hp;
    [HideInInspector] public int hpCount;

    void Start()
    {
        hpCount = hp.transform.childCount;
    }

    private void CheckHP()
    {
        if (hpCount <= 0)
        {
            Time.timeScale = 0f;
        }
    }
    public void LoseHP() //Hatal� harfe temas etti�imizde �al��acak ve hp nesnesinin i�indeki hp childlar�ndan birini yok edecek.
    {
        hpCount--;
        Transform lastChild = hp.transform.GetChild(hpCount);
        Destroy(lastChild.gameObject);
    }
}
