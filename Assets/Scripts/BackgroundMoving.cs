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
<<<<<<< HEAD
    //annyonghaseyo
=======
    // confilict tới nơi rồi này
    // quên không checkout ạ
>>>>>>> e6dfc9358d699b6aa02d9b0ec174be482ebf8727
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
