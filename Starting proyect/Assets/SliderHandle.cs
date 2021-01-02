using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour
{
    private void OnMouseOver()
    {
        transform.localScale = transform.localScale + Vector3.one;
        Debug.Log("Probando OnmouseOVer");
    }
}
