using UnityEngine;
using System.Collections;

namespace XO
{
	public class Piece : MonoBehaviour
	{
		private GazeObject gaze;
		public GameObject pieceX;
		public GameObject pieceO;

		public bool defined;
		public int value = 0;

        private void Start()
        {
			gaze = GetComponent<GazeObject>();
        }

        public void CleanSelection()
		{
			defined = false;
			value = 0;
			pieceX.SetActive(false);
			pieceO.SetActive(false);
		}

		public void PlayerSelect()
		{
			defined = true;
			value = 1;
			pieceX.SetActive(true);
			SoundManager.instance.PlayHitSound(SoundManager.instance.playSound);

		}

		public void ComputerSelect()
		{
			defined = true;
			value = 2;
			pieceO.SetActive(true);
		}
	}
}