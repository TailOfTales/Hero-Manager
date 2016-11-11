using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    public ushort id;
    public string name;
    public bool sex;
    public string biography;

    public List<StatModifier> effects;
    public List<Skill> skills;
    public Item[] items;   //четыре
    public Sprite[] sprite;

    public List<StatModifier> getEffects()
    {
        return effects;
    }

    public void setEffect(List<StatModifier> effects)
    {
        effects.AddRange(effects);
    }

    public ushort getId()
    {
        return id;
    }

    public string getName()
    {
        return name;
    }

    public bool getSex()
    {
        return sex;
    }

    public string getBiography()
    {
        return biography;
    }

    public List<Skill> getSkills()
    {
        return skills;
    }

    public Dictionary<string, float> baseStats;
    public Dictionary<string, float> trueStats;

    public Dictionary<string, float> getTrueStats()
    {
        return trueStats;
    }

    public const string HP = "hp";
    public const string DAMAGE = "damage";
    public const string DEFENCE = "defence";
    public const string MOTIVATION = "motivation";
    public const string KINDNESS = "kindness";
    public const string INDEPENDENCE = "independence";
    public const string LEADERSHIP = "leadership";
    public const string MAGIC = "magic";
    public const string PHYSIC = "physic";
    public const string PACIFIC = "pacific";

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
        skills.Add(skill);
    }

    public void calculateStats ()
    {
        trueStats = new Dictionary<string, float>(baseStats);
        foreach (StatModifier stat in effects)
        {
            trueStats[stat.getStatAffected()] += stat.getAmount();
        }
    }
}
