namespace AStarTest
{
  partial class Form1
  {
    /// <summary>
    /// 設計工具所需的變數。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清除任何使用中的資源。
    /// </summary>
    /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form 設計工具產生的程式碼

    /// <summary>
    /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
    /// 這個方法的內容。
    /// </summary>
    private void InitializeComponent()
    {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Again = new System.Windows.Forms.Button();
            this.bt_Set = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.bt_Previous = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_randm = new System.Windows.Forms.Button();
            this.bt_Custom = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bt_Again);
            this.panel1.Controls.Add(this.bt_Set);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.bt_Clear);
            this.panel1.Controls.Add(this.bt_Previous);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bt_randm);
            this.panel1.Controls.Add(this.bt_Custom);
            this.panel1.Location = new System.Drawing.Point(806, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 400);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(215, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 22);
            this.label4.TabIndex = 19;
            // 
            // bt_Again
            // 
            this.bt_Again.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_Again.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_Again.Location = new System.Drawing.Point(167, 187);
            this.bt_Again.Name = "bt_Again";
            this.bt_Again.Size = new System.Drawing.Size(100, 45);
            this.bt_Again.TabIndex = 18;
            this.bt_Again.Text = "Again";
            this.bt_Again.UseVisualStyleBackColor = false;
            this.bt_Again.Click += new System.EventHandler(this.bt_Again_Click);
            // 
            // bt_Set
            // 
            this.bt_Set.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_Set.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_Set.Location = new System.Drawing.Point(167, 103);
            this.bt_Set.Name = "bt_Set";
            this.bt_Set.Size = new System.Drawing.Size(100, 45);
            this.bt_Set.TabIndex = 17;
            this.bt_Set.Text = "Set";
            this.bt_Set.UseVisualStyleBackColor = false;
            this.bt_Set.Click += new System.EventHandler(this.bt_Set_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(163, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Size:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 15;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // bt_Clear
            // 
            this.bt_Clear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_Clear.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_Clear.Location = new System.Drawing.Point(15, 254);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(107, 45);
            this.bt_Clear.TabIndex = 14;
            this.bt_Clear.Text = "Clear";
            this.bt_Clear.UseVisualStyleBackColor = false;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // bt_Previous
            // 
            this.bt_Previous.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_Previous.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_Previous.Location = new System.Drawing.Point(15, 187);
            this.bt_Previous.Name = "bt_Previous";
            this.bt_Previous.Size = new System.Drawing.Size(107, 45);
            this.bt_Previous.TabIndex = 13;
            this.bt_Previous.Text = "Previous";
            this.bt_Previous.UseVisualStyleBackColor = false;
            this.bt_Previous.Click += new System.EventHandler(this.bt_Previous_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Obstacle:";
            // 
            // bt_randm
            // 
            this.bt_randm.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_randm.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_randm.Location = new System.Drawing.Point(15, 120);
            this.bt_randm.Name = "bt_randm";
            this.bt_randm.Size = new System.Drawing.Size(107, 45);
            this.bt_randm.TabIndex = 10;
            this.bt_randm.Text = "Randm";
            this.bt_randm.UseVisualStyleBackColor = false;
            this.bt_randm.Click += new System.EventHandler(this.bt_randm_Click);
            // 
            // bt_Custom
            // 
            this.bt_Custom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_Custom.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_Custom.Location = new System.Drawing.Point(15, 53);
            this.bt_Custom.Name = "bt_Custom";
            this.bt_Custom.Size = new System.Drawing.Size(107, 45);
            this.bt_Custom.TabIndex = 9;
            this.bt_Custom.Text = "Custom";
            this.bt_Custom.UseVisualStyleBackColor = false;
            this.bt_Custom.Click += new System.EventHandler(this.bt_Custom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1204, 753);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "A* Algorithm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.ComponentModel.BackgroundWorker backgroundWorker2;
    private System.ComponentModel.BackgroundWorker backgroundWorker3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bt_Set;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button bt_Clear;
    private System.Windows.Forms.Button bt_Previous;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button bt_randm;
    private System.Windows.Forms.Button bt_Custom;
    private System.Windows.Forms.Button bt_Again;
    private System.Windows.Forms.Label label4;
  }
}

