using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed;
    private float alpha = 1;
    private static int fadeDir = -1;
    private int draveDepth = -1000;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = draveDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public static void fadeOn(int dir)
    {
        fadeDir = dir;
    }

    public void OnLevelWasLoaded()
    {
        fadeOn(-1);
    }

}
