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
        //�ӽ� �ε��� ���� ���� ĭ ���� ����
        Chest _chest = Chest;
        Image _tempIcon = icon;
        int _tempItemId = id;

        //�ش� ĭ�� �巡�� �ϰ� �ִ� ������ ���� �߰�
        AddItem(DragSlot.instance.dragSlot.Chest);

        //�ش� ĭ�� �������� ������ �ӽ� �ε��� ���� �巡�� �ϴ� ĭ�� ������ ĭ�� ���� �߰�
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
    
    //������ ��� �� �� �ڸ��� ������ �߰� Ȥ�� �������� ������ ������ �� ����
    public void AddItem(Chest chest) 
    {
        //ItemSlot.SetActive(true);
        Chest = chest;
        icon.sprite = chest.itemImage;
        id = chest.itemId;
        SetColor(1);
    }

    //�ش� ĭ�� ����� �� ���� ������ ������ �����Ͽ� ��ĭ���� ����
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
