using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
  void Start()
  {

  }

  //public int i = 0;
  public List<Command> commands;

  // Update is called once per frame
  void Update()
  {

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



  public void AddCommand(Command m)
  {
    commands.Add(m);
  }

  public void SetCommand(Command m){
    commands.Clear();
    commands.Add(m);
  }

}
