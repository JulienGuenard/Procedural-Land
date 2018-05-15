using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Room : MonoBehaviour
{
  Room room;
  char[,] tableau;
  List<Room> listRoom = new List<Room>();
  int numberWall = 5;

  int widthMin = 5;
  int heightMin = 5;

  public void data_in(int seed, int width, int height)
  {
    // Wall

    int widthNew = Random.Range(room.width - room.width, room.width);
    int heightNew = Random.Range(room.height - room.height, room.height);

    for (int w = 0; w < numberWall; w++)
      {
        if (listRoom.Count != 0)
          {
              
            if (Random.Range(1, 3) == 1)
              {
                room = new Room(0, 0, listRoom[0].width / 2, height);
              } else
              {
                room = new Room(0, 0, listRoom[0].width, height / 2);
              }
            listRoom.RemoveAt(0);
          } else
          {
            room = new Room(0, 0, width, height);
            tableau = Master_Dungeon.create_board(room.width, room.height);
            for (int i = 0; i < room.width; i++)
              {
                for (int j = 0; j < room.height; j++)
                  {
                    tableau[i, j] = ' ';
                  }
              }
          }
          
        listRoom.Add(room);

        // Base
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
      
    /*   for (int w = 0; w < wallNumber; w++)
      {
        listRoom.Add(room);
        for (int i = 0; i < room.width; i++)
          {
            tableau[i, room.height / 2] = '1';
          }
      }*/



    string path = "Dungeon_Base.txt";
    Master_Dungeon.write_txt(path, tableau);

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
