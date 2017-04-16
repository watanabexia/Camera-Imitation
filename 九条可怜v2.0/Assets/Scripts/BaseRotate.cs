//http://blog.csdn.net/wf_unity/article/details/24343765
using UnityEngine;
using System.Collections;

public class BaseRotate : MonoBehaviour
{

    public Vector3 mousePos;

    IEnumerator OnMouseDown()
    {

        mousePos = Input.mousePosition;

        while (Input.GetMouseButton(0))
        {
            GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
            Vector3 offset = mousePos - Input.mousePosition;

            transform.Rotate(Vector3.down * offset.x, Space.World);
            transform.Rotate(Vector3.left * offset.y, Space.World);

            mousePos = Input.mousePosition;
            yield return null;
        }
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
    }
}