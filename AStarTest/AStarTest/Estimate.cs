using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTest
{
  class Estimate
  {
    public int g;
    public int h;
    public int f;
    public int direction;
    public int x;
    public int y;
    public Estimate(int x, int y, int G, int H,int D)
    {
      g = G;
      h = H;
      f = g + h;
      direction = D;
      this.x = x;
      this.y = y;
    }
    public void Set(int x, int y, int G,int H,int D)
    {
      h = H;
      f = g + h;
      g = G;
      direction = D;
      this.x = x;
      this.y = y;
    }
    public Estimate()
    {

    }
  }
}
