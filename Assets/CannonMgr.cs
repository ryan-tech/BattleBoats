using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMgr : MonoBehaviour
{
    public static CannonMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      foreach(Cannon c in cannons)
      {
        c.cannonBall.SetActive(false);
      }
    }

    public List<Cannon> cannons;
    public int power;

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyUp(KeyCode.F))
      {
        foreach(Cannon c in cannons)
        {
          c.Fire(power);
        }
      }
    }

    /*
    bool custom_wait(int milis)
    {
      Time.deltaTime;
    }
    */
}
