void TicTacToeInfinity()
{
	bool Xturn = true;

	Console.Write("enter size matrix: ");
	int size = Convert.ToInt32(Console.ReadLine());

	// number of possible plays
	int numShift = size * size;

	// board NxN
	char?[][] board = new char?[size][];
	for (int i = 0; i < size; i++)
	{
		board[i] = new char?[size];
		for (int j = 0; j < size; j++)
		{
			board[i][j] = null;
		}
	}

	do
	{
		numShift--;

		if (Xturn)
		{
			Call(board, ref Xturn);
			PrintBoard(board);

			if (Match(board, 'X'))
			{
				Console.WriteLine("X win... CONGRATULATIONS");
				break;
			}

		}
		else
		{
			Call(board, ref Xturn);
			PrintBoard(board);

			if (Match(board, 'O'))
			{
				Console.WriteLine("O win... CONGRATULATIONS");
				break;
			}

		}

		if (numShift == 0 && !Match(board, 'X') && !Match(board, 'O'))
		{
			Console.WriteLine("Draw");
			break;
		}

	} while (numShift != 0);

	Console.ReadKey();
}

void PrintBoard(char?[][] board)
{
	int size = board.Length;

	foreach (char?[] row in board)
	{
		Console.WriteLine(string.Join(" | ", row.Select(cell => cell.HasValue ? cell.Value.ToString() : " ")));
		Console.WriteLine(new string('-', size * 4 - 1));
	}
}

void Call(char?[][] board, ref bool Xturn)
{
	if (Xturn)
	{
		Console.WriteLine("X turn");
	}
	else
	{
		Console.WriteLine("O turn");
	}

	Console.Write("enter row: ");
	int row = Convert.ToInt32(Console.ReadLine());

	Console.Write("enter column: ");
	int column = Convert.ToInt32(Console.ReadLine());

	if (board[row][column] != null)
	{
		Console.WriteLine("\n");
		Console.WriteLine("Position already occupied...");
		Call(board, ref Xturn);
		return;
	}

	board[row][column] = Xturn ? 'X' : 'O';
	Xturn = !Xturn;

	Console.WriteLine("\n");

}

bool Match(char?[][] board, char symbol)
{
	int size = board.Length;

	// vertical and horizontals check
	for (int i = 0; i < size; i++)
	{
		bool verticalMatch = true;
		bool horizontalMatch = true;

		for (int j = 0; j < size; j++)
		{
			if (board[i][j] != symbol) // check row i
			{
				horizontalMatch = false;
			}

			if (board[j][i] != symbol) // check column i
			{
				verticalMatch = false;
			}
		}

		if (horizontalMatch || verticalMatch)
		{
			return true;
		}
	}

	// check diagonals
	bool diagonal1Match = true;
	bool diagonal2Match = true;

	for (int i = 0; i < size; i++)
	{
		if (board[i][i] != symbol) // check main diagonal 
		{
			diagonal1Match = false;
		}

		if (board[i][size - i - 1] != symbol) // check secondary diagonal
		{
			diagonal2Match = false;
		}
	}

	if (diagonal1Match || diagonal2Match)
	{
		return true;
	}

	return false;
}


TicTacToeInfinity();

