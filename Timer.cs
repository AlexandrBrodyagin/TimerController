using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool isRunning = false;
    private float elapsedTime = 0f;
    private Coroutine timerCoroutine;
    private float _delay = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isRunning)
            {
                StopCoroutine(timerCoroutine);
                isRunning = false;
            }
            else
            {
                timerCoroutine = StartCoroutine(TimerController(_delay));
                isRunning = true;
            }
        }
    }

    private IEnumerator TimerController(float delay)
    {
        while (true)
        {
            elapsedTime++;
            UpdateTimerText();
            yield return new WaitForSeconds(delay);
        }
    }

    private void UpdateTimerText()
    {
        if (_text != null)
        {
            _text.text = elapsedTime.ToString("");
        }
    }
}
