using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Command
{

  public Command(Entity381 ent)
  {
    entity = ent;
  }
  public virtual void Init(){}
  public virtual void Tick(float dt){}
  public virtual bool IsDone(){
    return isDone;
  }
  public virtual void Stop(){}

  public Entity381 entity;
  public bool isDone = false;
}
