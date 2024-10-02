using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scrCameraManager : MonoBehaviour
{

    // public Cinemachine.AxisState x, y;
    [SerializeField] scrPlayer scrp;
    public float x, y;

    [SerializeField] float mouseSense;
    [SerializeField] Transform followCamPos;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        x+=(Input.GetAxisRaw("Mouse X") * mouseSense);
        y-=(Input.GetAxisRaw("Mouse Y") * mouseSense);
        y=Mathf.Clamp(y,-80,80);

    }

    private void LateUpdate()
    {
        if(!scrp.noCover){
        followCamPos.localEulerAngles = new Vector3(y, followCamPos.localEulerAngles.y, followCamPos.localEulerAngles.z);
        transform.eulerAngles= new Vector3(transform.eulerAngles.x, x, transform.eulerAngles.z);
        }
    }
}
