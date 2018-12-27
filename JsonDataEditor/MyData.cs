
using System;
using System.Collections.Generic;

///
///     MyData.cs
///
[Serializable]
public class MyData {
    public List<MyDataItem> items;


    public MyData(List<MyDataItem> list) {
        this.items = list;
    }
}

[Serializable]
public class MyDataItem {
   
    /// <summary>
    /// 道具ID唯一ID 區別於其他道具
    /// </summary>
    public string ItemID { get; set; }
    //item name
    public string ItemName { get; set; }
    /// <summary>
    /// 道具描述訊息
    /// </summary>
    public string ItemDesc { get; set; }

    public ITEMTYPE ItemType { get; set; }
    
    public string ItemIcon { get; set; }
    public string ItemBgIcon { get; set; }
    public string ItemCount { get; set; }
    public string ItemQuality { get; set; }

    /// <summary>
    /// 道具的操作,如分解 合成 出售 裝備等等
    /// </summary>
    public string ItemOpreation { get; set; }

    public   string GetAll() {
        string s= string.Concat("ID:",ItemID,"Name:", ItemName , "ItemDesc", ItemDesc,"\n");
        return s;
    }

    public enum ITEMTYPE {
        Unknown = -1,
        Equip=0,  //裝備
        Chips=1,  //碎片
    }
    /// <summary>
    /// 
    /// </summary>

    public MyDataItem(string itemid, string name, string desc, int itemType, string icon, string bgIcon, string itemcount, string quality, string opreation) {
        this.ItemID = itemid;
        this.ItemName = name;
        this.ItemDesc = desc;
        switch (itemType) {
            case -1:
                this.ItemType = ITEMTYPE.Unknown;
                break;
            case 0:
                this.ItemType = ITEMTYPE.Equip;
                break;
            case 1:
                this.ItemType = ITEMTYPE.Chips;
                break;
            default:
                break;
        }
        this.ItemIcon = icon;
        this.ItemBgIcon = bgIcon;
        this.ItemCount = itemcount;
        this.ItemQuality = quality;
        this.ItemOpreation = opreation;

    }

    public MyDataItem(int id) {
        this.ItemID = id.ToString();
    }

    public MyDataItem() {
        this.ItemID = 1.ToString();
        this.ItemName = "未命名";
        this.ItemType=ITEMTYPE.Unknown;
    }

    public string GetName() {
        return this.ItemName;
    }
}
