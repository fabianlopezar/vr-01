using UnityEngine;
using TMPro;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
//-------------------------Ranking
public class Jugador
{
    public string nombre;
    public int puntaje;

    public Jugador(string nombre, int puntaje)
    {
        this.nombre = nombre;
        this.puntaje = puntaje;
    }
}
public class ControladorPuntuacion : MonoBehaviour
{
  public static ControladorPuntuacion Instance { get; private set; }

    public TextMeshProUGUI puntuacionTMP;
    public TMP_Text _nombreTMP;
    public int _puntuacion;
    public string _nombre;
    public TMP_Text puntuacionMostrarPerdiste;
    //  public string _nombreMostrarPerdiste;
    //-------------------------Ranking
    private List<Jugador> listaJugadores = new List<Jugador>();
    private string rutaArchivo = "jugadores.json";
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
        _puntuacion = _puntuacion + 10;
        puntuacionTMP.text = "" + _puntuacion;

             puntuacionMostrarPerdiste.text= ""+_puntuacion;
     
}
    public void GuardarNombre()
    {
       _nombre = _nombreTMP.text;
        Debug.Log("el nombre es: " + _nombre);
       // GuardarPuntaje(_nombre, _puntuacion);
    }

    //------------------------- Ranking
    void Start()
    {
        CargarPuntajes();
    }

    public void GuardarPuntaje()
    {
        Jugador nuevoJugador = new Jugador(_nombre, _puntuacion);
        listaJugadores.Add(nuevoJugador);
        GuardarPuntajes();
        ImprimirPuntajes();
    }

    public void CargarPuntajes()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            listaJugadores = JsonUtility.FromJson<List<Jugador>>(json);
        }
    }

    public void GuardarPuntajes()
    {
        string json = JsonUtility.ToJson(listaJugadores);
        File.WriteAllText(rutaArchivo, json);
    }

    public void ImprimirPuntajes()
    {
        foreach (var jugador in listaJugadores)
        {
            Debug.Log("Nombre: " + jugador.nombre + ", Puntaje: " + jugador.puntaje);
        }
    }

}
