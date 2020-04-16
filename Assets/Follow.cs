using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Follow : Command
{
  public Follow(Entity381 src, Entity381 dst) : base(src)
  {
    source = src;
    destination = dst;
  }
  public override void Init(){
    Debug.Log("Entity is following");
  }

  public override bool IsDone()
  {
    return isDone;
  }

  public override void Stop()
  {
    source.desiredSpeed = 0;
  }

  public override void Tick(float dt)
  {
    Vector3 diff = destination.position - source.position;
  	source.desiredHeading = Utils.Degrees360((float)(Math.Atan2(diff.x, diff.z) * (180/Math.PI)));
    Debug.Log(source.desiredHeading);
    //Gizmos.color = Color.green;
    Debug.DrawLine(source.position, destination.position, Color.green);
  	//Calculate velocity
  	source.desiredSpeed = source.maxSpeed;

  	if(Vector3.Distance(destination.position, source.position) < 50)
    {
  		isDone = true;
  	}
  	else
    {
  		isDone = false;
  	}
  }

  public Entity381 source;
  public Entity381 destination;
}
