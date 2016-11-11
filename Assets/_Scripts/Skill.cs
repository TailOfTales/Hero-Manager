using System.Collections.Generic;

public class Skill
{
    public ushort id;
    public string name;
    public string description;
    public bool isActive;
    public bool isAura;
    public byte phase;
    public List<StatModifier> statModifiers;

    public Skill (ushort id, string name, string description, bool isActive, bool isAura, byte phase
        , List<StatModifier> statModifiers)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.isActive = isActive;
        this.isAura = isAura;
        this.phase = phase;
        this.statModifiers = statModifiers;
    }

    public ushort getId()
    {
        return id;
    }
    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return description;
    }
    public bool getIsActive()
    {
        return isActive;
    }
    public bool getIsAura()
    {
        return isAura;
    }
    public byte getPhase()
    {
        return phase;
    }
    public List<StatModifier> getStatModifiers()
    {
        return statModifiers;
    }
}

public class StatModifier
{
    public string statAffected;
    public float amount;

    public StatModifier(string statAffected, float amount)
    {
        this.statAffected = statAffected;
        this.amount = amount;
    }

    public string getStatAffected()
    {
        return statAffected;
    }

    public float getAmount()
    {
        return amount;
    }

}

public class SkillDatabase
{
    public List<Skill> skills;
    private static SkillDatabase instance;

    private SkillDatabase()
    {
        skills = new List<Skill>();
        List<StatModifier> temp = new List<StatModifier>();
        temp.Add(new StatModifier(Hero.DEFENCE, 10.0f));
        temp.Add(new StatModifier(Hero.DAMAGE, -5.0f));
        skills.Add(new Skill(1, "Aura of battle", "Rises defence and attcak", false, true, 0, temp));
        temp.Clear();
        temp.Add(new StatModifier(Hero.HP, 5.0f));
        skills.Add(new Skill(2, "Heal time", "Heals your hero", false, false, 0, temp));
    }

    public static SkillDatabase Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkillDatabase();
            }
            return instance;
        }
    }
}