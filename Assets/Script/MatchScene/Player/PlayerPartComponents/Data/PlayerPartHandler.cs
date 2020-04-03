namespace MatchScene.Player.PlayerPartComponents.data {

	[System.Flags]
	public enum PlayerPartHandler {
		NONE = 0,
		AFTER_MOVEMENT = 1 << 0,
		BAD_HIT = 1 << 1,
		GOOD_HIT = 1 << 2,
		CASHOUT = 1 << 3,
		START_CLOSING = 1 << 4,
		START_OPENING = 1 << 5,
		DONE_OPENING = 1 << 6,
		SQUASHERS_MOVE = 1 << 7
	}
}
