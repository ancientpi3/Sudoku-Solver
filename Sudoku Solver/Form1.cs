using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class PuzzleForm : Form
    {
        private void createArrayOfTextBoxes()
        {

            this.textBoxes = new System.Windows.Forms.TextBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.textBoxes[i, j] = InitializeTextBox(i, j);
                    this.Controls.Add(textBoxes[i, j]);
                }

            }


        }
        private bool isValidSudoku()
        {
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++)
                {
                    try
                    {
                       if  (10 <= int.Parse(this.textBoxes[i,j].Text) || 0 > int.Parse(this.textBoxes[i, j].Text))
                        {
                            return false;
                       }
                    }
                    catch (Exception e) {
                        if (this.textBoxes[i, j].Text != "") {
                            return false;
                        }
                        
                    }
                    if (isValidEntry(i, j, this.textBoxes[i, j].Text)==false)
                    {
                        return false;
                    }

                }
            }
            return true;

        }
        private bool isValidEntry(int row, int col, string num)
        {
            bool doReplace = false;
            
            if (num.Equals("")) {
                return true;
            }
            
            // string num = this.textBoxes[row, col].Text;
            if (this.textBoxes[row, col].Text.Equals(num))
            {
               this.textBoxes[row, col].Text = "";
               doReplace = true;
            }
            for (int x = 0; x < 9; x++)
            {
                if (this.textBoxes[row, x].Text.Equals(num))
                {
                    return false;
                }
            }
            for (int x = 0; x < 9; x++)
            {
                if (this.textBoxes[x, col].Text.Equals(num))
                {
                    return false;
                }
            }
            int cornerRow = row - row % 3;
            int cornerCol = col - col % 3;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (this.textBoxes[cornerRow + x, cornerCol + y].Text == num)
                    {
                        return false;
                    }
                }
            }

            if (doReplace) {
                this.textBoxes[row, col].Text = num;
            }
            return true;


        }
        private bool Recursive_Solve(int row, int col)
        {
            if (col == 9)
            {
                if (row == 8)
                {
                    return true;
                }
                row = row + 1;
                col = 0;
            }
            if (this.textBoxes[row, col].Text.Equals("")) { }
            else
            {
                return Recursive_Solve(row, col + 1);
            }

            for (int i = 1; i < 10; i++)
            {
                if (isValidEntry(row, col, i.ToString()))
                {
                    this.mutateTextBoxWithDelay(row,col,1,i.ToString());
                    
                    if (Recursive_Solve(row, col + 1))
                    {
                        return true;
                    }

                }
                this.textBoxes[row, col].Text = "";

            }
            return false;
        }

        private void mutateTextBoxWithDelay(int row, int col, int delay, string num) {
            this.textBoxes[row, col].Text = num;
            this.Update();
            System.Threading.Thread.Sleep(delay);
        }
        private void changeArrayOfTextBoxes(int[,] puzzle)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)

                {
                    this.textBoxes[i, j].Text = puzzle[i, j].ToString();
                    if (puzzle[i, j] == 0)
                    {
                        this.textBoxes[i, j].Text = "";
                    }


                }

            }

        }
        private System.Windows.Forms.TextBox InitializeTextBox(int index1, int index2, int initialValue = 0)
        {
            System.Windows.Forms.TextBox box = new System.Windows.Forms.TextBox();
            box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            box.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            box.Location = new System.Drawing.Point(5 + index1 * (50), 5 + index2 * (50));
            box.Name = "textBox" + index1.ToString() + index2.ToString();
            box.Size = new System.Drawing.Size(40, 49);
            box.TabIndex = 1;
            box.Text = initialValue.ToString();
            if (initialValue == 0) { box.Text = ""; }

            box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //box.TextChanged += new System.EventHandler(this.textBox2_TextChanged);

            return box;




        }
        public PuzzleForm()
        {

            createArrayOfTextBoxes();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

 

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void generate_Click(object sender, EventArgs e)
        {
            int[,] defaultSudoku = {{0, 0, 7, 0, 8, 0, 0, 1, 0},
                                    {9, 8, 0, 2, 5, 0, 0, 0, 3},
                                    {1, 0, 0, 0, 0, 0, 6, 5, 8},
                                    {0, 3, 0, 8, 1, 7, 0, 0, 0},
                                    {7, 0, 0, 6, 0, 5, 0, 0, 4},
                                    {0, 0, 0, 4, 2, 3, 0, 7, 0},
                                    {3, 6, 1, 0, 0, 0, 0, 0, 7},
                                    {5, 0, 0, 0, 6, 8, 0, 3, 9},
                                    {0, 7, 0, 0, 3, 0, 4, 0, 0},};
            this.label_result.Text = "";
            this.changeArrayOfTextBoxes(defaultSudoku);
        }

        private void solve_Click(object sender, EventArgs e)
        {
            if (isValidSudoku())
            {
                if (Recursive_Solve(0, 0) == false) { this.label_result.Text = "Unsolvable"; } else
                {
                    this.label_result.Text = "Sudoku Solved!";
                }
            }
            else
            {
                this.label_result.Text = "Invalid Sudoku";
            }
            
            
        }

        private void submit_Click(object sender, EventArgs e)
        {
            bool isComplete = true;
            foreach (System.Windows.Forms.TextBox t in this.textBoxes){
                if (t.Text.Equals("")){
                    isComplete = false;
                    break;
                }
            }
            if (isComplete)
            {
                if (isValidSudoku()) {
                    this.label_result.Text = "Sudoku Solved!";
                }
                else
                {
                    this.label_result.Text = "Invalid Answer";
                }
            }
            else
            {
                label_result.Text = "Keep Solving!";
            }


            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            int[,] emptySudoku = {{0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0},};
            this.changeArrayOfTextBoxes(emptySudoku);
            this.label_result.Text = "";
        }
    }
}
