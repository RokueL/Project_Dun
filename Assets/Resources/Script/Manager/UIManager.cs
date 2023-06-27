using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    public SpriteAtlas atlas;
    public GameObject InventoryUI;
    GameObject RootUI;
    bool InvenBool;
    bool RootBool = false;

    public int RootitemId;
    int Invenitem;
    string spName = "";

    public Slot[] RootSlots;
    public Slot[] InvenSlots;

    public Transform RootHold, InvenHold;

    // Start is called before the first frame update
    void Start()
    {
        RootSlots = RootHold.GetComponentsInChildren<Slot>();
        InvenSlots = InvenHold.GetComponentsInChildren<Slot>();

        InventoryUI = GameObject.Find("InventoryUI");
        RootUI = GameObject.Find("RootUI");
        InvenBool = false;
        InventoryUI.SetActive(InvenBool);
        RootUI.SetActive(InvenBool);



    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InventoryOpen()
    {
            InvenBool = !InvenBool;
            InventoryUI.SetActive(InvenBool);


    }

    public void RootOpen()
    {
        RaycastHit rayHit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2f, new Color(1, 0, 0), 2f);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit, 2f, LayerMask.GetMask("Chest")))
        {
            RootBool = !RootBool;
            RootUI.SetActive(RootBool);

            var chest = rayHit.transform.GetComponent<Chest>();
            if(chest.openCheck == false)
            {
                AcquireItem(chest);
                chest.openCheck = true;
            }
            else
            {
                return;
            }
            //상자의 아이템 코드 값 접근 후 data 변수에 정보 값 찾아 넣기
            
            
        }
        else if(RootBool == true)
        {
            RootBool = !RootBool;
            RootUI.SetActive(RootBool);
        }
    }

    public void AllClose()
    {
        RootBool = false;
        InvenBool = false;
        InventoryUI.SetActive(InvenBool);
        RootUI.SetActive(RootBool);
        
    }
    public void AcquireItem(Chest chest)
    {

            for (int i = 0; i < RootSlots.Length; i++)
            {
                if (RootSlots[i].id == null || RootSlots[i].id == 0)
                {
                    var slots = RootSlots[i].GetComponent<Slot>();
                    Debug.Log(RootSlots[i]);
                    slots.AddItem(chest);
                    return;
                }
            }
        
    }

     
}
