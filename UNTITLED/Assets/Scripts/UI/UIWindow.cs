using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    public Rect windowRect;

    protected float scaleX = 0.7f;
    protected float scaleY = 0.7f;
    protected string title = "Unnamed Window";

    protected virtual void Start()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        int w = (int)(sw * scaleX);
        int h = (int)(sh * scaleY);
        windowRect = new Rect((sw / 2) - (w / 2), (sh / 2) - (h / 2), w, h);
    }

    void OnGUI()
    {
        // Register the window.
        windowRect = GUI.Window(0, windowRect, WindowContent, title);
    }

    // Make the contents of the window
    protected virtual void WindowContent(int windowID)
    {
        // Make a very long rect that is 20 pixels tall.
        // This will make the window be resizable by the top
        // title bar - no matter how wide it gets.
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }
}
