using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCamera : AdminMonoBehaviour
{
    Canvas canvas;
    protected override void LoadComponent()
    {
        this.canvas = transform.GetComponent<Canvas>();
        this.canvas.renderMode = RenderMode.ScreenSpaceCamera;
        this.canvas.worldCamera = Camera.main;
        transform.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
    }
}
