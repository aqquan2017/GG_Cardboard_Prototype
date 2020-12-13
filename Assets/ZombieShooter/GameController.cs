using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ZoombieShooter
{
	public class GameController : MonoBehaviour
	{

		public Player player;
		public GameObject enemyPrefab;
		public TextMesh infoText;

		public float enemySpawnDistance = 20f;

		public float enemyInterval = 2.0f;
		public float minimumEnemyInterval = 0.5f;
		public float enemyIntervalDecrement = 0.1f;

		private float gameTimer = 0f;
		private float enemyTimer = 0f;
		private float resetTimer = 3f;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (player.health > 0)
			{
				gameTimer += Time.deltaTime;
				infoText.text = "Health: " + player.health;
				infoText.text += "\nTime: " + Mathf.Floor(gameTimer);
			}
			else
			{
				infoText.text = "Game over!";
				infoText.text += "\nYou survived for " + Mathf.Floor(gameTimer) + " seconds!";

				resetTimer -= Time.deltaTime;
				if (resetTimer <= 0f)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}

			enemyTimer -= Time.deltaTime;
			if (enemyTimer <= 0)
			{
				enemyTimer = enemyInterval;
				enemyInterval -= enemyIntervalDecrement;

				if (enemyInterval < minimumEnemyInterval)
				{
					enemyInterval = minimumEnemyInterval;
				}

				GameObject enemyObject = Instantiate(enemyPrefab);
				Enemy enemy = enemyObject.GetComponent<Enemy>();

				float randomAngle = Random.Range(0f, 2f * Mathf.PI);
				enemy.transform.position = new Vector3(
					player.transform.position.x + Mathf.Cos(randomAngle) * enemySpawnDistance,
					enemy.transform.position.y,
					player.transform.position.z + Mathf.Sin(randomAngle) * enemySpawnDistance
				);

				enemy.player = player;
				enemy.direction = (player.transform.position - enemy.transform.position).normalized;
				enemy.transform.LookAt(player.transform);
			}
		}
	}
}