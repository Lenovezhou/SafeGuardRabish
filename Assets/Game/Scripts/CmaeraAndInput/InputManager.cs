using UnityEngine;
using System.Collections;

public class InputManager : Singleton<InputManager>
{
    public float AxisH;
    public float AxisV;
    public float ScrollWheel;
    public Touch touch1, touch2;
    void Update() 
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            AxisV = Input.GetAxis("Mouse X");
            AxisH = Input.GetAxis("Mouse Y");
        }
        ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
#else 

#endif

    }
	
}
