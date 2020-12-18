using UnityEngine;
using System.Collections;
using System;
namespace XO
{
	public class PlayerXO : MonoBehaviour
	{
		public Action onSelectedPiece;
		public bool locked = false;

		public void CallBackActionGaze(Piece piece)
        {
			if (piece.defined == false)
			{
				print("MOVE ");
				piece.PlayerSelect();
				onSelectedPiece();
			}
		}
	}
}
