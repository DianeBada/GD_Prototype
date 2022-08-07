using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTips : MonoBehaviour
{
    public GameObject toolTip;

    void OnMouseEnter()
    {
        toolTip.SetActive(true);
    }

    void OnMouseExit()
    {
        toolTip.SetActive(false);
    }
}
