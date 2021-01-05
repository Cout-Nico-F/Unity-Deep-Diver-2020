using UnityEngine;

public class ChildCount : MonoBehaviour
{
    // This script is useful to count how many childs has a gameobject. 

    GameObject obj;
    void Awake()
    {
        obj = this.gameObject;
        Debug.Log(obj.name + " has " + obj.transform.childCount + " children");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(obj.name + " has " + obj.transform.childCount + " children");
    }
}
