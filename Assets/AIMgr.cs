using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public static AIMgr inst;
    public Queue commands = new Queue();
    public Camera c;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
      layerMask = 1 << 9;// LayerMask.GetMask("Water");
    }

    public RaycastHit hit;
    public int layerMask;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(1))
      {
        if (Physics.Raycast(c.ScreenPointToRay(Input.mousePosition), out hit))
        {

          Vector3 pos = hit.point;
          pos.y = 0;
          Entity381 ent = FindClosestEntInRadius(pos, rClickRadiusSq);
          if (ent == null)
          {
            HandleMove(pos);
          }
          else
          {
            if (Input.GetKey(KeyCode.LeftControl))
              HandleIntercept(ent);
            else
              HandleFollow(ent);
          }
        }
        else
        {
          Debug.DrawRay(c.transform.position, c.transform.TransformDirection(Vector3.forward) * 1000, Color.white, 2);
        }
      }
    }


    void HandleMove(Vector3 point)
    {
        Move m = new Move(SelectionMgr.inst.selectedEntity, hit.point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
            uai.AddCommand(m);
        else
            uai.SetCommand(m);
    }

    void HandleFollow(Entity381 ent)
    {
        Follow f = new Follow(SelectionMgr.inst.selectedEntity, ent);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
            uai.AddCommand(f);
        else
            uai.SetCommand(f);

    }

    void HandleIntercept(Entity381 ent)
    {
        Intercept intercept = new Intercept(SelectionMgr.inst.selectedEntity, ent);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
            uai.AddCommand(intercept);
        else
            uai.SetCommand(intercept);

    }

    public float rClickRadiusSq = 100;
    public Entity381 FindClosestEntInRadius(Vector3 point, float rsq)
    {
        Entity381 minEnt = null;
        float min = float.MaxValue;
        foreach (Entity381 ent in EntityMgr.inst.entities) {
            float distanceSq = (ent.transform.position - point).sqrMagnitude;
            if (distanceSq < rsq) {
                if (distanceSq < min) {
                    minEnt = ent;
                    min = distanceSq;
                }
            }
        }
        return minEnt;
    }
}
