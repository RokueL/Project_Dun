using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DataManager
{
    private static DataManager instance;
    public Dictionary<int, ItemData> dicItemDatas;
    public Dictionary<int, OptionData> dicOptionDatas;

    private DataManager()
    {

    }

    public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }
        return DataManager.instance;
    }
   
    public void LoadDatas()
    {
        var json = Resources.Load<TextAsset>("ItemData/ItemData").text;
        var arrItemData = JsonConvert.DeserializeObject<ItemData[]>(json);
        this.dicItemDatas = arrItemData.ToDictionary(x => x.Id);

        var Opjson = Resources.Load<TextAsset>("ItemData/OptionData").text;
        var arrOptionData = JsonConvert.DeserializeObject<OptionData[]>(Opjson);
        this.dicOptionDatas = arrOptionData.ToDictionary(y => y.Id);
    }

}
