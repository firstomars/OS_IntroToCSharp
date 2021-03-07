//PAC MAN

// TO DO 
// 1 - implement game states (menu screen, high score screen)
// 2 - when player clicks play game from menu screen, player enters three character name
// 3 - when lives = 0, gameover screen text appears on screen
// 4 - when lives = 0, high score and player name is saved to text file 
// 4 - game over transitions to high score screen after a few seconds
// 5 - high score screen - read from file and print to screen
// 6 - change map, edit score and lives text (lives should be asset?) 
//

		//why can't we do this?
  //      void HandleGhostPlayerCollisions()
		//{
			
		//	foreach (var ghost in ghosts)
		//	{
		//		if (GetTileID(ghost.position) == GetTileID(player.position)) //this line
		//		{
		//			player.OnCollision(ghost);
		//			ghost.OnCollision(player);
		//		}
		//	}
		//}
		
		//Up to vid 3 - 20.56

/*
PACMAN STEPS

PART 1
create project
setup basic game states
setup GameLevelState"
Define 2D array for TileMap
Draw TileMap (walls and pacdots)
Debug Draw TileMap

PART 2
Create player class
Draw player
Move player on key press
Debug draw player - highlight which tile the player is on
Snap / lock to grid
Speed up
Prevent movement from going through walls
Eat pacdots
Reset level when all pacdots are eaten

PART 3
Create Ghost class - copy of player class
Spawn ghosts when level is created
Move in random direction at intersections
Detect collissions with Player
- pacman reset
- ghost resets
- lives decrease
*/
