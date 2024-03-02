using UnityEngine.UI;
using UnityEngine;

public class PanelesControlador : MonoBehaviour
{
    public GameObject paneleInicio;
    public Button pausaButton;
    public Text tiempoText;

    void Start()
    {
        JuegoPausado();
    }
    public void JuegoPausado()
    {
        Time.timeScale = 0f;
    }
    public void JuegoEnCurso()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        paneleInicio.SetActive(false);
        Time.timeScale = 1f;
    }
}
