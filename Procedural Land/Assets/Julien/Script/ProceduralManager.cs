using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using NUnit.Framework.Internal;

public class ProceduralManager : MonoBehaviour
{

  public static ProceduralManager Instance;

  public int width = 30;
  public int height = 30;

  public static string folderName;

  public char[,] tableau;

  class Room
  {
    public int x, y, width, height;

    public Room(int x, int y, int width, int height)
    {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
    }
  }

  // Use this for initialization
  void Awake()
  {
    Instance = this;

    CreateFolder();
    CreateBase();

 
  }

  void CreateFolder()
  {
    string date = DateTime.Now.ToString("yyyy_MM_dd-HH'h'mm'm'ss's'");
    folderName = System.IO.Directory.GetCurrentDirectory() + "\\" + "Assets\\" + "View\\" + date;
    System.IO.Directory.CreateDirectory(folderName);
  }

  void CreateBase()
  {
    Room room = new Room(0, 0, width, height);

    tableau = Master_Dungeon.create_board(room.width, room.height);

    for (int i = 0; i < room.width; i++)
      {
        for (int j = 0; j < room.height; j++)
          {
            tableau[i, j] = ' ';
            if (i == 0)
              {
                tableau[i, j] = '1';
              }
            if (i == room.width - 1)
              {
                tableau[i, j] = '1';
              }

            if (j == 0)
              {
                tableau[i, j] = '1';
              }
            if (j == room.height - 1)
              {
                tableau[i, j] = '1';
              }
          }
      }



//      for (int i = 0; i < room.width; i++)
//        {
//          for (int j = 0; j < room.height; j++)
//            {
//              tableau[i, j] = ' ';
//              if (i == 0)
//                {
//                  tableau[i, j] = '1';
//                }
//              if (i == room.width - 1)
//                {
//                  tableau[i, j] = '1';
//                }
//
//              if (j == 0)
//                {
//                  tableau[i, j] = '1';
//                }
//              if (j == room.height - 1)
//                {
//                  tableau[i, j] = '1';
//                }
//            }
//        }
          
    string path = "Dungeon.txt";

    Master_Dungeon.write_txt(path, tableau);
  }
}
