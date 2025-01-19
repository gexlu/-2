namespace ПР_2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblResult = new Label();
            plotView = new OxyPlot.WindowsForms.PlotView();
            Function = new Label();
            E = new Label();
            B = new Label();
            A = new Label();
            txtFunction = new TextBox();
            txtE = new TextBox();
            txtB = new TextBox();
            txtA = new TextBox();
            menuStrip1 = new MenuStrip();
            calculateMenuItem_Click = new ToolStripMenuItem();
            clearMenuItem_Click = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(12, 323);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 22;
            // 
            // plotView
            // 
            plotView.Location = new Point(256, 18);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(532, 426);
            plotView.TabIndex = 21;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // Function
            // 
            Function.AutoSize = true;
            Function.Location = new Point(80, 232);
            Function.Name = "Function";
            Function.Size = new Size(25, 15);
            Function.TabIndex = 19;
            Function.Text = "f(x)";
            // 
            // E
            // 
            E.AutoSize = true;
            E.Location = new Point(81, 203);
            E.Name = "E";
            E.Size = new Size(13, 15);
            E.TabIndex = 18;
            E.Text = "e";
            // 
            // B
            // 
            B.AutoSize = true;
            B.Location = new Point(80, 174);
            B.Name = "B";
            B.Size = new Size(14, 15);
            B.TabIndex = 17;
            B.Text = "b";
            // 
            // A
            // 
            A.AutoSize = true;
            A.Location = new Point(80, 145);
            A.Name = "A";
            A.Size = new Size(13, 15);
            A.TabIndex = 16;
            A.Text = "a";
            // 
            // txtFunction
            // 
            txtFunction.Location = new Point(124, 229);
            txtFunction.Name = "txtFunction";
            txtFunction.Size = new Size(100, 23);
            txtFunction.TabIndex = 15;
            // 
            // txtE
            // 
            txtE.Location = new Point(124, 200);
            txtE.Name = "txtE";
            txtE.Size = new Size(100, 23);
            txtE.TabIndex = 14;
            // 
            // txtB
            // 
            txtB.Location = new Point(124, 171);
            txtB.Name = "txtB";
            txtB.Size = new Size(100, 23);
            txtB.TabIndex = 13;
            // 
            // txtA
            // 
            txtA.Location = new Point(124, 142);
            txtA.Name = "txtA";
            txtA.Size = new Size(100, 23);
            txtA.TabIndex = 12;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { calculateMenuItem_Click, clearMenuItem_Click });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 20;
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
            // 
            // Form3
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
            Name = "Form3";
            Text = "Метод золотого сечения";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResult;
        private OxyPlot.WindowsForms.PlotView plotView;
        private Label Function;
        private Label E;
        private Label B;
        private Label A;
        private TextBox txtFunction;
        private TextBox txtE;
        private TextBox txtB;
        private TextBox txtA;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem calculateMenuItem_Click;
        private ToolStripMenuItem clearMenuItem_Click;
    }
}