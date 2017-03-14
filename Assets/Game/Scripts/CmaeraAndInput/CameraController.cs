using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public Transform[] ControlPath;

	private Vector3 playerPos;
	private Transform player;
    public Transform TarTransform;
    private float f_timer;

    private Transform go_subObj;

    private Vector3 v3_originPos;
    private Vector3 v3_originRot;

     //public Transform targer;    
    public float xSpeed = 200;
    public float ySpeed = 200;
    public float mSpeed = 10;
    public float yMinLimit = -50;
    public float yMaxLimit = 50;
    public float distance = 10;
    public float minDistance = 2;
    public float maxDistance = 30;

    //bool needDamping = false;  
    public bool needDamping = true;
    float damping = 5.0f;

    public float x = 0.0f;
    public float y = 0.0f;
    public float h = 0.0f;

    void Awake()
    {
        Debug.Log(distance);
        Instance = this;
    }

    // Use this for initialization  
    void Start()
    {
        go_subObj = transform.Find("3DCamera (1)");
        v3_originPos = transform.position;
        v3_originRot = transform.eulerAngles;
		player = GameObject.FindGameObjectWithTag("Player").transform.Find("targetPoint");
		playerPos = player.position;
		TarTransform = player;
            
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
		h = player.position.y;
    }

    public bool bl_isMove=false;
    public bool bl_isChange = false;
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (!bl_isChange)
        //    {
        //        bl_isChange = true;
        //        foreach (GameObject o in UIManager._instance.ChangeList)
        //        {
        //            if (!o.name.Equals("YaoJi") && !o.name.Equals("ChangWei") && !o.name.Equals("JingBu"))
        //            {
        //                o.SetActive(true);
        //            }
        //        }
        //        UIManager._instance.HideSkin();
        //    }
        //    else
        //    {
        //        bl_isChange = false;
        //        UIManager._instance.DisplaySkin();
        //    }
        //}       

        //if (Vector3.Distance(transform.position,ControlPath[int_index].position)<0.01f)
        //{
        //    bl_isMove = false;
        //}

        //if (bl_isMove)
        //{
        //    go_subObj.LookAt(TarTransform);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, go_subObj.rotation, Time.deltaTime * 30);
        //    transform.position = Vector3.Lerp(transform.position, ControlPath[int_index].position, Time.deltaTime * 10);            
        //}
    }

    // Update is called once per frame  
    void LateUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())return;                  
        
        if (TarTransform)
        {        
            if (Input.GetMouseButton(2))
            {
                h -= Input.GetAxis("Mouse Y") * Time.deltaTime*5f;
                h = Mathf.Clamp(h, 0, 1.8f);
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                        
                TarTransform.position=new Vector3(TarTransform.position.x,h,TarTransform.position.z);
            }
            
            //use the light button of mouse to rotate the camera
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            }
           
            distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
          
            Vector3 position = rotation * disVector + TarTransform.position;
            //adjust the camera  
            if (needDamping)
            {           
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = position;
            }
        }
        else if (TarTransform )
        {
            if (Input.GetMouseButton(0))
            {
                float v = Input.GetAxis("Mouse X");
                //float h = Input.GetAxis("Mouse Y");

                if (v != 0)
                {
                    transform.RotateAround(TarTransform.position, TarTransform.up, v * 10);                    
                }
            }
        }
    }

    public List<string> Messages=new List<string>();
    /// <summary>
    /// 接收网页的消息
    /// </summary>
    /// <param name="str"></param>
    //public void HtmlMessage(string str)
    //{
    //    //Debug.Log(str+"接收到的消息---------------------------------------------------");
    //    string[] strings = str.Split('&');
    //    string code = strings[0].Trim();
    //    string subCode=null;
    //    if (code == "7" || code == "8" || code == "9" || code == "10" || code == "11" || code == "12")
    //    {
    //        subCode = "7";
    //    }
    //    else
    //    {
    //        subCode = code;
    //    }
    //    string index = strings[1].Trim();
        
    //    ElementInfo elementInfo;
    //    bool bl= UIManager._instance.ElementDic.TryGetValue(subCode, out elementInfo);
    //    if (bl)
    //    {    
    //        switch (elementInfo.effectType)
    //        {
    //            case EffectType.Change3D:       
    //                OptionController optionController;
    //                    if (UIManager._instance.optionDic.TryGetValue(code,out optionController))
    //                    {                                      
    //                        if (index == "0")
    //                        {
    //                            if (code=="23"||code=="17"||code=="15")
    //                            {                                    
    //                                optionController.ShowNormalAll(false);
    //                            }
    //                            else
    //                            {
    //                                optionController.ShowNormal(false);    
    //                            }
                                
    //                        }
    //                        else if (index == "1")
    //                        {
    //                            if (code == "23" || code == "17" || code == "15")
    //                            {

    //                                optionController.ShowChangeAll(false);
    //                            }
    //                            else
    //                            {
    //                                optionController.ShowChange(false); 
    //                            }                                    
    //                        }
    //                        else
    //                        {
    //                            throw new Exception("Invalid code");
    //                        }                        
    //                    }                        
    //            break;             

    //            case EffectType.DropDown:

    //                NumDropdownManager numDropdownManager;
    //                if (UIManager._instance.ListNumDictionary.TryGetValue(subCode, out numDropdownManager))
    //                {
    //                    numDropdownManager.SetManage(index);                        
    //                }
                    
    //            break;
    //                case EffectType.DropNum:                    
    //                if (UIManager._instance.ListNumDictionary.TryGetValue(subCode, out numDropdownManager))
    //                {
    //                    string clickName="";
    //                    switch (code)
    //                    {
    //                        case "7":
    //                            clickName = "正常呼吸";
    //                            break;
    //                        case "8":
    //                            clickName = "库斯摩呼吸";
    //                            break;
    //                        case "9":
    //                            clickName = "潮式呼吸";
    //                            break;
    //                        case "10":
    //                            clickName = "毕奥呼吸";
    //                            break;
    //                        case "11":
    //                            clickName = "长吸式呼吸";
    //                            break;
    //                        case "12":
    //                            clickName = "呼吸暂停";
    //                            break;                           
    //                    }
    //                    numDropdownManager.SetManage(clickName, code, index,false);
    //                }
    //                break;
    //                case EffectType.OptionSlider:
    //                OptionSliderController optionSliderController;
    //                if (UIManager._instance.OptionSliderDic.TryGetValue(subCode, out optionSliderController))
    //                {
    //                    if (index.Equals("0"))    
    //                    {
    //                        optionSliderController.SelectSliderOption(true);
    //                    }
    //                    else
    //                    {
    //                        optionSliderController.SelectSliderOption(false);
    //                    }
                        
    //                }   
    //                break;
    //        }        
    //    }
    //    else
    //    {
    //        Messages.Add(str);          
    //    }        
    //}

    //static float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360)
    //        angle += 360;
    //    if (angle > 360)
    //        angle -= 360;
    //    return Mathf.Clamp(angle, min, max);
    //}

    //private int int_index;
    //public void MoveToTarget(string pointId,string tarModelName)
    //{
    //    UIManager._instance.PlayerState=PlayerState.Change;                
    //    int_index = Int32.Parse(pointId);

    //    GameObject go;
    //    bool bl= UIManager._instance.ChangeDic.TryGetValue(tarModelName, out go);

    //    if (bl)
    //    {
    //        TarTransform = go.transform;
    //        transform.LookAt(TarTransform);
    //        //iTween.MoveTo(gameObject,ControlPath[index].position,0.5f);
    //        bl_isMove = true;                                   
    //    }
    //}

    //public void Init()
    //{
    //    UIManager uiManager = UIManager._instance;
    //    x = v3_originRot.y;
    //    y = v3_originRot.x;
    //    uiManager.PlayerState = PlayerState.Normal;        
    //    transform.position = v3_originPos;
    //    distance = 3;
    //    TarTransform = player;
    //    TarTransform.position = playerPos;
    //    h = playerPos.y;
    //    uiManager.DisplaySkin();
    //    uiManager.NeiZang.SetActive(true);
    //    transform.LookAt(TarTransform);
    //    if (UIManager._instance.LastGameObject.activeSelf)
    //    {
    //        UIManager._instance.LastGameObject.SetActive(false);
    //    }        
    //}        
}