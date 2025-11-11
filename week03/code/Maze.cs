/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// Get the current location and check the left direction (index 0) in the boolean array.
    /// if true, then decrement _currX to move to left, else throw exception.
    public void MoveLeft()
    {
        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// Get the current location and check the right direction (index 1) in the boolean array.
    /// if true, then increment _currX to move to right, else throw exception.
    public void MoveRight()
    {
        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// Get the current location and check the up direction (index 2) in the boolean array.
    /// if true, then DECREMENT _currY to move up, else throw exception.
    public void MoveUp()
    {
        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// Get the current location and check the left down (index 3) in the boolean array.
    /// if true, then INCREMENT _currY to move down, else throw exception.
    public void MoveDown()
    {
        if( _mazeMap[(_currX, _currY)][3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}