using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

   

    void Start()
    {
        startTime = Time.time;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            float elapsedTime = Time.time - startTime;
            int seconds = Mathf.FloorToInt(elapsedTime);

            timerText.text = "" + string.Format("{0:00}", seconds) + "";

            yield return new WaitForSeconds(1f);
        }
    }
}
