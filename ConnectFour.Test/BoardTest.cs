namespace ConnectFour.Test;

public class BoardTest
{
    [Fact]
    public void TestNothing()
    {
        Assert.Equal(2, 1 + 1);
    }
    
    [Fact]
    public void MakeMove_InvalidColumn_ReturnsMinusOne()
    {
        // Arrange
        var board = new Board();
        char player = Board.PLAYER_1;

        // Act & Assert
        Assert.Equal(-1, board.MakeMove(player, 9));
    }
    
    [Fact]
    public void MakeMove_InvalidRow_ReturnsMinusOne()
    {
        // Arrange
        var board = new Board();
        char player = Board.PLAYER_1;

        // Act & Assert
        Assert.Equal(-1, board.MakeMove(player, -1));
        Assert.Equal(-1, board.MakeMove(player, 7));
    }

}