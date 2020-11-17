using System;
using System.Collections.Generic;
using System.Text;

class Bscreen : screen
{


    screen screen;



    public Bscreen(screen _screen) : base(X, (Y - 2), false)
    {
        screen = _screen;


    }
    public int getY
    {
        get
        {
            return list.Count;
        }


    }
    public List<List<string>> getlist
    {
        get
        {
            return list;
        }


    }
    public void Bdraw()
    {
        for (int y = 0; y < list.Count; y++)
        {
            for (int x = 0; x < list[y].Count; x++)
            {
                if (list[y][x] == "■")
                {
                    screen.drawblock(x, y + 1, list[y][x]);
                }
                //Console.Write(list[y][x]);
            }
            // Console.WriteLine();

        }
    }
    public void breakline() {
      
        for (int y = list.Count-1; y > 0; y--)
        {
            bool breakl = true;
            for (int x = 0; x < list[y].Count; x++)
            {
                if (list[list.Count - 1][x] == "□")
                {
                    breakl = false;
                  
                }
              
            }
            if (breakl)
            {
                newlist();
            }

        }
        
      
       
    }
    public void newlist()
    {

        Console.Write("실행 돼ㅣㅁ");
        List<string> newlist = new List<string>();
        for (int _x = 0; _x < X; _x++)
        {
            newlist.Add("□");
        }
        list.Insert(0, newlist);
        list.RemoveAt(list.Count - 1);
        // 0번째에 추가
      
    }

        public void pileup(string[][] block, int x, int y)
        {

            for (int _y = 0; _y < 4; _y++)
            {

                for (int _x = 0; _x < 4; _x++)
                {
                    if (block[_y][_x] == "■")
                    {
                        list[y + _y][x + _x] = "■";

                    }
                }


            }

        }


    
}