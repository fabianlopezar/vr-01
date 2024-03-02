using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class ControladorPuntuacion : MonoBehaviour
{
  public static ControladorPuntuacion Instance { get; private set; }

    public TextMeshProUGUI puntuacionTMP;
    public TMP_Text _nombreTMP;
    public int puntuacion;
    public string _nombre;
    public TMP_Text puntuacionMostrarPerdiste;
  //  public string _nombreMostrarPerdiste;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void AddPuntuacion()
    {   
        puntuacion = puntuacion + 10;
        puntuacionTMP.text = "" + puntuacion;

             puntuacionMostrarPerdiste.text= ""+puntuacion;
     
}
    public void GuardarNombre()
    {
       _nombre = _nombreTMP.text;
        Debug.Log("el nombre es: " + _nombre);
    }
}
