using UnityEngine;
using TMPro;
using System.Collections;

public class ControladorPuntuacion : MonoBehaviour
{
  public static ControladorPuntuacion Instance { get; private set; }

    public TextMeshProUGUI puntuacionTMP;
    public int puntuacion;
    public string nombre;

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
    }
}
