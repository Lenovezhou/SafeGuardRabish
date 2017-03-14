using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class MyEditor : Editor
{

    [MenuItem("Tools/Begine Create MainFiles")]
    static void CreateFiles() 
    {
        Directory.CreateDirectory(Application.dataPath + "/Scenes");
        Directory.CreateDirectory(Application.dataPath + "/Materials");
        Directory.CreateDirectory(Application.dataPath + "/Prefab");
        Directory.CreateDirectory(Application.dataPath + "/Game");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Application");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Application/1.Model");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Application/2.View");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Application/1.Controllers");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Framework");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Framework/Pool");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Framework/Singleton");
        Directory.CreateDirectory(Application.dataPath + "/Game/Scripts/Framework/Sound");
        Directory.CreateDirectory(Application.dataPath + "/Prefab");
    }

    [MenuItem("Tools/Create XML For OnCompletePosition")]
    static void CreateCompletePositionXML() 
    {
        MyXML.CreateXML(Application.dataPath + "/XML/CompletePostion.xml",Selection.activeGameObject.GetComponentsInChildren<Transform>());
    }

    [MenuItem("Tools/Create XML For InilazablePosition")]
    static void CreateInilazabelXML()
    {
        MyXML.CreateXML(Application.dataPath + "/XML/Inilazable.xml", Selection.activeGameObject.GetComponentsInChildren<Transform>());
    }


    [MenuItem("Tools/Update XML")]
    static void UpdateXML()
    {
        MyXML.UpdateXML(Application.dataPath + "/XML/CompletePostion.xml", Selection.activeGameObject.GetComponent<Transform>());
    }
}
