using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Master_Room
{
  Room room;
 
  List<Room> listRoom = new List<Room>();
  int numberWall = 5;

  int widthMin = 5;
  int heightMin = 5;

  Random rnd = new Random();

  public void data_in(int seed, int width, int height)
  {
    // Base
    char[,] tableau = new char[width, height];
    room = new Room(0, 0, width, height);
    listRoom.Add(room);

    int widthNew = rnd.Next(room.width - room.width, room.width);
    int heightNew = rnd.Next(room.height - room.height, room.height);
 
    for (int i = 0; i < room.width; i++)
      {
        for (int j = 0; j < room.height; j++)
          {
            tableau[i, j] = ' ';
          }
      }

    CreateWall(tableau);

    // Wall

//      rnd.
//    for (int w = 0; w < numberWall; w++)
//      {
//        if (Random.Range(1, 3) == 1)
//          {
//            room = new Room(0, 0, listRoom[0].width, height);
//          } else
//          {
//            room = new Room(0, 0, listRoom[0].width, height / 2);
//          }
//      }

    string path = "Dungeon_Base.txt";
    Master_Dungeon.write_txt(path, tableau);

  }

  void CreateWall(char[,] tableau)
  {
    for (int i = 0; i < room.width; i++)
      {
        for (int j = 0; j < room.height; j++)
          {
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
  }

  public void phase_begin()
  {

  }

  public void phase_update()
  {

  }

  public void phase_end()
  {

  }

  public void view()
  {

  }

  public List<Room> data_out()
  {
    return new List<Room>();
  }

  public void kill()
  {

  }

  public static void draw_layer_txt(char[,] arr_tile, List<Room> list_room)
  {

  }
}
