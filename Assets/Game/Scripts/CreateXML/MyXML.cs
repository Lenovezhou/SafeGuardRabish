using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public static class MyXML
{
    public static void CreateXML(string path,Transform[] trans) 
    {
        if (!File.Exists(path))
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("ProItems");
            for (int i = 0; i < trans.Length; i++)
            {
                XmlElement Eltransform = xmldoc.CreateElement(trans[i].name);



                XmlElement position_X = xmldoc.CreateElement("Tx");
                position_X.InnerText = trans[i].transform.position.x.ToString();
                XmlElement position_Y = xmldoc.CreateElement("Ty");
                position_Y.InnerText = trans[i].transform.position.y.ToString();
                XmlElement position_Z = xmldoc.CreateElement("Tz");
                position_Z.InnerText = trans[i].transform.position.z.ToString();

                XmlElement rotation_X = xmldoc.CreateElement("Rx");
                rotation_X.InnerText = trans[i].eulerAngles.x.ToString();
                XmlElement rotation_Y = xmldoc.CreateElement("Ry");
                rotation_Y.InnerText = trans[i].eulerAngles.y.ToString();
                XmlElement rotation_Z = xmldoc.CreateElement("Rz");
                rotation_Z.InnerText = trans[i].eulerAngles.z.ToString();


                Eltransform.AppendChild(position_X);
                Eltransform.AppendChild(position_Y);
                Eltransform.AppendChild(position_Z);
                Eltransform.AppendChild(rotation_X);
                Eltransform.AppendChild(rotation_Y);
                Eltransform.AppendChild(rotation_Z);

               // XmlElement Elrotation = xmldoc.CreateElement(trans[i].name + "rotation");

                //XmlElement rotation_X = xmldoc.CreateElement("x");
                //rotation_X.InnerText = trans[i].eulerAngles.x.ToString();
                //XmlElement rotation_Y = xmldoc.CreateElement("y");
                //rotation_Y.InnerText = trans[i].eulerAngles.y.ToString();
                //XmlElement rotation_Z = xmldoc.CreateElement("z");
                //rotation_Z.InnerText = trans[i].eulerAngles.z.ToString();


                //Elrotation.AppendChild(rotation_X);
                //Elrotation.AppendChild(rotation_Y);
                //Elrotation.AppendChild(rotation_Z);

                root.AppendChild(Eltransform);
            }
            xmldoc.AppendChild(root);

            xmldoc.Save(path);

            Debug.Log("CreateXML OK!!!");
        }
    }


    public static void UpdateXML(string path, Transform trans) 
    {
        if (File.Exists(path))
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNodeList nodelist = xmldoc.SelectSingleNode("ProItems").ChildNodes;
            for (int i = 0; i < nodelist.Count; i++)
            {
                if (nodelist[i].Name.Equals(trans.name))
                {
                    XmlNodeList childnode = nodelist[i].ChildNodes;
                    for (int j = 0; j < childnode.Count; j++)
                    {
                        switch (childnode[j].Name)
                        {
                                case "Tx":
                                childnode[j].InnerText = trans.position.x.ToString();
                                break;
                                 case "Ty":
                                childnode[j].InnerText = trans.position.y.ToString();
                                break;
                                 case "Tz":
                                childnode[j].InnerText = trans.position.z.ToString();
                                break;
                                 case "Rx":
                                childnode[j].InnerText = trans.eulerAngles.x.ToString();
                                break;
                                 case "Ry" :
                                childnode[j].InnerText = trans.eulerAngles.y.ToString();
                                break;
                                 case "Rz":
                                childnode[j].InnerText = trans.eulerAngles.z.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }


    public static List<Transform> ReadXML(string path) 
    {
        List<Transform> transforms = new List<Transform>();
        if (File.Exists(path))
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNodeList nodelist = xmldoc.SelectSingleNode("ProItems").ChildNodes;
            for (int i = 0; i < nodelist.Count; i++)
            {
                Transform t = null;
                Vector3 pos = Vector3.zero;
                Vector3 rot = Vector3.zero;
                XmlNodeList childnode = nodelist[i].ChildNodes;
                for (int j = 0; j < childnode.Count; j++)
                {
                    switch (childnode[j].Name)
                    {
                        case "Tx":
                            pos.x = float.Parse(childnode[j].InnerText); break;
                        case "Ty":
                            pos.y = float.Parse(childnode[j].InnerText);
                            break;
                        case "Tz":
                            pos.z = float.Parse(childnode[j].InnerText);
                            break;
                        case "Rx":
                            rot.x = float.Parse(childnode[j].InnerText);
                            break;
                        case "Ry":
                            rot.y = float.Parse(childnode[j].InnerText);
                            break;
                        case "Rz":
                            rot.z = float.Parse(childnode[j].InnerText);
                            break;
                        default:
                            break;
                    }
                }
                t.position = pos;
                t.eulerAngles = rot;
                transforms.Add(t);
            }
            return transforms;
        }
        else {
            return null;
        }
    }

}
