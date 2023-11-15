using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    Vector3 mousePositionWorld;
    Vector3 mousePositionBegin;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        this.mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.MoveCamera();
        this.ZoomCamera();
    }
    bool IsCameraOutMap(Camera cam,Vector3 pos)
    {
        Vector3 minMap = MapManager.instance.mapCollider.bounds.min;
        Vector3 maxMap = MapManager.instance.mapCollider.bounds.max;

        Vector3 minCam = cam.ScreenToWorldPoint(new Vector3(0, 0, 0))- pos;
        Vector3 maxCam = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) - pos;

        return (minCam.y < minMap.y || minCam.x < minMap.x || maxCam.y > maxMap.y || maxCam.x > maxMap.x);
    }
    void MoveCamera()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            this.mousePositionBegin = this.mousePositionWorld;
        }
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (this.mousePositionWorld != this.mousePositionBegin)
            {
                Vector3 distance = this.mousePositionWorld - this.mousePositionBegin;
                if (this.IsCameraOutMap(Camera.main,distance))
                {
                    Vector3 distance1 = new Vector3(distance.x, 0, 0);
                    Vector3 distance2 = new Vector3(0, distance.y, 0);
                    if (!this.IsCameraOutMap(Camera.main, distance1)) Camera.main.transform.position -= distance1;
                    else if (!this.IsCameraOutMap(Camera.main, distance2)) Camera.main.transform.position -= distance2;

                }
                else Camera.main.transform.position -= distance;
            }
        }
    }
    void ZoomCamera()
    {
        float zoomValue = 0.35f;
        float scrollDelta = Input.mouseScrollDelta.y;
        if (scrollDelta > 0)
        {
            Camera.main.orthographicSize -= zoomValue;
        }
        else if(scrollDelta < 0)
        {
            float speed = 60;
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(0,0,-10), Time.deltaTime*speed);
            Camera.main.orthographicSize += zoomValue;
            if (this.IsCameraOutMap(Camera.main, Vector3.zero)) Camera.main.orthographicSize -= zoomValue;
        }
    }
}
