using System;
using System.Collections.Generic;

[Serializable]
public class SkillDatas {
    public List<SkillData> skillDatas;

    public SkillDatas(List<SkillData> list){
        this.skillDatas = list;
    }

    
}
[Serializable]
public class SkillData {
    private int skillID;
    private string skillName;
    private string imagePath;

    public int SkillID { get => skillID; set => skillID = value; }
    public string SkillName { get => skillName; set => skillName = value; }
    public string ImagePath { get => imagePath; set => imagePath = value; }

    public SkillData() {
    }

    public SkillData(int SkillId) {
        this.SkillID = SkillId;
    }
}
