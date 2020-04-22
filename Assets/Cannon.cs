using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public bool left_side;
    public GameObject cannonBall;
    bool fired = false;
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = new Vector3(0, -9.8f, 0);

    // Start is called before the first frame update
    void Start()
    {
      position = cannonBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      if(fired)
      {
        cannonBall.transform.position = position;
        position += velocity * Time.deltaTime + acceleration * Time.deltaTime / 2;

      }
    }

    public void Fire(int power)
    {
      cannonBall.SetActive(true);
      fired = true;
      if(left_side)
      {
        velocity = new Vector3(Mathf.Cos(ControlMgr.inst.player_entity.heading + 90), 0, Mathf.Sin(ControlMgr.inst.player_entity.heading + 90));
      }
      else
      {
        velocity = new Vector3(Mathf.Cos(ControlMgr.inst.player_entity.heading - 90), 0, Mathf.Sin(ControlMgr.inst.player_entity.heading - 90));
      }
      velocity *= power;
    }
}
