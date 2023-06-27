using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Chest : MonoBehaviour
{
    int _ranItemId,_ranOp;

    public bool openCheck = false;

    public int itemId;
    public Sprite itemImage;
    public string itemInfo;
    
    string spName;

    int optionID;

    public SpriteAtlas atlas;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.GetInstance().LoadDatas();
        _ranItemId = Random.Range(1001, 1009);
        var data = DataManager.GetInstance().dicItemDatas[_ranItemId];

        _ranOp = Random.Range(101, 104);
        var Odata = DataManager.GetInstance().dicOptionDatas[_ranOp];

        Debug.Log(Odata.OpName);

        spName = data.Sprite_name;
        //Debug.Log(spName);
        Sprite sp = this.atlas.GetSprite(spName);
        itemImage = sp;
        itemId = data.Id;
        itemInfo = data.Info;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
