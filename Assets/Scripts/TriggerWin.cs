using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    public GameObject panelWin;

    private void OnTriggerEnter2D(Collider2D other)
    {
    // if(other.CompareTag("Player"))
        //panelWin.SetActive(true);
    }
}
