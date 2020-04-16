using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Intercept : Command
{
  public Intercept(Entity381 src, Entity381 dst) : base(src)
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
    Vector3 rel = destination.velocity - source.velocity;
	  float dist = Vector3.Distance(source.position, destination.position);
    float t = dist / rel.magnitude;
	  Vector3 diff = (destination.position + destination.velocity * t) - source.position;
    source.desiredHeading = (float)(Math.Atan2(diff.x, diff.z) * (180/Math.PI));
    source.desiredHeading = source.desiredHeading > 0 ? source.desiredHeading < 360 ? source.desiredHeading : source.desiredHeading - 360 : source.desiredHeading + 360;
    //Gizmos.color = Color.red;
    Debug.DrawLine(source.position, destination.position, Color.red);

  	//Calculate velocity
  	source.desiredSpeed = source.maxSpeed;

  	if(dist < 50)
  		isDone = true;
  	else
  		isDone = false;
  }

  public Entity381 source;
  public Entity381 destination;

}
