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
      GameMgr.inst.gold_earned = 0;
      Text txt = GameMgr.inst.gold_ui.GetComponent<Text>();
      txt.text = GameMgr.inst.gold_earned.ToString();
      GameMgr.inst.upgrade_menu.transform.Find("treasure_val").GetComponent<Text>().text = GameMgr.inst.gold_earned.ToString();
    }
}
