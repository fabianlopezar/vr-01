using UnityEngine;
using UnityEngine.UI;
public class CorralOvejas : MonoBehaviour
{
    public Image barraDeProgreso;
    public float progresoActual;
    public float progresoMaximo;

    public float cantidadIncrementar;
    void Update()
    {
        barraDeProgreso.fillAmount = progresoActual / progresoMaximo;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Sheeps sheep = other.GetComponent<Sheeps>();
        if (sheep != null)
        {
            string id = sheep.idSheep;

            if (id == "1"|| id == "2" || id == "3" || id == "4" || id == "5" )
            {
                progresoActual += cantidadIncrementar;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Sheeps sheep = other.GetComponent<Sheeps>();
        if (sheep != null)
        {
            string id = sheep.idSheep;

            // Verifica si la oveja está entre las ovejas permitidas
            if (id == "1" || id == "2" || id == "3" || id == "4" || id == "5")
            {
                // Decrementa el progreso
                progresoActual -= cantidadIncrementar;
            }
        }
    }
}
