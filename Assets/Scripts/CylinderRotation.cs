using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    void Update()
    {
        //Mouse Control
        transform.Rotate(0, -1000f * Input.GetAxis("Mouse X") * Time.deltaTime, 0);
        //KeyBoard Control
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, -300f * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0, 300f * Time.deltaTime, 0);
        }
        //Mobile Control
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Moved){
                transform.Rotate(0, -touch.deltaPosition.x * 10f * Time.deltaTime, 0);
            }
        }
    }
}
