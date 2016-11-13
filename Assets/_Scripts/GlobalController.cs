using Newtonsoft.Json;
using UnityEngine;

public class GlobalController : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
        player = new Player();
        SkillDatabase skillDatabase = new SkillDatabase();

        Debug.Log(player.heroes[0].toString());

        int phase = 0;
        if (phase == 0)
        {
            for (int i = 0; i < player.heroes.Count; i++)
            {
                for (int j = 0; j < player.heroes[i].skills.Count; j++)
                {
                    if (!player.heroes[i].skills[j].isActive && player.heroes[i].skills[j].phase==phase)
                    {
                        if (player.heroes[i].skills[j].isAura)
                        {
                            Debug.Log(player.heroes[i].name + " has an aura, called: " + player.heroes[i].skills[j].name);
                            for (int k = 0; k < player.heroes.Count; k++)
                            {
                                player.heroes[k].setEffect(player.heroes[i].skills[j].statModifiers);
                            }
                        }
                        else
                        {
                            Debug.Log(player.heroes[i].name + " has an passive skill, called: " + player.heroes[i].skills[j].name);
                            player.heroes[i].setEffect(player.heroes[i].skills[j].statModifiers);
                        }
                    }
                }
            }
            foreach (Hero hero in player.heroes)
            {
                hero.calculateStats();
            }
        }

        player.saveHeroes();

        Debug.Log(player.heroes[0].toString());
    }
}
