using MatchScene.Player.PlayerPartComponents.data;
using UnityEngine;

public class PlayerPartComponent : MonoBehaviour
{
	public PlayerPartHandler ActiveHandlers = PlayerPartHandler.NONE;

	private bool CheckIsActivated(PlayerPartHandler handler) {
		return (ActiveHandlers & handler) != 0;
	}

    public void CallAfterMovement(float distance, float direction) {
		if (CheckIsActivated(PlayerPartHandler.AFTER_MOVEMENT)) {
			UpdateAfterMovement(distance, direction);
		}
	}

	protected virtual void UpdateAfterMovement(float distance, float direction) {

	}
	
}
