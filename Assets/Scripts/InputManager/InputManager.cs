using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject())
        {
            this.mousePositionBegin = this.mousePositionWorld;
        }
        if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (this.mousePositionWorld != this.mousePositionBegin)
            {
                Vector3 distance = this.mousePositionWorld - this.mousePositionBegin;
                if (this.IsCameraOutMap(distance))
                {
                    Vector3 distance1 = new Vector3(distance.x,0, 0);
                    Vector3 distance2 = new Vector3(0, distance.y, 0);
                    if(!this.IsCameraOutMap(distance1)) Camera.main.transform.position -= distance1;
                    else if (!this.IsCameraOutMap(distance2)) Camera.main.transform.position -= distance2;

                }
                else Camera.main.transform.position -= distance;
            }
        }
        
    }
    bool IsCameraOutMap(Vector3 pos)
    {
        Vector3 minMap = MapManager.instance.mapCollider.bounds.min;
        Vector3 maxMap = MapManager.instance.mapCollider.bounds.max;

        Vector3 minCam = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0))- pos;
        Vector3 maxCam = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) - pos;

        return (minCam.y < minMap.y || minCam.x < minMap.x || maxCam.y > maxMap.y || maxCam.x > maxMap.x);
    }
}
