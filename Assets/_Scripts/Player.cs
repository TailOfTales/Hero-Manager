using System.Collections.Generic;

public class Player
{
    public int coins;
    public uint donateCoins;
    public uint playTime;
    public List<Perk> perks;
    public List<Hero> heroes;
    public List<Item> inventory;

    public Player ()
    {
        coins = 0;
        donateCoins = 0;
        playTime = 0;
        perks = new List<Perk>();
        heroes = new List<Hero>();
        inventory = new List<Item>();
    }

    public List<Hero> getHeroes()
    {
        return heroes;
    }

    public void recruitHero(Hero hero)
    {
        heroes.Add(hero);
    }
}
