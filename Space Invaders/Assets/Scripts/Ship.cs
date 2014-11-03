using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public GameObject bulletPrefab;
	
	private GUIText livesLabel;
	
	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab) as GameObject;
			bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
			bullet.rigidbody2D.velocity = new Vector2(0, 20);
		}
	}
	

		private void shoot()
		{
			Transform bullet = Instantiate (bulletPrefab) as Transform;
			bullet.transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
			bullet.rigidbody2D.velocity = new Vector2 (0, 50);
			Transform bullet2 = Instantiate (bulletPrefab) as Transform;
			bullet2.transform.position = new Vector3 (transform.position.x-1, transform.position.y + 0.5f, transform.position.z);
			bullet2.rigidbody2D.velocity = new Vector2 (-7, 50);
			Transform bullet3 = Instantiate (bulletPrefab) as Transform;
			bullet3.transform.position = new Vector3 (transform.position.x+1, transform.position.y + 0.5f, transform.position.z);
			bullet3.rigidbody2D.velocity = new Vector2 (7, 50);
			Transform bullet4 = Instantiate (bulletPrefab) as Transform;
			bullet4.transform.position = new Vector3 (transform.position.x-2, transform.position.y , transform.position.z);
			bullet4.rigidbody2D.velocity = new Vector2 (-15, 50);
			Transform bullet5 = Instantiate (bulletPrefab) as Transform;
			bullet5.transform.position = new Vector3 (transform.position.x+2, transform.position.y , transform.position.z);
			bullet5.rigidbody2D.velocity = new Vector2 (15, 50);
		}
	

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
		}
	}
}
