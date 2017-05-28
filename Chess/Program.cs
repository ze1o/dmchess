﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static String[,] chessBoard={
        {"r","k","b","q","a","b","k","r"},
        {"p","p","p","p","p","p","p","p"},
        {" "," ","K"," "," "," "," "," "},
        {" "," "," "," "," "," "," "," "},
        {" "," "," "," "," "," "," "," "},
        {" "," "," "," "," "," "," "," "},
        {"P","P","P","P","P","P","P","P"},
        {"R","K","B","Q","A","B","K","R"}};

		static int[,] pawnBoard={//attribute to http://chessprogramming.wikispaces.com/Simplified+evaluation+function
        { 0,  0,  0,  0,  0,  0,  0,  0},
        {50, 50, 50, 50, 50, 50, 50, 50},
        {10, 10, 20, 30, 30, 20, 10, 10},
        { 5,  5, 10, 25, 25, 10,  5,  5},
        { 0,  0,  0, 20, 20,  0,  0,  0},
        { 5, -5,-10,  0,  0,-10, -5,  5},
        { 5, 10, 10,-20,-20, 10, 10,  5},
        { 0,  0,  0,  0,  0,  0,  0,  0}};
        
        static int[,] rookBoard={
        { 0,  0,  0,  0,  0,  0,  0,  0},
        { 5, 10, 10, 10, 10, 10, 10,  5},
        {-5,  0,  0,  0,  0,  0,  0, -5},
        {-5,  0,  0,  0,  0,  0,  0, -5},
        {-5,  0,  0,  0,  0,  0,  0, -5},
        {-5,  0,  0,  0,  0,  0,  0, -5},
        {-5,  0,  0,  0,  0,  0,  0, -5},
        { 0,  0,  0,  5,  5,  0,  0,  0}};
        
        static int[,] knightBoard={
        {-50,-40,-30,-30,-30,-30,-40,-50},
        {-40,-20,  0,  0,  0,  0,-20,-40},
        {-30,  0, 10, 15, 15, 10,  0,-30},
        {-30,  5, 15, 20, 20, 15,  5,-30},
        {-30,  0, 15, 20, 20, 15,  0,-30},
        {-30,  5, 10, 15, 15, 10,  5,-30},
        {-40,-20,  0,  5,  5,  0,-20,-40},
        {-50,-40,-30,-30,-30,-30,-40,-50}};
        
        static int[,] bishopBoard={
        {-20,-10,-10,-10,-10,-10,-10,-20},
        {-10,  0,  0,  0,  0,  0,  0,-10},
        {-10,  0,  5, 10, 10,  5,  0,-10},
        {-10,  5,  5, 10, 10,  5,  5,-10},
        {-10,  0, 10, 10, 10, 10,  0,-10},
        {-10, 10, 10, 10, 10, 10, 10,-10},
        {-10,  5,  0,  0,  0,  0,  5,-10},
        {-20,-10,-10,-10,-10,-10,-10,-20}};
        
        static int[,] queenBoard={
        {-20,-10,-10, -5, -5,-10,-10,-20},
        {-10,  0,  0,  0,  0,  0,  0,-10},
        {-10,  0,  5,  5,  5,  5,  0,-10},
        { -5,  0,  5,  5,  5,  5,  0, -5},
        {  0,  0,  5,  5,  5,  5,  0, -5},
        {-10,  5,  5,  5,  5,  5,  0,-10},
        {-10,  0,  5,  0,  0,  0,  0,-10},
        {-20,-10,-10, -5, -5,-10,-10,-20}};
        
        static int[,] kingMidBoard={
        {-30,-40,-40,-50,-50,-40,-40,-30},
        {-30,-40,-40,-50,-50,-40,-40,-30},
        {-30,-40,-40,-50,-50,-40,-40,-30},
        {-30,-40,-40,-50,-50,-40,-40,-30},
        {-20,-30,-30,-40,-40,-30,-30,-20},
        {-10,-20,-20,-20,-20,-20,-20,-10},
        { 20, 20,  0,  0,  0,  0, 20, 20},
        { 20, 30, 10,  0,  0, 10, 30, 20}};
        
        static int[,] kingEndBoard={
        {-50,-40,-30,-20,-20,-30,-40,-50},
        {-30,-20,-10,  0,  0,-10,-20,-30},
        {-30,-10, 20, 30, 30, 20,-10,-30},
        {-30,-10, 30, 40, 40, 30,-10,-30},
        {-30,-10, 30, 40, 40, 30,-10,-30},
        {-30,-10, 20, 30, 30, 20,-10,-30},
        {-30,-30,  0,  0,  0,  0,-30,-30},
        {-50,-30,-30,-30,-30,-30,-30,-50}};
        
        static int kingPositionU;
        public static void Main(string[] args)
        {

			kingPositionU = 0;
            while(!"A".Equals(chessBoard[kingPositionU/8,kingPositionU%8])){
                kingPositionU++;
            }
			System.Console.WriteLine(possibleMove());


		}
        public static String possibleMove()
        {
            String list = "";
            for (int i = 0; i < 64; i++)
            {
                if (Char.IsUpper(chessBoard[i / 8, i % 8], 0))
                {
                    switch (chessBoard[i / 8, i % 8])
                    {
                        case "A":
                            list += possibleA(i);
                            break;
                        case "B":
                            list += possibleB(i);
                            break;
                        case "Q":
                            list += possibleQ(i);
                            break;
                        case "R":
                            list += possibleR(i);
                            break;
                        case "K":
                            list += possibleK(i);
                            break;
						case "P":
							list += possibleP(i);
							break;
                    }

                }
            }
            return list;
        }
        public static String possibleA(int i)
        {
            String list = "", oldPiece;
            int row = i / 8, col = i % 8;
            for (int j = 0; j < 9; j++)
            {
                //J==4 is present king's position 
                if (j != 4)
                {
                    try
                    {//Check position around of the king is enemy or blank
                        if (Char.IsLower(chessBoard[row - 1 + j / 3, col - 1 + j % 3], 0) || " ".Equals(chessBoard[row - 1 + j / 3, col - 1 + j % 3]))
                        {
                            oldPiece = chessBoard[row - 1 + j / 3, col - 1 + j % 3];
                            chessBoard[row, col] = " ";
                            chessBoard[row - 1 + j / 3, col - 1 + j % 3] = "A";
                            int tempKing = kingPositionU;
                            kingPositionU = i - 9 + j * 8 / 3 + j % 3;
                            if (safeKing())
                            {
                                //Old Position [ROW, COL] => New Position [..., ...], where is OldPiece
                                list = list + row.ToString() + col.ToString() + (row - 1 + j / 3).ToString() + (col - 1 + j % 3).ToString() + oldPiece;
                            }
                            chessBoard[row, col] = "A";
                            chessBoard[row - 1 + j / 3, col - 1 + j % 3] = oldPiece;
                            kingPositionU = tempKing;
                        }
                    }
                    catch (Exception) { }
                }
            }
            return list;
        }
        public static String possibleB(int i)
        {
			String list = "", oldPiece;
			int row = i / 8, col = i % 8;
			int distance = 1;
            for (int j = -1; j <= 1; j+=2)
            {
                for (int k = -1; k <= 1; k+=2)
                {
                    try{
						while (" ".Equals(chessBoard[row + distance * j, col + distance * k]))
						{
							oldPiece = chessBoard[row + distance * j, col + distance * k];
							chessBoard[row, col] = " ";
							chessBoard[row + distance * j, col + distance * k] = "B";
							if (safeKing())
							{
								list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
							}
							chessBoard[row, col] = "B";
							chessBoard[row + distance * j, col + distance * k] = oldPiece;
							distance++;
						}

						if (Char.IsLower(chessBoard[row + distance * j, col + distance * k], 0))
						{
							oldPiece = chessBoard[row + distance * j, col + distance * k];
							chessBoard[row, col] = " ";
							chessBoard[row + distance * j, col + distance * k] = "B";
							if (safeKing())
							{
								list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
							}
							chessBoard[row, col] = "B";
							chessBoard[row + distance * j, col + distance * k] = oldPiece;
						}
                    } catch(Exception){}
                    distance = 1;
                }
            }
            return list;
        }

        public static String possibleR(int i)
        {
			String list = "", oldPiece;
			int row = i / 8, col = i % 8;
            int distance = 1;
            for (int j = -1; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    if (k * j == 0){
                        if (k != j){
							try
							{
								while (" ".Equals(chessBoard[row + distance * j, col + distance * k]))
								{
									oldPiece = " ";
									chessBoard[row, col] = " ";
									chessBoard[row + distance * j, col + distance * k] = "R";
									if (safeKing())
									{
										list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
									}
									chessBoard[row, col] = "R";
									chessBoard[row + distance * j, col + distance * k] = oldPiece;
									distance++;
								}

								if (Char.IsLower(chessBoard[row + distance * j, col + distance * k], 0))
								{
									oldPiece = chessBoard[row + distance * j, col + distance * k];
									chessBoard[row, col] = " ";
									chessBoard[row + distance * j, col + distance * k] = "R";
									if (safeKing())
									{
										list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
									}
									chessBoard[row, col] = "R";
									chessBoard[row + distance * j, col + distance * k] = oldPiece;
								}
							}
							catch (Exception) { }
							distance = 1;
                        }
                    }
                }
            }
			return list;
		}
        public static String possibleQ(int i)
        {
            String list = "", oldPiece;
            int row = i / 8, col = i % 8;
            int distance = 1;
            for (int j = -1; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    if (j != 0 || k != 0)
                    {
                        try
                        {
                            while (" ".Equals(chessBoard[row + distance * j, col + distance * k]))
                            {
                                oldPiece = " ";
                                chessBoard[row, col] = " ";
                                chessBoard[row + distance * j, col + distance * k] = "Q";
                                if (safeKing())
                                {
                                    list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
                                }
                                chessBoard[row, col] = "Q";
                                chessBoard[row + distance * j, col + distance * k] = oldPiece;
                                distance++;
                            }

                            if (Char.IsLower(chessBoard[row + distance * j, col + distance * k], 0))
                            {
                                oldPiece = " ";
                                chessBoard[row, col] = " ";
                                chessBoard[row + distance * j, col + distance * k] = "Q";
                                if (safeKing())
                                {
                                    list = list + row.ToString() + col.ToString() + (row + distance * j).ToString() + (col + distance * k).ToString() + oldPiece;
                                }
                                chessBoard[row, col] = "Q";
                                chessBoard[row + distance * j, col + distance * k] = oldPiece;
                            }
                        }
                        catch (Exception) { }
                        distance = 1;
                    }
                }
            }
            return list;
        }

        public static String possibleK(int i)
        {
            String list = "", oldPiece;
            int row = i / 8, col = i % 8;
            for (int j = -2; j <= 2; j++)
            {
                for (int k = -2; k <= 2; k++){
                    if ( Math.Abs(j * k) == 2){
                        try 
                        {
                            if (Char.IsLower(chessBoard[row + j, col + k], 0) || " ".Equals(chessBoard[row + j, col + k]))
							{
								oldPiece = chessBoard[row + j, col + k];
								chessBoard[row, col] = " ";
								chessBoard[row + j, col + k] = "K";
								if (safeKing())
								{
									list = list + row.ToString() + col.ToString() + (row + j).ToString() + (col + k).ToString() + oldPiece;
								}
								chessBoard[row, col] = "K";
								chessBoard[row + j, col + k] = oldPiece;
							}
                        }catch (Exception){}
                    }
                }
            }
            return list;
        }

        public static String possibleP(int i)
        {
            String list = "", oldPiece;
            int row = i / 8, col = i % 8;

            return list;
        }
        //Don't work with
        public static Boolean safeKing()
        {
            return true;
        }
    }
}