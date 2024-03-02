using UnityEngine;
using System.Collections;

public class Oleadas : MonoBehaviour

{
    public GameObject[] enemigos;
    public Transform jugador;
    public float distanciaMinima = 10f;
    public float tiempoEntreOleadas = 5f;
    public float tiempoEntreEnemigos = 1f;
    public int cantidadEnemigosPorOleadaInicial = 10; // Número inicial de enemigos por oleada
    public float aumentoEnemigosIntervalo = 5f; // Intervalo de tiempo para aumentar el número de enemigos
    public int aumentoEnemigosCantidad = 5; // Cantidad de enemigos a aumentar por intervalo

    private bool enOleada;
    private int cantidadEnemigosPorOleadaActual; // Número actual de enemigos por oleada

    private float timer;
    void Start()
    {
        cantidadEnemigosPorOleadaActual = cantidadEnemigosPorOleadaInicial;
        StartCoroutine(GenerarOleadas());
        StartCoroutine(AumentarEnemigos());
    }

    IEnumerator GenerarOleadas()
    {
        while (true)
        {
            enOleada = true;

            for (int i = 0; i < cantidadEnemigosPorOleadaActual; i++)
            {
                Vector2 posicionAleatoria = (Random.insideUnitCircle * distanciaMinima) + (Vector2)jugador.position;
                GameObject enemigoAleatorio = enemigos[Random.Range(0, enemigos.Length)];
                Instantiate(enemigoAleatorio, posicionAleatoria, Quaternion.identity);
                yield return new WaitForSeconds(tiempoEntreEnemigos);
            }

            yield return new WaitForSeconds(tiempoEntreOleadas);
            enOleada = false;
        }
    }

    IEnumerator AumentarEnemigos()
    {
        while (true)
        {
            yield return new WaitForSeconds(aumentoEnemigosIntervalo);
            cantidadEnemigosPorOleadaActual += aumentoEnemigosCantidad;
        }
    }

    void Update()
    {
        if (!enOleada && GameObject.FindGameObjectsWithTag("Enemigo").Length == 0)
        {
            StartCoroutine(GenerarOleadas());
        }
        timer += Time.deltaTime;

        if (timer >= 40f)
        {
            // Instantiate x number of enemies
            for (int i = 0; i < 50; i++)
            {
                Vector2 posicionAleatoria = (Random.insideUnitCircle * distanciaMinima) + (Vector2)jugador.position;
                GameObject enemigoAleatorio = enemigos[Random.Range(0, enemigos.Length)];
                Instantiate(enemigoAleatorio, posicionAleatoria, Quaternion.identity);
            }
            timer = 0f;
        }

        if (!enOleada && GameObject.FindGameObjectsWithTag("Enemigo").Length == 0)
        {
            StartCoroutine(GenerarOleadas());
        }
    }

}
