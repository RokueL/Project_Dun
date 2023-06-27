using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    TestManager TM;

    LayerMask layerMaskk;
    void Check()
    {
        RaycastHit rayHit;

        Vector3 point = this.transform.rotation * Vector3.forward;

        Debug.DrawRay(this.transform.position + point, this.transform.rotation * Vector3.forward * 2, new Color(0, 0, 1), 50);
            if (Physics.Raycast(this.transform.position + point, this.transform.rotation * Vector3.forward, out rayHit, 3f, layerMaskk) == false)
            {
                  int j = Random.Range(0, 10);
                   if (j >= 4)
                   {
                      TM.RoomMaker(this.transform);
                      TM.i++;
                    }
                   else
                  {
                      TM.WallMaker(this.transform);
                    }
             }

    }

    void Start()
    {
        TM = GameObject.Find("TestManager").GetComponent<TestManager>();
        layerMaskk = LayerMask.GetMask("Room");
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
