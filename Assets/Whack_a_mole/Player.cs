using UnityEngine;
namespace WhackAMole
{
	public class Player : MonoBehaviour
	{
        public MoveToMe curArrow;
        public GazeController gazeController;
		public int score = 0;
		public Hammer hammer;
        

        public void OnHit(Mole mole)
        {
            print("HIT");
            SoundManager.instance.PlayHitSound(SoundManager.instance.hitSound);
            mole.OnHit();
            hammer.Hit(mole.transform.position);

            score++;
        }
    }
}