using UnityEngine;
using System.IO;

public class ScreenshotTool : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.P; // Taste zum Ausl�sen des Screenshots
    public string screenshotFolder = "Screenshots"; // Ordner, in dem Screenshots gespeichert werden
    public int superSize = 1; // Erh�ht die Aufl�sung des Screenshots, 1 = native Aufl�sung, 2 = doppelte Aufl�sung usw

    private void Start()
    {
        // �berpr�fe, ob der Screenshot-Ordner existiert, und erstelle ihn, wenn nicht
        if (!Directory.Exists(screenshotFolder))
        {
            Directory.CreateDirectory(screenshotFolder);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            TakeScreenshot();
        }
    }

    private void TakeScreenshot()
    {
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
        string fileName = Path.Combine(screenshotFolder, "Screenshot_" + timestamp + ".png");
        ScreenCapture.CaptureScreenshot(fileName, superSize);
        Debug.Log("Screenshot saved to: " + Path.GetFullPath(fileName));
    }
}
