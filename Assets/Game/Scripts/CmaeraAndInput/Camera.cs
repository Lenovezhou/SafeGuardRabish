using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform TargetModel;
    public Transform BaseModel;
	
	// Update is called once per frame
	void Update () {
        //Vector3 targetPoint = TargetModel.position/2 + BaseModel.position/2;
        //transform.LookAt(targetPoint);

        Vector3 pos = TargetModel.position + TargetModel.up * 1 - TargetModel.forward * 2;

        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime);

        transform.LookAt(TargetModel);

	}
}
