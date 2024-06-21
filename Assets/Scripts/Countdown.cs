using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText; // Verweis auf das UI-Text-Element für die Anzeige des Timers
    public Button startButton; // Verweis auf den Start-Button
    public Button add5Button; // Verweis auf den +5-Button
    public Button add10Button; // Verweis auf den +10-Button
    public Button add15Button; // Verweis auf den +15-Button
    public Button subtract5Button; // Verweis auf den -5-Button
    public Button subtract10Button; // Verweis auf den -10-Button
    public Button subtract15Button; // Verweis auf den -15-Button

    private float currentTime = 0; // Startzeit in Sekunden
    private bool countdownActive = false; // Gibt an, ob der Countdown aktiv ist

    void Start()
    {
        // Zuordnung der Methoden zu den OnClick-Ereignissen der Buttons
        startButton.onClick.AddListener(StartCountdown);
        add5Button.onClick.AddListener(() => AddTime(300));  // 5 Minuten = 300 Sekunden
        add10Button.onClick.AddListener(() => AddTime(600)); // 10 Minuten = 600 Sekunden
        add15Button.onClick.AddListener(() => AddTime(900)); // 15 Minuten = 900 Sekunden
        subtract5Button.onClick.AddListener(() => SubtractTime(300));  // 5 Minuten = 300 Sekunden
        subtract10Button.onClick.AddListener(() => SubtractTime(600)); // 10 Minuten = 600 Sekunden
        subtract15Button.onClick.AddListener(() => SubtractTime(900)); // 15 Minuten = 900 Sekunden

        UpdateTimerDisplay(); // Timer-Anzeige zu Beginn aktualisieren
    }

    void Update()
    {
        if (countdownActive && currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Zeit herunterzählen
            if (currentTime < 0)
            {
                currentTime = 0; // Sicherstellen, dass die Zeit nicht negativ wird
            }
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Zeit in Stunden, Minuten und Sekunden umwandeln
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Zeit im Text-Format aktualisieren (z.B. "01:05:30" für 1 Stunde, 5 Minuten und 30 Sekunden)
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void StartCountdown()
    {
        countdownActive = true; // Countdown starten
    }

    public void AddTime(int secondsToAdd)
    {
        currentTime += secondsToAdd;
        UpdateTimerDisplay();
    }

    public void SubtractTime(int secondsToSubtract)
    {
        currentTime = Mathf.Max(0, currentTime - secondsToSubtract);
        UpdateTimerDisplay();
    }
}
