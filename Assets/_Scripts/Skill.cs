using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

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
}


public class SkillDatabase
{
    public List<Skill> skills { get; set; }

    public SkillDatabase()
    {

        skills = JsonConvert.DeserializeObject<List<Skill>>(Resources
            .Load<TextAsset>("SkillDatabase").text);
        if (skills == null)
            skills = new List<Skill>();
    }
}