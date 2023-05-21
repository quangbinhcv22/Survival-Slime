using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimerText : MonoBehaviour
{
    private TMP_Text _text;


    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        StartCount();
    }

    private void OnDisable()
    {
        StopCount();
    }


    private float _startTime;
    private readonly StringBuilder _stringBuilder = new();

    private void StartCount()
    {
        _startTime = Time.time;
        InvokeRepeating(nameof(Counting), 0f, 1f);
    }

    private void Counting()
    {
        _stringBuilder.Clear();

        var elapsedTime = Time.time - _startTime;

        var minutes = (int)(elapsedTime / 60);
        var seconds = (int)(elapsedTime % 60);

        _stringBuilder.AppendFormat("{0:00}:{1:00}", minutes, seconds);
        _text.SetText(_stringBuilder.ToString());
    }

    private void StopCount()
    {
        CancelInvoke(nameof(Counting));
    }
}