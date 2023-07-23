using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public RectTransform pointer;
    public RectTransform pointer02;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointer.localEulerAngles = new Vector3(0, 0, pointer.eulerAngles.z + 20 * Time.realtimeSinceStartup);
        pointer02.localEulerAngles = new Vector3(0, 0, pointer02.eulerAngles.z - 20 * Time.realtimeSinceStartup);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pointer.eulerAngles.z > pointer02.eulerAngles.z - 10 && pointer.eulerAngles.z < pointer02.eulerAngles.z + 10)
            {
                Debug.Log("W");
            }
            else
            {
                Debug.Log("F");
            }
        }
    }
}
