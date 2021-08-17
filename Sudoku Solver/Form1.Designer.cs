namespace Sudoku_Solver
{
    partial class PuzzleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox[,] textBoxes;
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
        /// 
        
        private void InitializeComponent()

        {
            this.Solve = new System.Windows.Forms.Button();
            this.GeneratePuzzle = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(455, 73);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(122, 33);
            this.Solve.TabIndex = 0;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // GeneratePuzzle
            // 
            this.GeneratePuzzle.Location = new System.Drawing.Point(455, 22);
            this.GeneratePuzzle.Name = "GeneratePuzzle";
            this.GeneratePuzzle.Size = new System.Drawing.Size(122, 45);
            this.GeneratePuzzle.TabIndex = 1;
            this.GeneratePuzzle.Text = "Generate Default Puzzle";
            this.GeneratePuzzle.UseVisualStyleBackColor = true;
            this.GeneratePuzzle.Click += new System.EventHandler(this.generate_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(455, 118);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(122, 33);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit Solution";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(455, 163);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(122, 33);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_result.Location = new System.Drawing.Point(454, 224);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(0, 20);
            this.label_result.TabIndex = 4;
            // 
            // PuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sudoku_Solver.Properties.Resources.sudoku3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(580, 449);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.GeneratePuzzle);
            this.Controls.Add(this.Solve);
            this.DoubleBuffered = true;
            this.Name = "PuzzleForm";
            this.Text = "Sudoku";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.Button GeneratePuzzle;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label_result;
    }
}

