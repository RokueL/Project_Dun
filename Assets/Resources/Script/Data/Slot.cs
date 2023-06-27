using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Vector3 _startPosition;

    public Chest Chest;
    public Image icon;
    public int id;


    public GameObject ItemSlot;

    UIManager UIManager;

    private void Start()
    {
        ItemSlot = transform.GetChild(0).gameObject;
        icon = ItemSlot.GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (id != 0)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.SetColor(255);
            DragSlot.instance.DragSetItemId(id);
            DragSlot.instance.DragSetImage(icon);

            Debug.Log(DragSlot.instance.dragSlot.Chest.itemId + DragSlot.instance.dragSlot.Chest.itemInfo);

            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (id != 0)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }
    
    private void ChangeSlot()
    {
        //임시 인덱스 값에 원래 칸 정보 저장
        Chest _chest = Chest;
        Image _tempIcon = icon;
        int _tempItemId = id;

        //해당 칸에 드래그 하고 있는 아이템 정보 추가
        AddItem(DragSlot.instance.dragSlot.Chest);

        //해당 칸에 아이템이 있으면 임시 인덱스 값을 드래그 하던 칸의 아이템 칸에 정보 추가
        if (_chest != null)
        {
            Debug.Log("Change");
            DragSlot.instance.dragSlot.AddItem(_chest);
        }
        else
        {
            Debug.Log("Clear");
            DragSlot.instance.dragSlot.ClearItem();
        }
    }
    
    //아이템 드랍 시 그 자리에 아이템 추가 혹은 아이템이 있으면 서로의 값 변경
    public void AddItem(Chest chest) 
    {
        //ItemSlot.SetActive(true);
        Chest = chest;
        icon.sprite = chest.itemImage;
        id = chest.itemId;
        SetColor(1);
    }

    //해당 칸이 비었을 시 원래 아이템 데이터 삭제하여 빈칸으로 변경
    public void ClearItem()
    {
        icon.sprite = null;
        id = 0;
        Chest = null;
        // ItemSlot.SetActive(false);
       SetColor(0);
    }

    private void SetColor(float _alpha)
    {
        Color color = icon.color;
        color.a = _alpha;
        icon.color = color;
    }
}
