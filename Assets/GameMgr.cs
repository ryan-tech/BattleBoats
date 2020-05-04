using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject upgrade_menu;
    public GameObject game_over_screen;
    public GameObject gold_ui;

    public Entity381 player_ent;
    public int delta_ship_speed;
    public int delta_ship_health;
    public int delta_cannon_dmg;
    public int delta_cannon_range;

    // treasure_count is going to be the main variable to store treasure;
    public int treasure_count;

    // Update is called once per frame
    void Update()
    {
      //keeps treasure updated on the gui
      Text txt = gold_ui.GetComponent<Text>();
      txt.text = treasure_count.ToString();

      //Updates Gold Values
      // This will be updated in the future to be when an enemy ship dies
      if(Input.GetKeyUp(KeyCode.F))
      {
        treasure_count += 1;
      }

      // Game over screen
      // Will be changed to happen when you die
      if(Input.GetKeyUp(KeyCode.I))
      {
        game_over_screen.SetActive(true);
      }

      HandleTreasureUpdateAfterEnemyDies();
      UpdateUpgradeUI();
    }


    void UpdateUpgradeUI()
    {
      // Opens upgrade menu
      if(Input.GetKeyUp(KeyCode.U))
      {
        upgrade_menu.SetActive(true);
      }
      upgrade_menu.transform.Find("treasure_val").GetComponent<Text>().text = treasure_count.ToString();
      upgrade_menu.transform.Find("CurrentShipSpeed").GetComponent<Text>().text = player_ent.maxSpeed.ToString();
      upgrade_menu.transform.Find("CurrentShipHealth").GetComponent<Text>().text = player_ent.maxHealth.ToString();
      upgrade_menu.transform.Find("CurrentCannonDmg").GetComponent<Text>().text = player_ent.cannonDmg.ToString();
      upgrade_menu.transform.Find("CurrentCannonRange").GetComponent<Text>().text = player_ent.cannonRange.ToString();
    }

    void HandleTreasureUpdateAfterEnemyDies()
    {
      foreach(GameObject e in EnemyMgr.inst.enemies)
      {
        Entity381 enemy_entity = e.GetComponent<Entity381>();
        if(enemy_entity.currentHealth == 0 && !enemy_entity.dead)
        {
          treasure_count += 1;
          e.SetActive(false);
          enemy_entity.dead = true;
        }
      }
    }
}
