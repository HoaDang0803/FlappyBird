using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveRange;
    private Vector3 oldPosition;
    private GameObject obj;
    
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
    }
    // hôm nay mình tạo nhánh mới nhe các bạn
    //annyonghaseyo
    // Update is called once per frame
    void Update()
    {
      obj.transform.Translate(new Vector3(x: -1*Time.deltaTime*moveSpeed,transform.position.y,0));

       if (Vector3.Distance(oldPosition,obj.transform.position) > moveRange)
       {
           obj.transform.position = oldPosition;
       }
    }
}
