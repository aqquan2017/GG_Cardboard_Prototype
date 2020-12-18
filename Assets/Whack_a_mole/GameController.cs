using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace WhackAMole
{
	public class GameController : MonoBehaviour
	{
		public SwitchBtn switchBtn;
		public GameObject moleContainer;
		public Player player;
		public TextMesh infoText;
		public float spawnDuration = 1.5f;
		public float spawnDecrement = 0.1f;
		public float minimumSpawnDuration = 0.5f;
		public float gameTimer = 30f;
		public bool isPlay = false;

		private Mole[] moles;
		private float spawnTimer = 0f;
		private float resetTimer = 3f;

		// Use this for initialization
		void Start()
		{
			moles = moleContainer.GetComponentsInChildren<Mole>();
		}

		public void ChangeStateGame()
        {
			isPlay = !isPlay;

        }

		// Update is called once per frame
		void Update()
		{
			if (isPlay)
			{
				gameTimer -= Time.deltaTime;

				if (gameTimer > 0f)
				{
					infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;

					spawnTimer -= Time.deltaTime;
					if (spawnTimer <= 0f)
					{
						moles[Random.Range(0, moles.Length)].Rise();

						spawnDuration -= spawnDecrement;
						if (spawnDuration < minimumSpawnDuration)
						{
							spawnDuration = minimumSpawnDuration;
						}

						spawnTimer = spawnDuration;
					}
				}
				else
				{
					infoText.text = "Game over! Your score: " + Mathf.Floor(player.score);

					resetTimer -= Time.deltaTime;
					if (resetTimer <= 0f)
					{
						WinGame();
					}
				}
			}
		}

		public void WinGame()
        {
			isPlay = false;
			switchBtn.GetComponent<GazeObject>().state = true;
			switchBtn.SetMaterial();
			ResetGame();
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void ResetGame()
        {
            spawnDuration = 1.5f;
            spawnDecrement = 0.1f;
            minimumSpawnDuration = 0.5f;
            gameTimer = 30f;
            isPlay = false;

            spawnTimer = 0f;
            resetTimer = 3f;
			infoText.text = "Hello Fen !";
        }



	}
}