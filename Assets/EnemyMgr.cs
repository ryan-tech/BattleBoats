using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{

    public static EnemyMgr inst;

    private void Awake()
    {
        inst = this;
    }
    public GameObject original_enemy_object;

    public List<GameObject> enemies;
    public int num_enemies;
    public int min_spawn_radius = -100;
    public int max_spawn_radius = 100;

    // Start is called before the first frame update
    void Start()
    {
      // Loads randomly positioned enemy ships
      for(int i = 0; i < num_enemies; i++)
      {
        Vector3 random_pos_in_range = new Vector3(Random.Range(min_spawn_radius, max_spawn_radius), 0, Random.Range(min_spawn_radius, max_spawn_radius));

        GameObject enemy = Instantiate(original_enemy_object, random_pos_in_range, Quaternion.identity);
        enemy.SetActive(true);
        enemies.Insert(0, enemy);
      }
    }

    // Update is called once per frame
    void Update()
    {
      foreach(GameObject e in enemies)
      {
        Entity381 enemy_entity = e.GetComponent<Entity381>();
        Move m = new Move(enemy_entity, ControlMgr.inst.player_entity.position, 50);
        enemy_entity.SetCommand(m);
      }
    }
}
