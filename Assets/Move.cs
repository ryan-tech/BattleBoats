using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Move : Command
{
  public Move(Entity381 e, Vector3 pos) : base(e)
  {
    ent = e;
    targetPosition = pos;
  }
  public override void Init(){
    Debug.Log("Entity is moving");
  }

  public override bool IsDone()
  {
    return isDone;
  }

  public override void Stop()
  {
    ent.desiredSpeed = 0;

  }

  public override void Tick(float dt)
  {
    Vector3 diff = targetPosition - ent.position;

  	ent.desiredHeading = Utils.Degrees360((float)(Math.Atan2(diff.x, diff.z) * (180/Math.PI)));
    //Debug.Log(ent.desiredHeading);
    Debug.DrawLine(ent.position, targetPosition);
  	//Calculate velocity
  	ent.desiredSpeed = ent.maxSpeed;
    Debug.Log(ent.desiredSpeed);
  	if(Vector3.Distance(targetPosition, ent.position) < 25)
    {
  		isDone = true;
  	}
  	else
    {
  		isDone = false;
  	}
  }

  public Entity381 ent;
  public Vector3 targetPosition;
}
