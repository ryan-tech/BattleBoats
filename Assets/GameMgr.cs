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
    public int gold_earned;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.U))
        {
          upgrade_menu.SetActive(true);
          //inst.transform.parent.SetActive(true);
        }

        //Updates Gold Values
        // This will be updated in the future to be when an enemy ship dies
        if(Input.GetKeyUp(KeyCode.F))
        {
          gold_earned += 1;
          Text txt = gold_ui.GetComponent<Text>();
          txt.text = gold_earned.ToString();
          upgrade_menu.transform.Find("treasure_val").GetComponent<Text>().text = gold_earned.ToString();
        }

        if(Input.GetKeyUp(KeyCode.I))
        {
          game_over_screen.SetActive(true);
        }


    }

    
}
