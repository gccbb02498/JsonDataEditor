namespace Common.dataBase;

[Serializable]
public class SkillData : BaseData
{
    private string _aniName = null!;
    private float _aniTime;
    private int _applyRole;
    private int _applyTime;
    private int _coldTime;
    private string _effectName = null!;
    private string _iconName = null!;
    private int _level;
    private int _mpCost;
    private float _releaseDistance;
    private ReleaseType _releaseType;
    private int _skillId;
    private string _skillName = null!;
    private ApplyProperty _applyProperty;
    private ApplyType _applyType;
    private int _applyValue;
    private string _des = null!;

    public SkillData(int skillId)
    {
        SkillID = skillId;
    }

    public int SkillID
    {
        get => _skillId;
        set => _skillId = value;
    }

    public string SkillName
    {
        get => _skillName;
        set => _skillName = value;
    }

    public string Icon_name
    {
        get => _iconName;
        set => _iconName = value;
    }

    public string Des
    {
        get => _des;
        set => _des = value;
    }

    public int ApplyValue
    {
        get => _applyValue;
        set => _applyValue = value;
    }

    public int ApplyTime
    {
        get => _applyTime;
        set => _applyTime = value;
    }

    public int MpCost
    {
        get => _mpCost;
        set => _mpCost = value;
    }

    public int ColdTime
    {
        get => _coldTime;
        set => _coldTime = value;
    }

    public int ApplyRole
    {
        get => _applyRole;
        set => _applyRole = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
    }

    public float ReleaseDistance
    {
        get => _releaseDistance;
        set => _releaseDistance = value;
    }

    public string EffectName
    {
        get => _effectName;
        set => _effectName = value;
    }

    public string AniName
    {
        get => _aniName;
        set => _aniName = value;
    }

    public float AniTime
    {
        get => _aniTime;
        set => _aniTime = value;
    }

    public ApplyType ApplyType
    {
        get => _applyType;
        set => _applyType = value;
    }

    public ApplyProperty ApplyProperty
    {
        get => _applyProperty;
        set => _applyProperty = value;
    }

    public ReleaseType ReleaseType
    {
        get => _releaseType;
        set => _releaseType = value;
    }


    public int GetId()
    {
        return _skillId;
    }
}

public enum ApplyProperty
{
    Attack,
    Defense,
    AttackSpeed,
    Hp,
    Mp
}

public enum ReleaseType
{
    Self,
    Enemy,
    Position
}

public enum ApplyType
{
    Swordman,
    Magician
}