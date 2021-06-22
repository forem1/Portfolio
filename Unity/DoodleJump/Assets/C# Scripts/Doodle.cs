using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doodle : MonoBehaviour
{
		public static Doodle instance;
    public Rigidbody2D DoodleRigid;
		public Transform doodlePos;

		// Скорость
		public float maxSpeed = 10f;

    void Start()
    {
        if(instance == null)
        {
        	instance = this;
        }
    }

    void FixedUpdate()
    {
				// Движение влево вправо
				if (Input.GetKey(KeyCode.LeftArrow))
				{
					gameObject.GetComponent<SpriteRenderer>().flipX = true;
					this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - 0.1f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
				}
				else if (Input.GetKey(KeyCode.RightArrow))
				{
					gameObject.GetComponent<SpriteRenderer>().flipX = false;
					this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.1f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
				}

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);
    }

		// Смерть
    public void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.collider.name == "DeadZone" || collision.collider.name == "enemy(Clone)")
    	{
    		SceneManager.LoadScene(0);
				Score.scoreValue = 0;
    	}
    }
}
