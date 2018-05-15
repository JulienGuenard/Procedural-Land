using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Master_Dungeon : MonoBehaviour
{
  static string folder_name;

  static void Main(string[] args)
  {
    // Parameter
    int width = 30;
    int height = 30;

    // Create folder
    string date = DateTime.Now.ToString("yyyy_MM_dd-HH'h'mm'm'ss's'");
    Master_Dungeon.folder_name = System.IO.Directory.GetCurrentDirectory() + "\\" + "View\\" + date;
    System.IO.Directory.CreateDirectory(Master_Dungeon.folder_name);

    // Random
    Master_Random master_random = new Master_Random();
    master_random.data_in();
    master_random.phase_begin();
    master_random.phase_update();
    master_random.phase_end();
    master_random.view();
    int seed = master_random.data_out();
    master_random.kill();


    // Room
    Master_Room master_room = new Master_Room();
    master_room.data_in(seed, width, height);
    master_room.phase_begin();
    master_room.phase_update();
    master_room.phase_end();
    master_room.view();
    List<Room> list_room = master_room.data_out();
    master_room.kill();

    // Web
    Master_Web master_web = new Master_Web();
    master_web.data_in(list_room);
    master_web.phase_begin();
    master_web.phase_update();
    master_web.phase_end();
    master_web.view();
    Web web = master_web.data_out();
    master_web.kill();

    // Door
    Master_Door master_door = new Master_Door();
    master_door.data_in(list_room, web, width, height);
    master_door.phase_begin();
    master_door.phase_update();
    master_door.phase_end();
    master_door.view();
    List<Door> list_door = master_door.data_out();
    master_door.kill();

    // Stair
    Master_Stair master_stair = new Master_Stair();
    master_stair.data_in(web, width, height);
    master_stair.phase_begin();
    master_stair.phase_update();
    master_stair.phase_end();
    master_stair.view();
    List<Stair> list_stair = master_stair.data_out();
    master_stair.kill();

    // Enemy
    Master_Enemy master_enemy = new Master_Enemy();
    master_enemy.data_in(web, width, height, list_stair);
    master_enemy.phase_begin();
    master_enemy.phase_update();
    master_enemy.phase_end();
    master_enemy.view();
    List<Enemy> list_enemy = master_enemy.data_out();
    master_enemy.kill();

    // Dungeon Drawing
    char[,] arr_tile = Master_Dungeon.create_board(width, height);
    Master_Room.draw_layer_txt(arr_tile, list_room);
    Master_Door.draw_layer_txt(arr_tile, list_door);
    Master_Stair.draw_layer_txt(arr_tile, list_stair);
    Master_Enemy.draw_layer_txt(arr_tile, list_enemy);
    Master_Dungeon.write_txt("final_dungeon.txt", arr_tile);


  }


  public static void write_txt(string name, string data)
  {
    //  string date = DateTime.Now.ToString("yyyy_MM_dd-HH'h'mm'm'ss's'");
    // string folderName = System.IO.Directory.GetCurrentDirectory() + "\\" + "Assets\\" + "View\\" + date;

    string path = ProceduralManager.folderName + "/" + name;
    System.IO.File.WriteAllText(path, data);
    path = System.IO.Directory.GetCurrentDirectory() + "\\" + "View\\" + "current\\" + name;
//    System.IO.File.WriteAllText(path, data);
  }

  public static void write_txt(string name, char[,] arr_tile)
  {
    string data = "";

    for (int y = arr_tile.GetUpperBound(1); y >= 0; y--)
      {
        for (int x = 0; x <= arr_tile.GetUpperBound(0); x++)
          {
            Debug.Log("aaa");
            char tile = arr_tile[x, y];
            data += tile.ToString();
          }
        data += "\r\n";
      }
    write_txt(name, data);
  }


  public static char[,] create_board(int width, int height)
  {
    char[,] arr_tile = new char[width, height];
    return arr_tile;
  }

}
