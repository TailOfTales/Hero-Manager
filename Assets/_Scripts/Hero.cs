using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    public const string HP = "HP";
    public const string DAMAGE = "DAMAGE";
    public const string DEFENCE = "DEFENCE";
    public const string MOTIVATION = "MOTIVATION";
    public const string KINDNESS = "KINDNESS";
    public const string INDEPENDENCE = "INDEPENDENCE";
    public const string LEADERSHIP = "LEADERSHIP";
    public const string MAGIC = "MAGIC";
    public const string PHYSIC = "PHYSIC";
    public const string PACIFIC = "PACIFIC";

    public ushort id;
    public string name;
    public bool sex;
    public string biography;

    public List<StatModifier> effects;
    public List<Skill> skills;
    public Item[] items;   //четыре
    public Sprite[] sprite;

    public Dictionary<string, float> baseStats;
    public Dictionary<string, float> trueStats;

    public Hero()
    {
        id = 0;
        name = "JoJo";
        sex = true;
        biography = "Жил был, никого не трогал. Как вдруг ДИО.";

        skills = new List<Skill>();
        effects = new List<StatModifier>();


        baseStats = new Dictionary<string, float>();
        baseStats.Add(HP, 100.0f);
        baseStats.Add(DAMAGE, 5.0f);
        baseStats.Add(DEFENCE, 10.0f);
        baseStats.Add(MOTIVATION, 20.0f);
        baseStats.Add(KINDNESS, -20.0f);
        baseStats.Add(INDEPENDENCE, 2.0f);
        baseStats.Add(LEADERSHIP, 4.0f);
        baseStats.Add(MAGIC, 50.0f);
        baseStats.Add(PHYSIC, 20.0f);
        baseStats.Add(PACIFIC, 34.0f);

        trueStats = new Dictionary<string, float>(baseStats);
    }

    public void learnSkill(Skill skill)
    {
        this.skills.Add(skill);
    }

    public void calculateStats ()
    {
        trueStats = new Dictionary<string, float>(baseStats);
        foreach (StatModifier stat in effects)
        {
            trueStats[stat.statAffected] += stat.amount;
            Debug.Log(name + " " + stat.statAffected + " " + stat.amount + " affected");
        }
    }

    public void setEffect(List<StatModifier> effects)
    {
        this.effects.AddRange(effects);
    }

    public string toString()
    {
        return "\"" + name + "\"" + " HP = " + trueStats[Hero.HP] +
            "; DEFENCE = " + trueStats[Hero.DEFENCE] +
            "; DAMAGE = " + trueStats[Hero.DAMAGE];
    }
}
