﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_Game_Project.classes;

namespace chessgames.backPieces
{
    internal class BlackKnight2
    {
        typeOfMovesChess type = new typeOfMovesChess();
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool blackTurn)
        {
            if (!blackTurn)
                return possibleMoves;

            possibleMoves = type.BlackHorseMove(board, possibleMoves, i, j);
            return possibleMoves;
        }
        public int[,] isStale(int[,] board, int[,] possibleMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 08)
                    {
                        possibleMoves = type.BlackHorseMove(board, possibleMoves, i, j);
                    }
                }
            }
            return possibleMoves;
        }
    }
}
