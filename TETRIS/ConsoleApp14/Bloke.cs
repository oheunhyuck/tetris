using System;
using System.Collections.Generic;
using System.Text;

   partial class Block
    {
    List<List<string[][]>> block = new List<List<string[][]>>();
    int x;
    int y;
    screen screen;
    string[][] sblock;
    blocktype curtype;
    Blockdic curdic;
    Random random = new Random();
    Bscreen bscreen;
   

    public enum Blockdic
    {
        T,
        R,
        L,
        B,
        Max
    }
    public enum blocktype
    {
        I,
        L,
        J,
        Z,
        S,
        T,
        O,
        Max
    }
    public void ramdomblock()
    {
        curtype = (blocktype)random.Next(0,(int) blocktype.Max);
        curdic= (Blockdic)random.Next(0,(int)Blockdic.Max);
        sblock = block[(int)curtype][(int)curdic];
        

    }
    public void down()
    {
        y = -1;
    }
    public Block(screen screen,blocktype _type,Blockdic _dic,Bscreen _bscreen)
    {
       
        blockcreate();
        sblock = block[(int)_type][(int)_dic];
        this.screen = screen;
        bscreen = _bscreen;
        
      
        curtype = _type;
        curdic = _dic;
    }
    public void blockcreate()
    {
        for (int i = 0; i < (int)blocktype.Max; i++)
        {
            block.Add(new List<string[][]>());
            for (int a = 0; a < (int)Blockdic.Max; a++)
            {
                block[i].Add(null);
            }
        }

        block[(int)blocktype.I][(int)Blockdic.T] = new string[][]
        {
            new string[] { "■", "■", "■", "■" },
            new string[] { "□", "□", "□", "□" },
            new string[] { "□", "□", "□", "□" },
            new string[] { "□", "□", "□", "□" }
        };
        block[(int)blocktype.I][(int)Blockdic.R] = new string[][]
    {
            new string[] { "□", "□", "□", "■" },
            new string[] { "□", "□", "□", "■" },
            new string[] { "□", "□", "□", "■" },
            new string[] { "□", "□", "□", "■" }
    };
        block[(int)blocktype.I][(int)Blockdic.L] = new string[][]
{
            new string[] { "■", "□", "□", "□" },
            new string[] { "■", "□", "□", "□" },
            new string[] { "■", "□", "□", "□" },
            new string[] { "■", "□", "□", "□" }
    };
        block[(int)blocktype.I][(int)Blockdic.B] = new string[][]
{
            new string[] { "□", "□", "□", "□" },
            new string[] { "□", "□", "□", "□" },
            new string[] { "□", "□", "□", "□" },
            new string[] { "■", "■", "■", "■" }
    };

    }
    public bool check()
    {
        for(int y=0; y < 4; y++)
        {
            for(int x = 0; x < 4; x++)
            {
                if (sblock[y][x] == "■")
                {
                    if (this.y + y == bscreen.getY || bscreen.getlist[this.y + y][this.x+x]=="■")
                    {
                      
                        return true;
                        
                    }
                    
                }
            }
        }
        return false;
    }
    public void goup()
    {
        //ramdomblock();
        x = 0;
        y = 1;

    }
    public void ground()
    {
       
        if (check())
        {
          
            bscreen.pileup(sblock, x, y -1);
           // goup();


        }
    }
    public void deletepre()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                screen.resetblock(sblock[y][x], (this.y + y), (this.x + x));
            }
        }
    }
    public void move()
    {
        if (true == Console.KeyAvailable)
        {
            switch (Console.ReadKey().Key)

            {
                case (ConsoleKey.A):
                    deletepre();

                     x -= 1;
                    break;
                case (ConsoleKey.D):
                    deletepre();
                    x += 1;
                    break;
                case (ConsoleKey.S):
                    if (check() != true) {
                        deletepre();
                        y += 1;
                    }
                    
                    break;
                case (ConsoleKey.Q):
                    deletepre();
               

                    if (curdic == Blockdic.B)
                    {
                        
                        sblock=block[(int)curtype][(int)Blockdic.T];
                        curdic = Blockdic.T;
                    }
                    else {
                        sblock=block[(int)curtype][(int)curdic + 1];
                        curdic = (Blockdic)((int)curdic + 1);
                            
                    }
                    break;
                case (ConsoleKey.E):
                    deletepre();
                    if (curdic == Blockdic.T)
                    {

                        sblock = block[(int)curtype][(int)Blockdic.B];
                        curdic = Blockdic.B;
                    }
                    else
                    {
                        sblock = block[(int)curtype][(int)curdic -1];
                        curdic = (Blockdic)((int)curdic -1);


                    }
                    break;



                default:
                    break;
            }
            for(int y = 0; y < 4; y++)
            {
                for(int x =0; x < 4; x++)
                {
                    if (sblock[y][x] == "■")
                    {
                        screen.drawblock((this.x + x), (this.y + y), sblock[y][x]);
                        
                    }
                }
            }

        }

    }
}