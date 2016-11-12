using System.Collections.Generic;

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
    }

    public void recruitHero(Hero hero)
    {
        heroes.Add(hero);
    }
}
