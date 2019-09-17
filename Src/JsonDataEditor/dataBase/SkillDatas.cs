using System;
using System.Collections.Generic;

namespace JsonDataEditor.dataBase
{
    [Serializable]
    public class SkillDatas
    {
        public List<SkillInfo> skillDatas;

        public SkillDatas(List<SkillInfo> list)
        {
            this.skillDatas = list;
        }
    }
    
    [Serializable]
    public class SkillInfo : BaseData
    {
       
        private int skillID;
        private string skillName;
        private string icon_name;
        private string des;
        private ApplyType applyType;
        private ApplyProperty aplyProperty;
        private int applyValue;
        private int applyTime;
        private int mpCost;
        private int coldTime;
        private int applyRole;
        private int level;
        private ReleaseType releaseType;
        private float releaseDistance;
        private string effectName;
        private string aniName;
        private float aniTime;

        public int SkillID { get => skillID; set => skillID = value; }
        public string SkillName { get => skillName; set => skillName = value; }
        public string Icon_name { get => icon_name; set => icon_name = value; }
        public string Des { get => des; set => des = value; }
        public int ApplyValue { get => applyValue; set => applyValue = value; }
        public int ApplyTime { get => applyTime; set => applyTime = value; }
        public int MpCost { get => mpCost; set => mpCost = value; }
        public int ColdTime { get => coldTime; set => coldTime = value; }
        public int ApplyRole { get => applyRole; set => applyRole = value; }
        public int Level { get => level; set => level = value; }
        public float ReleaseDistance { get => releaseDistance; set => releaseDistance = value; }
        public string EffectName { get => effectName; set => effectName = value; }
        public string AniName { get => aniName; set => aniName = value; }
        public float AniTime { get => aniTime; set => aniTime = value; }
        internal ApplyType ApplyType { get => applyType; set => applyType = value; }
        internal ApplyProperty AplyProperty { get => aplyProperty; set => aplyProperty = value; }
        internal ReleaseType ReleaseType { get => releaseType; set => releaseType = value; }

        public SkillInfo()
        {
            basetype = Basetype.SkillInfo;
        }

        public SkillInfo(int SkillId)
        {
            this.SkillID = SkillId;
        }
    }

    internal enum ApplyProperty
    {
        Attack,
        Defense,
        AttackSpeed,
        Hp,
        Mp
    }

    internal enum ReleaseType
    {
        Self,
        Enemy,
        Position
    }

    internal enum ApplyType
    {
        Swordman,
        Magician
    }
}