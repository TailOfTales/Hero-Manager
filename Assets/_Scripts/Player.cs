using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player
{
    public int coins;
    public uint donateCoins;
    public uint playTime;
    public List<Perk> perks;
    public List<Hero> heroes;
    public Hero[] leaders;
    public List<Item> inventory;

    public Player ()
    {
        coins = 0;
        donateCoins = 0;
        playTime = 0;
        perks = new List<Perk>();
        heroes = new List<Hero>();
        leaders = new Hero[8];
        inventory = new List<Item>();

        heroes = JsonConvert.DeserializeObject<List<Hero>>(Resources
            .Load<TextAsset>("SavedHeroes").text);
    }

    public void recruitHero(Hero hero)
    {
        heroes.Add(hero);  //ПОКЕМОН!!111!!
    }

    public void saveHeroes()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saveSlot1"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saveSlot1");
        }
        File.WriteAllText(Application.persistentDataPath + "/saveSlot1/SavedHeroes.json"
            , JsonConvert.SerializeObject(heroes));

            
    }
}
