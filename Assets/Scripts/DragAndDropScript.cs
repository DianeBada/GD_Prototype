using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropScript : MonoBehaviour
{
    public GameObject player;

    void OnMouseDrag()
    {
        transform.position = GetMousePosition();
    }

    Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1;
        mousePos.x = Mathf.Round(mousePos.x);
        mousePos.y = Mathf.Round(mousePos.y);
        return mousePos;
    }
}
