using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!!!
using UnityEngine.EventSystems;//哇哦 神功能！避免穿透！

public class CameraProcessing : MonoBehaviour
{
    int cameracounter = 0;
    int bcounter = 0;
    string log;
    // Use this for initialization
    void Start()
    {

    }
    /*void OnGUI()
    {
        GUI.TextField (new Rect(0, 0, 100, 30), "haa");
    }*/
    // Update is called once per frame
    void OnGUI()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (!(GameObject.Find(hit.collider.name).GetComponent<Light>() == null))
        {
            //Debug.Log("1");
            GUILayout.BeginArea(new Rect(100, 200, 300, 400));
            GUILayout.Label("Name " + GameObject.Find(hit.collider.name).name);
            GUILayout.Label("Range " + GameObject.Find(hit.collider.name).GetComponent<Light>().range.ToString());
            GUILayout.Label("SpotAngle " + GameObject.Find(hit.collider.name).GetComponent<Light>().spotAngle.ToString());
        }
    }
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        Vector3 RayPosition = hit.point;
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && !EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("碰撞对象: " + hit.collider.name);
                if (GameObject.Find(hit.collider.name).GetComponent<Light>() == null)//低级错误！判空！

                {
                    /*// 如果射线与平面碰撞，打印碰撞物体信息
                    Debug.Log("碰撞对象: " + hit.collider.name);
                    // 在场景视图中绘制射线
                    Debug.DrawLine(ray.origin, hit.point, Color.red);*/
                    ++cameracounter;
                    log = cameracounter.ToString();
                    GameObject camera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    camera.AddComponent<Light>();//注意不是AddComponents！
                    camera.transform.position = RayPosition;
                    camera.name = log;
                    camera.GetComponent<Light>().type = LightType.Spot;
                    camera.AddComponent<BaseRotate>();
                    camera.GetComponent<Renderer>().material = Resources.Load("textures/Camera", typeof(Material)) as Material;//大神
                    camera.GetComponent<Light>().color = Color.green;
                    camera.GetComponent<Light>().shadows = LightShadows.Hard;
                }
                else
                {
                    float cloney = GameObject.Find(hit.collider.name).transform.rotation.y;
                    float clonez = GameObject.Find(hit.collider.name).transform.rotation.z;
                    GameObject.Find(hit.collider.name).transform.Rotate(int.Parse(GameObject.Find("Y Axe Rotate").GetComponent<Text>().text), cloney, clonez, Space.Self);
                    GameObject.Find(hit.collider.name).GetComponent<Light>().range = float.Parse(GameObject.Find("Range").GetComponent<Text>().text);//using UnityEngine.UI!
                    GameObject.Find(hit.collider.name).GetComponent<Light>().spotAngle = float.Parse(GameObject.Find("Angle").GetComponent<Text>().text);
                }
            }
        }
        else if (Input.GetMouseButton(2) && ((!(GameObject.Find(hit.collider.name).GetComponent<Light>() == null))||!(GameObject.Find(hit.collider.name).GetComponent<BoxCollider>() == null)))
        {
            Destroy(GameObject.Find(hit.collider.name));
        }else if (Input.GetKey("m"))
        {
            ++bcounter;
            GameObject z =GameObject.CreatePrimitive(PrimitiveType.Cube);
            z.transform.position = RayPosition;
            z.name = "b" + bcounter.ToString();
        }
    }
}
