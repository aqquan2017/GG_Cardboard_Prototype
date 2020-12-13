using UnityEngine;
namespace WhackAMole
{
	public class Player : MonoBehaviour
	{

		public int score = 0;
		public Hammer hammer;

		void Update()
		{
			if (GvrPointerInputModule.Pointer.TriggerDown)
			{
				RaycastHit hit;

				if (Physics.Raycast(transform.position, transform.forward, out hit))
				{
					if (hit.transform.GetComponent<Mole>() != null)
					{
						Mole mole = hit.transform.GetComponent<Mole>();
						mole.OnHit();
						hammer.Hit(mole.transform.position);

						score++;
					}
				}
			}
		}
	}
}