using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
    public static SelectionMgr inst;

    public Camera c;

    private void Awake()
    {
        inst = this;
    }
    //public EntityMgr entityMgr;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            SelectNextEntity();
        }

        if (Input.GetMouseButtonUp(0)) //Left mouse button was pressed
        {
          SelectEntityAtMouseCursor();
        }



    }

    public int selectedEntityIndex = 0;
    public Entity381 selectedEntity;

    public void SelectEntityAtMouseCursor()
    {
      RaycastHit hit;
      Ray ray = c.ScreenPointToRay(Input.mousePosition);
      UnSelectAll();
      float deltaDistance = 100;
      if (Physics.Raycast(ray, out hit)) {
        if (hit.collider != null)
          {
            selectedEntity = getClosestEntityFromMousePosition(hit, deltaDistance);

            if (selectedEntity != null) selectedEntity.isSelected = true;
            //Debug.Log(selectedEntity.position);
          }
      }
    }

    Entity381 getClosestEntityFromMousePosition(RaycastHit hit, float deltaDistance)
    {
      float closestDistance = 9999;
      Entity381 closestEntity = null;
      foreach (Entity381 ent in EntityMgr.inst.entities)
      {
        float dist = Vector3.Distance(hit.point, ent.position);
        if(dist <= closestDistance)
        {
          closestDistance = dist;
          closestEntity = ent;
        }
      }
      if(closestDistance <= deltaDistance)
      {
        return closestEntity;
      }
      else
      {
        return null;
      }
    }

    public void SelectNextEntity()
    {
        selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1 ? 0 : selectedEntityIndex + 1);
        selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
        UnSelectAll();
        selectedEntity.isSelected = true;
    }

    void UnSelectAll()
    {
        foreach (Entity381 ent in EntityMgr.inst.entities)
            ent.isSelected = false;
    }

}
