using System;

namespace Snake
{
    partial class Snake
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlayArea = new System.Windows.Forms.PictureBox();
            this.lblScoreText = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblHighText = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayArea)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayArea
            // 
            this.PlayArea.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PlayArea.Location = new System.Drawing.Point(25, 34);
            this.PlayArea.Name = "PlayArea";
            this.PlayArea.Size = new System.Drawing.Size(763, 686);
            this.PlayArea.TabIndex = 0;
            this.PlayArea.TabStop = false;
            this.PlayArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayArea_Paint);
            // 
            // lblScoreText
            // 
            this.lblScoreText.AutoSize = true;
            this.lblScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreText.Location = new System.Drawing.Point(847, 34);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(115, 37);
            this.lblScoreText.TabIndex = 1;
            this.lblScoreText.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(968, 34);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 37);
            this.lblScore.TabIndex = 2;
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(63, 70);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(0, 42);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Visible = false;
            // 
            // lblHighText
            // 
            this.lblHighText.AutoSize = true;
            this.lblHighText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighText.Location = new System.Drawing.Point(849, 235);
            this.lblHighText.Name = "lblHighText";
            this.lblHighText.Size = new System.Drawing.Size(212, 37);
            this.lblHighText.TabIndex = 4;
            this.lblHighText.Text = "High Scores:";
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.Location = new System.Drawing.Point(854, 302);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(29, 31);
            this.lblHighScore.TabIndex = 5;
            this.lblHighScore.Text = "0";
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 773);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblHighText);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblScoreText);
            this.Controls.Add(this.PlayArea);
            this.KeyPreview = true;
            this.Name = "Snake";
            this.Text = "Snake - The Game";
            this.Load += new System.EventHandler(this.Snake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PlayArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Snake_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.PictureBox PlayArea;
        private System.Windows.Forms.Label lblScoreText;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblHighText;
        private System.Windows.Forms.Label lblHighScore;
    }
}

