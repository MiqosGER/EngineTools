using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Verweis auf das UI-Text-Element
    public Button startButton; // Verweis auf den Start-Button
    public Button stopButton; // Verweis auf den Stopp-Button
    public Button resetButton; // Verweis auf den Reset-Button
    public Button pauseResumeButton; // Verweis auf den Pause-/Resume-Button

    private float startTime;
    private float pausedTime;
    private bool running = false;
    private bool paused = false;

    void Start()
    {
        // Zuordnung der Methoden zu den OnClick-Ereignissen der Buttons
        startButton.onClick.AddListener(StartTimer);
        stopButton.onClick.AddListener(StopTimer);
        resetButton.onClick.AddListener(ResetTimer);
        pauseResumeButton.onClick.AddListener(PauseResumeTimer);
    }

    void Update()
    {
        if (running && !paused)
        {
            float currentTime = Time.time - startTime;
            int hours = (int)(currentTime / 3600);
            int minutes = (int)((currentTime % 3600) / 60);
            int seconds = (int)(currentTime % 60);
            float milliseconds = (currentTime * 1000) % 1000;

            string timerString = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hours, minutes, seconds, milliseconds);
            timerText.text = timerString;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        running = true;
        paused = false;
    }

    public void StopTimer()
    {
        running = false;
        paused = false;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
        timerText.text = "0:00";
        running = true;
        paused = false;
    }

    public void PauseResumeTimer()
    {
        if (running)
        {
            if (paused)
            {
                // Fortsetzen des Timers
                startTime += (Time.time - pausedTime);
                paused = false;
            }
            else
            {
                // Pausieren des Timers
                pausedTime = Time.time;
                paused = true;
            }
        }
    }
}
