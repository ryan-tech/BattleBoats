using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity381 : MonoBehaviour
{
    public bool isSelected = true;
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    //Variables that change while running
    public float speed;
    public float desiredSpeed;
    public float heading;
    public float desiredHeading;
    //Variables that do not change
    public float acceleration;
    public float turnRate;
    public float maxSpeed;
    public float minSpeed;

    public int currentHealth;
    public int maxHealth;
    public int cannonDmg;
    public int cannonRange;

    public bool dead;

    public GameObject cameraRig;

    public GameObject selectionCircle;
    public List<Command> commands;
    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
      dead = false;
    }

    // Update is called once per frame
    void Update()
    {
      selectionCircle.SetActive(isSelected);
      if(commands.Count != 0){
      		// Run oldest command
      		Command runCommand = commands[0];
      		runCommand.Tick(Time.deltaTime);

      		// Delete command after done
      		if(runCommand.IsDone()){
      			runCommand.Stop();
      			commands.RemoveAt(0);
      		}
      	}
    }


    public void SetCommand(Command m){
      commands.Clear();
      commands.Add(m);
    }

}
