using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static Cannon inst;
    private void Awake()
    {
        inst = this;
    }
    public bool left_side;
    public GameObject cannonBall;
    public bool firing = false;
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = new Vector3(0, -5f, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if(firing)
      {
        if(position.y > 0)
        {
          cannonBall.transform.position = position;
          position += velocity * Time.deltaTime + acceleration * Time.deltaTime / 2;
        }
        else
        {
          firing = false;
        }
      }
      else
      {
        //Reset the cannonball
        cannonBall.SetActive(false);
        cannonBall.transform.position = this.transform.position;
        position = this.transform.position;
      }
    }

    public void Fire(int power)
    {
      cannonBall.SetActive(true);
      firing = true;
      position = cannonBall.transform.position;
      if(left_side)
      {
        velocity = new Vector3(Mathf.Sin(ControlMgr.inst.player_entity.heading), 0, Mathf.Cos(ControlMgr.inst.player_entity.heading));
      }
      else
      {
        velocity = new Vector3(Mathf.Sin(ControlMgr.inst.player_entity.heading), 0, Mathf.Cos(ControlMgr.inst.player_entity.heading));
        velocity = -velocity;
      }
      velocity *= power;
    }
}
