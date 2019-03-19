using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindow : UIWindow
{
    protected override void Start()
    {
        scaleX = 0.7f;
        scaleY = 0.8f;
        base.Start();
    }

    protected override void WindowContent(int id)
    {
        base.WindowContent(id);

        GUI.Button(new Rect(windowRect.width * 0.5f - 60, windowRect.height * 0.5f - 25, 120, 50), "Button");
    }
}
