using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    public const string MAX_HP = "MAX_HP";
    public const string CURRENT_HP = "CURRENT_HP";
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

    public Hero(ushort id)
    {
        this.id = id;
        name = "JoJo" + Random.Range(1, 20);
        int Lala = Random.Range(0, 6);
        if (Lala%2 == 1)
        {
            sex = true;
        } else
        {
            sex = false;
        }
        biography = Random.Range(0,100).ToString();

        skills = new List<Skill>();
        effects = new List<StatModifier>();

        baseStats = new Dictionary<string, float>();
        baseStats.Add(MAX_HP, Random.Range(90, 110));
        baseStats.Add(CURRENT_HP, Random.Range(90, 110));
        baseStats.Add(DAMAGE, Random.Range(5, 15));
        baseStats.Add(DEFENCE, Random.Range(10, 20));
        baseStats.Add(MOTIVATION, Random.Range(10, 50));
        baseStats.Add(KINDNESS, Random.Range(-100, 100));
        baseStats.Add(INDEPENDENCE, Random.Range(0, 50));
        baseStats.Add(LEADERSHIP, Random.Range(1, 5));
        baseStats.Add(MAGIC, Random.Range(0, 100));
        baseStats.Add(PHYSIC, Random.Range(0, 100));
        baseStats.Add(PACIFIC, Random.Range(0, 100));

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
        }
    }

    public void setEffect(List<StatModifier> effects)
    {
        this.effects.AddRange(effects);
    }

    public string toString()
    {
        return "\"" + name + "\"" + " Характеристики" 
            + "\nHP = " + trueStats[Hero.CURRENT_HP] + "/" + trueStats[Hero.MAX_HP]
            + "\nDEFENCE = " + trueStats[Hero.DEFENCE]
            + "\nDAMAGE = " + trueStats[Hero.DAMAGE]
            + "\nMOTIVATION = " + trueStats[Hero.MOTIVATION]
            + "\nKINDNESS = " + trueStats[Hero.KINDNESS]
            + "\nINDEPENDENCE = " + trueStats[Hero.INDEPENDENCE]
            + "\nLEADERSHIP = " + trueStats[Hero.LEADERSHIP]
            + "\nMAGIC = " + trueStats[Hero.MAGIC]
            + "\nPHYSIC = " + trueStats[Hero.PHYSIC]
            + "\nPACIFIC = " + trueStats[Hero.PACIFIC];
    }


}
