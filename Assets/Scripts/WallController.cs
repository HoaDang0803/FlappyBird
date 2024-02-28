using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallController : MonoBehaviour
{
    public List<WallMoving> wall;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (WallMoving i in wall)
        {
            i.transform.position = new Vector3(i.transform.position.x,Random.Range(4,7),0);
        }
    }

}
