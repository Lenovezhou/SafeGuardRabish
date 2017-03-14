using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

    void Start() 
    {
        List<Transform> trans = MyXML.ReadXML(Application.dataPath + "/XML/CompletePostion.xml");   
        for (int i = 0; i < trans.Count; i++)
        {
            Debug.Log(trans[i].position +"hello"+trans[i].eulerAngles);
        }
    }

}
