using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isRunning = false;
    private Coroutine _timer;
    private float _delay = 0.5f;
    private float _elapsedTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isRunning)
            {
                StopCoroutine(_timer);
                _isRunning = false;
            }
            else
            {
                _timer = StartCoroutine(TurnOnTimer(_delay));
                _isRunning = true;
            }
        }
    }

    private IEnumerator TurnOnTimer(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _elapsedTime++;
            UpdateTimerText();
            yield return wait;
        }
    }

    private void UpdateTimerText()
    {
        if (_text != null)
        {
            _text.text = _elapsedTime.ToString("");
        }
    }
}