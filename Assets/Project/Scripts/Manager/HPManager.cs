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
    public void LoseHP() //Hatalý harfe temas ettiðimizde çalýþacak ve hp nesnesinin içindeki hp childlarýndan birini yok edecek.
    {
        hpCount--;
        Transform lastChild = hp.transform.GetChild(hpCount);
        Destroy(lastChild.gameObject);
    }
}
