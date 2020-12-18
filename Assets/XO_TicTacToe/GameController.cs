using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using System.Collections;

namespace XO
{
	public class GameController : MonoBehaviour
	{
		public PlayerXO player;
		public Piece[] pieces;
		public TextMesh infoText;

		public bool isGameOver = false;
		private float resetTimer = 3f;

		// Use this for initialization
		void Start()
		{
			player.onSelectedPiece = () =>
			{
				OnPlayerSelected();
			};

			ResetGame();
			ActiveBoard(true);
		}

		void ResetGame()
        {
			infoText.text = "Ăn tao đê !";
			resetTimer = 3f;
			foreach (Piece piece in pieces)
			{
				piece.CleanSelection();
				piece.GetComponent<GazeObject>().SwitchStateOn();
			}

			isGameOver = false;
			PickRandomPiece();
		}

		void OnPlayerSelected()
		{
			CheckBoard();

			if (isGameOver == false)
			{
				PickRandomPiece();
				CheckBoard();
			}
		}

		void PickRandomPiece()
		{
			int availablePieces = 0;
			foreach (Piece piece in pieces)
			{
				if (piece.defined == false)
				{
					availablePieces++;
				}
			}

			if (availablePieces > 0)
			{
				Piece randomPiece = pieces[Random.Range(0, pieces.Length)];
				while (randomPiece.defined == true)
				{
					randomPiece = pieces[Random.Range(0, pieces.Length)];
				}

				randomPiece.ComputerSelect();
				CheckBoard();
			}
		}

		void ActiveBoard(bool state)
        {
			foreach(var p in pieces)
            {
				p.GetComponent<GazeObject>().state = state;
            }
        }

		public void CheckBoard()
		{
			// Horizontal check
			for (int y = 0; y < 3; y++)
			{
				Piece pieceCheck = null;
				int matches = 0;

				for (int x = 0; x < 3; x++)
				{
					Piece currentPiece = pieces[y * 3 + x];

					if (pieceCheck == null)
					{
						if (currentPiece.value != 0)
						{
							pieceCheck = currentPiece;
							matches++;
						}
					}
					else if (currentPiece.value == pieceCheck.value)
					{
						matches++;
					}
				}

				if (matches == 3)
				{
					if (pieceCheck.value == 1)
					{
						infoText.text = "Giỏi !";
						SoundManager.instance.PlayHitSound(SoundManager.instance.winSound);
					}
					else
					{
						infoText.text = "Ngu !";
						SoundManager.instance.PlayHitSound(SoundManager.instance.loseSound);
					}
					isGameOver = true;
					print("HORIZONTAL WIN");
					ResetGameCroundtine();
					return;
				}
			}

			// Vertical check
			for (int y = 0; y < 3; y++)
			{
				Piece pieceCheck = null;
				int matches = 0;

				for (int x = 0; x < 3; x++)
				{
					Piece currentPiece = pieces[x * 3 + y];

					if (pieceCheck == null)
					{
						if (currentPiece.value != 0)
						{
							pieceCheck = currentPiece;
							matches++;
						}
					}
					else if (currentPiece.value == pieceCheck.value)
					{
						matches++;
					}
				}

				if (matches == 3)
				{
					if (pieceCheck.value == 1)
					{
						infoText.text = "Giỏi !";
						SoundManager.instance.PlayHitSound(SoundManager.instance.winSound);

					}
					else
					{
						infoText.text = "Ngu !";
						SoundManager.instance.PlayHitSound(SoundManager.instance.loseSound);
					}
					isGameOver = true;
					print("Vertical WIN");
					ResetGameCroundtine();
					return;
				}
			}

			// Diagonal check 0 4 8 
			if((pieces[0].value == pieces[4].value && pieces[4].value == pieces[8].value)
				&& (pieces[0].value != 0))
            {
				if (pieces[0].value == 1)
				{
					infoText.text = "Giỏi !";
					SoundManager.instance.PlayHitSound(SoundManager.instance.winSound);
				}
				else if (pieces[0].value == 2) { 
					infoText.text = "Ngu !";
					SoundManager.instance.PlayHitSound(SoundManager.instance.loseSound);
				}
				ResetGameCroundtine();
				isGameOver = true;
				print("Diagonal left WIN");

				return;
			}

			// Diagonal check 2 4 6
			if ((pieces[2].value == pieces[4].value && pieces[4].value == pieces[6].value)
				&& (pieces[2].value != 0))
			{
				if (pieces[2].value == 1)
				{
					infoText.text = "Giỏi !";
					SoundManager.instance.PlayHitSound(SoundManager.instance.winSound);
				}
				else if (pieces[2].value == 2)
				{
					infoText.text = "Ngu !";
					SoundManager.instance.PlayHitSound(SoundManager.instance.loseSound);
				}
				ResetGameCroundtine();
				isGameOver = true;
				print("Diagonal right WIN");

				return;
			}


			//CheckDraw
			bool check = false;
			foreach(var p in pieces){
				if(p.value == 0)
                {
					check = true;
					break;
                }
            }
			if(!check)
            {
				infoText.text = "Hòa rồi pạn ơi !";
				SoundManager.instance.PlayHitSound(SoundManager.instance.winSound);
				isGameOver = true;
				print("CheckDraw WIN");
				ResetGameCroundtine();
				return;
			}
		}

		void ResetGameCroundtine()
        {
			StopAllCoroutines();
			StartCoroutine(WaitToResetGame());
		}

		IEnumerator WaitToResetGame()
        {
			ActiveBoard(false);
			yield return new WaitForSeconds(2f);
			ResetGame();
        }
	}

	
}