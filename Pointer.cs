using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform Aim;
    [SerializeField]  private Camera PlayerCamera;
    [SerializeField] private Transform _body;
    private  float _yEuler;
  
    void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, -Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);

        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;

        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
        if (toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8f);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8f);
        }
        _body.localEulerAngles =  new Vector3(0,_yEuler,0);
    
    }
}
