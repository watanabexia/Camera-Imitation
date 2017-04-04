using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testclick : MonoBehaviour
{
    public bool is_c = true;
    public void Click()
    {
        if (is_c)
        {
            for (int x = 0; x <= 100; ++x)
            {
                for (int z = 0; z <= 100; ++z)
                {
                    int namegiv = 100000000 + 10000 * x + z;
                    GameObject clone = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    clone.transform.localScale = new Vector3(1f, 1f, 1f);
                    clone.transform.position = new Vector3(10f * x, 0,10f * z);
                    clone.name = namegiv + "";
                    if ((z+x) % 2 == 0)
                    {
                        clone.GetComponent<Renderer>().material.color = Color.black;
                    }
                    else
                    {
                        clone.GetComponent<Renderer>().material.color = Color.white;
                    }

                }
            }
            is_c = false;
        }
        
    }
}