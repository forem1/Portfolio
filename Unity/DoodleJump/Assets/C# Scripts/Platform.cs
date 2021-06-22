using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump;
    public GameObject enemyPrefab;


    public void OnCollisionEnter2D(Collision2D collision)
    {
      // Прыжок
    	if (collision.relativeVelocity.y < 0)
    	{
    	Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;
    	}
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
      Vector3 SpawnerPosition = new Vector3();

      // Генерация платформ
    	if (collision.collider.name == "DeadZone")
    	{
    		float RandX = Random.Range(-5f, 5f);
    		float RandY = Random.Range(transform.position.y + 16f, transform.position.y + 17.5f);

    		transform.position = new Vector3(RandX, RandY, 0);
            Score.scoreValue += 1;

            int value = Random.Range(1, 15);
        SpawnerPosition.x = RandX;
        SpawnerPosition.y = RandY + 0.7f;
        if (value == 1)
        {
          Instantiate(enemyPrefab, SpawnerPosition, Quaternion.identity);
        }
    	}
    }
}
