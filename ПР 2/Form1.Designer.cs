namespace ПР_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtA = new TextBox();
            txtB = new TextBox();
            txtE = new TextBox();
            txtFunction = new TextBox();
            A = new Label();
            B = new Label();
            E = new Label();
            Function = new Label();
            menuStrip1 = new MenuStrip();
            calculateMenuItem_Click = new ToolStripMenuItem();
            clearMenuItem_Click = new ToolStripMenuItem();
            plotView = new OxyPlot.WindowsForms.PlotView();
            lblResult = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtA
            // 
            txtA.Location = new Point(124, 136);
            txtA.Name = "txtA";
            txtA.Size = new Size(100, 23);
            txtA.TabIndex = 1;
            // 
            // txtB
            // 
            txtB.Location = new Point(124, 165);
            txtB.Name = "txtB";
            txtB.Size = new Size(100, 23);
            txtB.TabIndex = 2;
            // 
            // txtE
            // 
            txtE.Location = new Point(124, 194);
            txtE.Name = "txtE";
            txtE.Size = new Size(100, 23);
            txtE.TabIndex = 3;
            // 
            // txtFunction
            // 
            txtFunction.Location = new Point(124, 223);
            txtFunction.Name = "txtFunction";
            txtFunction.Size = new Size(100, 23);
            txtFunction.TabIndex = 4;
            // 
            // A
            // 
            A.AutoSize = true;
            A.Location = new Point(80, 139);
            A.Name = "A";
            A.Size = new Size(13, 15);
            A.TabIndex = 5;
            A.Text = "a";
            // 
            // B
            // 
            B.AutoSize = true;
            B.Location = new Point(80, 168);
            B.Name = "B";
            B.Size = new Size(14, 15);
            B.TabIndex = 6;
            B.Text = "b";
            // 
            // E
            // 
            E.AutoSize = true;
            E.Location = new Point(81, 197);
            E.Name = "E";
            E.Size = new Size(13, 15);
            E.TabIndex = 7;
            E.Text = "e";
            // 
            // Function
            // 
            Function.AutoSize = true;
            Function.Location = new Point(80, 226);
            Function.Name = "Function";
            Function.Size = new Size(25, 15);
            Function.TabIndex = 8;
            Function.Text = "f(x)";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { calculateMenuItem_Click, clearMenuItem_Click });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // calculateMenuItem_Click
            // 
            calculateMenuItem_Click.Name = "calculateMenuItem_Click";
            calculateMenuItem_Click.Size = new Size(69, 20);
            calculateMenuItem_Click.Text = "Решение";
            calculateMenuItem_Click.Click += решениеToolStripMenuItem_Click;
            // 
            // clearMenuItem_Click
            // 
            clearMenuItem_Click.Name = "clearMenuItem_Click";
            clearMenuItem_Click.Size = new Size(71, 20);
            clearMenuItem_Click.Text = "Очистить";
            clearMenuItem_Click.Click += очиститьToolStripMenuItem_Click;
            // 
            // plotView
            // 
            plotView.Location = new Point(256, 12);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(532, 426);
            plotView.TabIndex = 10;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(12, 317);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(plotView);
            Controls.Add(Function);
            Controls.Add(E);
            Controls.Add(B);
            Controls.Add(A);
            Controls.Add(txtFunction);
            Controls.Add(txtE);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Метод дихотомии";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtE;
        private TextBox txtFunction;
        private Label A;
        private Label B;
        private Label E;
        private Label Function;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem calculateMenuItem_Click;
        private ToolStripMenuItem clearMenuItem_Click;
        private OxyPlot.WindowsForms.PlotView plotView;
        private Label lblResult;
    }
}