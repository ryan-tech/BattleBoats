using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ControlMgr will control the player's ship

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public Entity381 player_entity;
    public Camera c;
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {

      player_entity.desiredSpeed = Utils.Clamp(player_entity.desiredSpeed, player_entity.minSpeed, player_entity.maxSpeed);
      player_entity.desiredHeading = Utils.Degrees360(player_entity.desiredHeading);

      if (Input.GetMouseButtonDown(1))
      {
        //Debug.Log("Control read a right click");
        if (Physics.Raycast(c.ScreenPointToRay(Input.mousePosition), out hit))
        {
          //Debug.Log("Ray was cast");
          Vector3 pos = hit.point;
          pos.y = 0;

          Move m = new Move(player_entity, pos);
          player_entity.SetCommand(m);

          //Debug.DrawRay(player_entity.transform.position, hit.point, Color.green, 2);
        }
        else
        {
          //Debug.Log("Wtf");
        }
      }

      if (Input.GetKey(KeyCode.Escape))
      {
          Application.Quit();
      }
    }
}
