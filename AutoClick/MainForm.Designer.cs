namespace AutoClick
{
  partial class MainForm
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
            this.btn_click = new System.Windows.Forms.Button();
            this.btn_move = new System.Windows.Forms.Button();
            this.Logger = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_click
            // 
            this.btn_click.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_click.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.btn_click.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_click.Location = new System.Drawing.Point(140, 20);
            this.btn_click.Name = "btn_click";
            this.btn_click.Size = new System.Drawing.Size(100, 30);
            this.btn_click.TabIndex = 0;
            this.btn_click.Text = "鼠标连点";
            this.btn_click.UseVisualStyleBackColor = false;
            // 
            // btn_move
            // 
            this.btn_move.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_move.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.btn_move.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_move.Location = new System.Drawing.Point(20, 20);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(100, 30);
            this.btn_move.TabIndex = 0;
            this.btn_move.Text = "自动奔跑";
            this.btn_move.UseVisualStyleBackColor = false;
            // 
            // Logger
            // 
            this.Logger.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Logger.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Logger.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.Logger.ForeColor = System.Drawing.SystemColors.Control;
            this.Logger.Location = new System.Drawing.Point(20, 70);
            this.Logger.Name = "Logger";
            this.Logger.Size = new System.Drawing.Size(220, 30);
            this.Logger.TabIndex = 2;
            this.Logger.Text = "使用热键连点鼠标";
            this.Logger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(264, 121);
            this.Controls.Add(this.Logger);
            this.Controls.Add(this.btn_move);
            this.Controls.Add(this.btn_click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "原神解放器";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_click;

        private System.Windows.Forms.Button btn_move;

        private System.Windows.Forms.Label Logger;


        #endregion
  }
}