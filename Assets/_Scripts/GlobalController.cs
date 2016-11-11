using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
        player = new Player();
        player.recruitHero(new Hero());
        player.recruitHero(new Hero());
        player.getHeroes()[0].learnSkill(SkillDatabase.Instance.skills[0]);
        player.getHeroes()[1].learnSkill(SkillDatabase.Instance.skills[1]);
        Debug.Log("Jonathan true def = " + player.getHeroes()[0].getTrueStats()[Hero.DEFENCE]);
        int phase = 0;
        if (phase == 0)
        {
            foreach (Hero hero in player.getHeroes())
            {
                foreach (Skill skill in hero.getSkills())
                {
                    if (!skill.getIsActive() && skill.getPhase()==phase)
                    {
                        if (skill.getIsAura())
                        {
                            foreach (Hero partyMember in player.getHeroes())
                            {
                                partyMember.setEffect(skill.getStatModifiers());
                            }
                        }
                        else
                        {
                            hero.setEffect(skill.getStatModifiers());
                        }
                    }
                }
            }
            foreach (Hero hero in player.getHeroes())
            {
                hero.calculateStats();
            }
        }

        Debug.Log("\nJonathan FINAL def = " + player.getHeroes()[0].getTrueStats()[Hero.DEFENCE]);
        Debug.Log("\nJoseph FINAL def = " + player.getHeroes()[1].getTrueStats()[Hero.DEFENCE]);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
