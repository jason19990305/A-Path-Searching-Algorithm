using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace AStarTest
{
  public partial class Form1 : Form
  {
    private List<Estimate> OpenList;
    private List<Estimate> CloseList;
    private int x = 0;
    private int y = 0;
    private int CloseCount;
    private Estimate Current;
    private Estimate Previous;
    private int width;
    private int height;
    private Graphics g;
    private bool NeedCloseFlag;
    private bool NeedCloseFinal;
    private List<Point> Obstacle;
    private int size;
    private Random crandom;
    private bool DoneForChoice;
    private bool StartForChoic;
    private bool MouseDownBool;
    private Bitmap backBmp;
    private int StartSize;
    private int SearchTime;
    private Brush RedBrush;
    private Pen LinePen;
    private Brush BlueBursh;
    private Brush WhiteBrush;
    private Pen WhitePen;
    private Brush GreenBrush;
    public Form1()
    {
      InitializeComponent();
      RedBrush = new SolidBrush(Color.Red);
      LinePen = new Pen(Color.Yellow, 2);
      BlueBursh = new SolidBrush(Color.Blue);
      WhiteBrush = new SolidBrush(Color.White);
      WhitePen = new Pen(Color.FromArgb(240, 240, 240), 1);
      GreenBrush = new SolidBrush(Color.Green);
      SearchTime = 0;
      this.Show();
      NeedCloseFlag = false;
      NeedCloseFinal = false;
      backBmp = new Bitmap(this.DisplayRectangle.Width
   , this.DisplayRectangle.Height);
      g = Graphics.FromImage(backBmp);

      OpenList = new List<Estimate>();//initialiation
      CloseList = new List<Estimate>();//initialiation
      crandom = new Random();
      Obstacle = new List<Point>();
      DoneForChoice = false;

      CloseCount = 0;
      width = 20;
      height = 20;
      label4.Text = "20x20";
      UpdateSize();
      StartSize = size;
      StartForChoic = false;
      MouseDownBool = false;
      DrawGrid();
    }
    private void UpdateGrid(int n)
    {
      width = n;
      height = n;
      label4.Text = n.ToString() + "x" + n.ToString();
      double gg = 500.0 / n;
      size = Convert.ToInt32(gg);
      g.Clear(Color.Black);
      DrawGrid();
    }
    private void DrawOpen()//劃出所有OpenList
    {
      g.FillRectangle(BlueBursh, 0 * size, 0 * size, size - 1, size - 1);
      g.FillRectangle(BlueBursh, (width - 1) * size, (height - 1) * size, size - 1, size - 1);
      foreach (Estimate v in OpenList)
      {
        int x = v.x;
        int y = v.y;
        if (x == 0 && y == 0 || (width - 1) == x && (height - 1) == y)
          continue;
        g.FillRectangle(GreenBrush, x * size, y * size, size - 1, size - 1);
      }
    }
    private void DrawOpenOnce(Estimate v)//劃出所有OpenList
    {
      int x = v.x;
      int y = v.y;
      if (x == 0 && y == 0 || (width - 1) == x && (height - 1) == y)
        return;
      g.FillRectangle(GreenBrush, x * size, y * size, size - 1, size - 1);

    }
    private void DrawClose()//畫出所有CloseList
    {
      foreach (Estimate v in CloseList)
      {
        int x = v.x;
        int y = v.y;
        if (x == 0 && y == 0 || (width - 1) == x && (height - 1) == y)
          continue;
        g.FillRectangle(RedBrush, x * size, y * size, size - 1, size - 1);
        int d = v.direction;
        y += -1 * ((d - 1) / 3 - 1);
        x += -1 * ((d - 1) % 3 - 1);
        Point p1 = new Point(v.x * size + size / 2, v.y * size + size / 2);
        Point p2 = new Point(x * size + size / 2, y * size + size / 2);
        g.DrawLine(LinePen, p1, p2);
      }
    }
    private void DrawCloseOnce()//
    {
      try
      {
        int x = Current.x;
        int y = Current.y;
        int d = Current.direction;
        if (x == 0 && y == 0 || (width - 1) == x && (height - 1) == y)
          return;
        g.FillRectangle(RedBrush, x * size, y * size, size - 1, size - 1);
        Point p1 = new Point(x * size + size / 2, y * size + size / 2);
        y += -1 * ((d - 1) / 3 - 1);
        x += -1 * ((d - 1) % 3 - 1);

        Point p2 = new Point(x * size + size / 2, y * size + size / 2);
        g.DrawLine(LinePen, p1, p2);
      }
      catch (Exception E) { }
    }
    private void DrawObstacle()//畫出所有Obstacle
    {
      Pen WhitePen = new Pen(Color.FromArgb(240, 240, 240), 1);
      try
      {
        g.DrawLine(WhitePen, width * size, height * size, 0, height * size);//y
        g.DrawLine(WhitePen, width * size, height * size, width * size, 0);//x

      }
      catch (Exception E)
      {
        g.DrawLine(WhitePen, width * size, height * size, 0, height * size);//y
        g.DrawLine(WhitePen, width * size, height * size, width * size, 0);//x
      }

      foreach (Point v in Obstacle)
      {
        int x = v.X;
        int y = v.Y;
        if (x == 0 && y == 0 || (width - 1) == x && (height - 1) == y)
          continue;
        g.FillRectangle(WhiteBrush, x * size, y * size, size - 1, size - 1);
      }

    }
    private void DrawGrid()//劃出grid
    {
      g.FillRectangle(BlueBursh, 0 * size, 0 * size, size - 1, size - 1);
      g.FillRectangle(BlueBursh, (width - 1) * size, (height - 1) * size, size - 1, size - 1);
      for (int i = 0; i <= width; i++)
      {
        int m = i * size;
        g.DrawLine(WhitePen, m, 0, m, height * size);//y
        g.DrawLine(WhitePen, 0, m, width * size, m);//x
      }
      this.CreateGraphics().DrawImageUnscaled(backBmp, 0, 0);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      OpenList.Add(new Estimate(0, 0, 0, 9 * 14, 5));
      this.Resize -= new System.EventHandler(this.Form1_Resize);
      g.Clear(Color.Black);
      DrawObstacle();
      g.FillRectangle(BlueBursh, 0 * size, 0 * size, size - 1, size - 1);
      g.FillRectangle(BlueBursh, (width - 1) * size,
        (height - 1) * size, size - 1, size - 1);

      while (true)
      {
        if (NeedCloseFlag)
        {
          if (OpenList.Count != 0)
          {
            backgroundWorker2.RunWorkerAsync();//劃出路線
          }
          backgroundWorker1.CancelAsync();
          break;
        }
        else
        {
          Thread.Sleep(1);
          try
          {
            backgroundWorker1.ReportProgress(1);
          }
          catch (Exception E)
          { }

          Thread.Sleep(10);
        }

      }
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {

      try
      {
        if (NeedCloseFlag)
          return;
        DrawCloseOnce();
        this.CreateGraphics().DrawImageUnscaled(backBmp, 0, 0);

        Previous = Current;//紀錄前一個點
        Current = OpenList[0];//移動當前點  index0是排序後最佳的點
        CloseList.Add(Current);//當前點加入CloseList
      }
      catch (Exception E)
      { }


      if (Current == null)
        return;
      for (int i = -1; i <= 1; i++)//新增OpenPoint
      {
        for (int j = -1; j <= 1; j++)
        {
          int x = Current.x + j;
          int y = Current.y + i;
          int OBstacleIndex = Obstacle.FindIndex(v => v.X == x && v.Y == y);
          int CloseIndex = CloseList.FindIndex(v => v.x == x && v.y == y);
          if (OBstacleIndex >= 0 ||
            CloseIndex >= 0)//如果ObstacleList有點P就跳過
          {
            continue;
          }
          if (y < 0 || y > height - 1 || x < 0 || x > width - 1)//超出範圍
            continue;
          int x1 = x;
          int y1 = y;
          if (x1 < y1)
            Swap<int>(ref x1, ref y1);
          int h = ((width - 1 - x) + (height - y - 1)) * 10;
          int d = (i + 1) * 3 + (j + 1) + 1;//計算移動方向
          int g;
          if (i == j || i * -1 == j || j * -1 == i)
            g = Current.g + 16;
          else
            g = Current.g + 10;
          int index = OpenList.FindIndex(v => v.x == x && v.y == y);
          if (index >= 0)//OpenList有發現點P
          {
            if (OpenList[index].g > g)//比較g的大小
            {
              OpenList[index].Set(x, y, g, h, d);//更新g
              DrawOpenOnce(new Estimate(x, y, g, h, d));
            }
          }
          else
          {
            OpenList.Add(new Estimate(x, y, g, h, d));
            DrawOpenOnce(new Estimate(x, y, g, h, d));
            //新增OpenList
          }
        }
      }

      try
      {
        int index = OpenList.FindIndex(v => v == Previous);//2.刪除前一個當前點
        if (index >= 0)//2.刪除前一個當前點
        {
          OpenList.RemoveAt(index);//2.刪除前一個當前點
        }
        index = OpenList.FindIndex(v => v.x == width - 1
        && v.y == height - 1);//找看看有沒有到終點
        if (OpenList.Count == 0 || index >= 0)//判斷結束條件
        {
          if (index >= 0)
          {
            Current = OpenList[index];
            label2.Text = "Done for sarch path\nSearching " +
              SearchTime.ToString() + " times";
          }
          else
            label2.Text = "Can't find path";
          NeedCloseFlag = true;
          backgroundWorker1.CancelAsync();

          g.Clear(Color.Black);
          DrawOpen();
          DrawClose();
          DrawObstacle();

          return;
        }

        OpenList.Sort((x, y) =>
        {
          int n = x.f.CompareTo(y.f);
          if (n == 0)
            return x.h.CompareTo(y.h);
          return n;
        });//對Open的F做排序
      }
      catch (Exception E) { }
      SearchTime++;
    }
    private static void Swap<T>(ref T lhs, ref T rhs)//交換
    {
      T temp;
      temp = lhs;
      lhs = rhs;
      rhs = temp;
    }
    private void backgroundWorker2_ProgressChanged(object sender,
      ProgressChangedEventArgs e)
    {

      int x = Current.x;
      int y = Current.y;
      int x1 = x;
      int y1 = y;
      int d = Current.direction;
      y += -1 * ((d - 1) / 3 - 1);
      x += -1 * ((d - 1) % 3 - 1);

      if (Current.x == 0 && Current.y == 0)
      {
        NeedCloseFinal = true;
        return;
      }

      Pen LightBluePen = new Pen(Color.FromArgb(100, 100, 255), 7);
      try
      {
        g.DrawLine(LightBluePen, x * size + size / 2, y * size + size / 2,
          x1 * size + size / 2, y1 * size + size / 2);
        this.CreateGraphics().DrawImageUnscaled(backBmp, 0, 0);
        int index = CloseList.FindIndex(v => v.x == x && v.y == y);
        Current = CloseList[index];
      }
      catch (Exception E) { }
      if (x == 0 && y == 0)
        backgroundWorker2.CancelAsync();
    }

    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
      int i = 0;

      if (!backgroundWorker1.CancellationPending)
        backgroundWorker1.CancelAsync();

      while (true)
      {
        if (NeedCloseFinal)
        {
          try
          {
            backgroundWorker2.CancelAsync();
          }
          catch (Exception E) { }
          break;
        }
        try
        {
          backgroundWorker2.ReportProgress(i++);
        }
        catch (Exception E)
        {
          backgroundWorker2.ReportProgress(i++);
        }

        Thread.Sleep(5);
      }
    }

    private void bt_Custom_Click(object sender, EventArgs e)
    {
      if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
      {
        if (StartForChoic == false)
        {
          StartForChoic = true;
          backgroundWorker3.RunWorkerAsync();
          bt_Custom.BackColor = Color.Yellow;
          bt_Custom.Text = "Done";
          bt_randm.Enabled = false;
          bt_Set.Enabled = false;
        }
        else
        {
          DoneForChoice = true;
          bt_Custom.Enabled = false;
          bt_randm.Enabled = false;
          bt_Clear.Enabled = false;
          bt_Previous.Enabled = false;
          bt_Set.Enabled = false;
          this.textBox1.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
          this.FormBorderStyle = FormBorderStyle.FixedSingle;
          backgroundWorker3.CancelAsync();
          label2.Text = "Start!!";
          if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync();//start algorithm
        }
      }

    }
    private void bt_randm_Click(object sender, EventArgs e)
    {
      if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
      {
        for (int i = 0; i < width * height * 0.4; i++)
        {
          int x = crandom.Next(width);
          int y = crandom.Next(width);
          Point p = new Point(x, y);
          int ObstacleIndex = Obstacle.FindIndex(v => v == p);
          if (ObstacleIndex >= 0 || (x == 0 && y == 0) || (x == width - 1 && y == height - 1))
          {
            i--;
            continue;
          }
          Obstacle.Add(p);
        }
        bt_Custom.Enabled = false;
        bt_randm.Enabled = false;
        bt_Clear.Enabled = false;
        bt_Previous.Enabled = false;
        bt_Set.Enabled = false;
        this.textBox1.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        label2.Text = "Start!!";
        backgroundWorker1.RunWorkerAsync();//start algorithm
      }
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      if (!StartForChoic)
        return;
      MouseDownBool = true;
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
      if (!StartForChoic)
        return;
      MouseDownBool = false;
    }

    private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        if (!StartForChoic || DoneForChoice)
          continue;
        if (!MouseDownBool)
          continue;
        backgroundWorker3.ReportProgress(1);
        Thread.Sleep(1);
      }
    }

    private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      var relativePoint = this.PointToClient(Cursor.Position);//取得視窗相對螢幕的滑鼠位置
      int x = relativePoint.X / size;
      int y = relativePoint.Y / size;
      var p = new Point(x, y);
      int ObstacleIndex = Obstacle.FindIndex(v => v == p);
      if (ObstacleIndex >= 0 || (x == 0 && y == 0) ||
        (x == width - 1 && y == height - 1) ||
        x >= width || y >= height
        )
        return;
      label2.Text = "Y:" + y.ToString() + "\nX:" + x.ToString();
      Brush WhiteBrush = new SolidBrush(Color.White);
      g.FillRectangle(WhiteBrush, x * size, y * size, size - 1, size - 1);
      this.CreateGraphics().DrawImageUnscaled(backBmp, 0, 0);
      Obstacle.Add(p);
    }

    private void bt_Previous_Click(object sender, EventArgs e)
    {
      try
      {
        Obstacle.RemoveAt(Obstacle.Count - 1);
        g.Clear(Color.Black);
        DrawObstacle();
        DrawGrid();
      }
      catch (Exception E) { }
    }

    private void bt_Clear_Click(object sender, EventArgs e)
    {
      Obstacle.Clear();
      g.Clear(Color.Black);
      DrawGrid();
    }

    private void bt_Set_Click(object sender, EventArgs e)
    {
      try
      {
        int n = Convert.ToInt32(textBox1.Text);
        width = n;
        height = n;
        label4.Text = n.ToString() + "x" + n.ToString();
        UpdateSize();
      }
      catch (Exception E) { }
    }
    private void bt_Again_Click(object sender, EventArgs e)
    {
      try
      {
        Application.ExitThread();
        Restart();
      }
      catch (Exception E) { }

    }
    private void Restart()
    {
      System.Threading.Thread thtmp = new System.Threading.Thread(new
      System.Threading.ParameterizedThreadStart(run));
      object appName = Application.ExecutablePath;
      System.Threading.Thread.Sleep(10);
      thtmp.Start(appName);
    }

    private void run(Object obj)
    {
      System.Diagnostics.Process ps = new System.Diagnostics.Process();
      ps.StartInfo.FileName = obj.ToString();
      ps.Start();
    }


    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)13)
      {
        try
        {
          int n = Convert.ToInt32(textBox1.Text);
          width = n;
          height = n;
          label4.Text = n.ToString() + "x" + n.ToString();
          UpdateSize();
        }
        catch (Exception E) { }
      }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      UpdateSize();
    }
    private void UpdateSize()
    {
      int w;
      int h;
      double gg;
      try
      {
        w = this.Size.Width;
        h = this.Size.Height;
        panel1.Location = new Point(w - 280, 12);
        if (w < h)
          Swap(ref w, ref h);
        gg = 0.9 * h / width;

        backBmp = new Bitmap(this.DisplayRectangle.Width
   , this.DisplayRectangle.Height);
        g = Graphics.FromImage(backBmp);

        size = Convert.ToInt32(gg);
        g.Clear(Color.Black);

        if (StartForChoic)
          DrawObstacle();
        DrawGrid();
      }
      catch (Exception E)
      { }
    }
  }
}
