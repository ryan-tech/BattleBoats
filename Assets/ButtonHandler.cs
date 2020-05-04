using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public void HideUI()
    {
      GameMgr.inst.upgrade_menu.SetActive(false);
    }

    public void ResetGame()
    {
      GameMgr.inst.game_over_screen.SetActive(false);
      GameMgr.inst.treasure_count = 0;
    }

    public void IncreaseSpeed()
    {
      if(GameMgr.inst.treasure_count > 0 && GameMgr.inst.player_ent.maxSpeed < 100)
      {
        //Decrease treasure, increase speed
        GameMgr.inst.treasure_count -= 1;
        GameMgr.inst.player_ent.maxSpeed += GameMgr.inst.delta_ship_speed;
        GameMgr.inst.player_ent.acceleration += GameMgr.inst.delta_ship_speed;
      }
      else if(GameMgr.inst.player_ent.maxSpeed >= 100)
      {
        GameMgr.inst.player_ent.maxSpeed = 100;
      }
    }

    public void IncreaseHealth()
    {
      if(GameMgr.inst.treasure_count > 0 && GameMgr.inst.player_ent.maxHealth < 10)
      {
        //Decrease treasure, increase health
        GameMgr.inst.treasure_count -= 1;
        GameMgr.inst.player_ent.maxHealth += GameMgr.inst.delta_ship_health;
      }
      else if(GameMgr.inst.player_ent.maxHealth >= 10)
      {
        GameMgr.inst.player_ent.maxHealth = 10;
      }
    }

    public void IncreaseCannonDmg()
    {
      //max damage = 5
      if(GameMgr.inst.treasure_count > 0 && GameMgr.inst.player_ent.cannonDmg < 5)
      {
        GameMgr.inst.treasure_count -= 1;
        GameMgr.inst.player_ent.cannonDmg += GameMgr.inst.delta_cannon_dmg;
      }
      else if(GameMgr.inst.player_ent.cannonDmg >= 5)
      {
        GameMgr.inst.player_ent.cannonDmg = 5;
      }
    }

    public void IncreaseCannonRange()
    {
      //max damage = 5
      if(GameMgr.inst.treasure_count > 0 && GameMgr.inst.player_ent.cannonRange < 50)
      {
        GameMgr.inst.treasure_count -= 1;
        GameMgr.inst.player_ent.cannonRange += GameMgr.inst.delta_cannon_range;
      }
      else if(GameMgr.inst.player_ent.cannonRange >= 50)
      {
        GameMgr.inst.player_ent.cannonRange = 50;
      }
    }

}
