using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Dungeon;

public class Master_Door : MonoBehaviour {

  List<Room> list_room;

  public void data_in(List<Room> list_room, Web web, int width, int height)
  {
    this.list_room = list_room;
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

  public List<Door> data_out()
  {
    return new List<Door>();
  }

  public void kill()
  {

  }

  public static void draw_layer_txt(char[,] arr_tile, List<Door> list_door)
  {

  }
}
