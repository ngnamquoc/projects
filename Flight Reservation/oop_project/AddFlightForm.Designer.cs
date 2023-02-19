
namespace oop_project
{
    partial class AddFlightForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFlightDestination = new System.Windows.Forms.Label();
            this.txtFlightDestination = new System.Windows.Forms.TextBox();
            this.lblFlightOrigin = new System.Windows.Forms.Label();
            this.txtFlightOrigin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFlightCapacity = new System.Windows.Forms.Label();
            this.txtFlightCapacity = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFlightDestination
            // 
            this.lblFlightDestination.AutoSize = true;
            this.lblFlightDestination.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightDestination.ForeColor = System.Drawing.Color.White;
            this.lblFlightDestination.Location = new System.Drawing.Point(321, 213);
            this.lblFlightDestination.Name = "lblFlightDestination";
            this.lblFlightDestination.Size = new System.Drawing.Size(102, 19);
            this.lblFlightDestination.TabIndex = 16;
            this.lblFlightDestination.Text = "Flight Destination";
            // 
            // txtFlightDestination
            // 
            this.txtFlightDestination.Location = new System.Drawing.Point(326, 235);
            this.txtFlightDestination.Name = "txtFlightDestination";
            this.txtFlightDestination.Size = new System.Drawing.Size(160, 20);
            this.txtFlightDestination.TabIndex = 15;
            // 
            // lblFlightOrigin
            // 
            this.lblFlightOrigin.AutoSize = true;
            this.lblFlightOrigin.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightOrigin.ForeColor = System.Drawing.Color.White;
            this.lblFlightOrigin.Location = new System.Drawing.Point(321, 153);
            this.lblFlightOrigin.Name = "lblFlightOrigin";
            this.lblFlightOrigin.Size = new System.Drawing.Size(73, 19);
            this.lblFlightOrigin.TabIndex = 14;
            this.lblFlightOrigin.Text = "Flight Origin";
            // 
            // txtFlightOrigin
            // 
            this.txtFlightOrigin.Location = new System.Drawing.Point(326, 175);
            this.txtFlightOrigin.Name = "txtFlightOrigin";
            this.txtFlightOrigin.Size = new System.Drawing.Size(160, 20);
            this.txtFlightOrigin.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(321, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Add Flight";
            // 
            // lblFlightCapacity
            // 
            this.lblFlightCapacity.AutoSize = true;
            this.lblFlightCapacity.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightCapacity.ForeColor = System.Drawing.Color.White;
            this.lblFlightCapacity.Location = new System.Drawing.Point(321, 281);
            this.lblFlightCapacity.Name = "lblFlightCapacity";
            this.lblFlightCapacity.Size = new System.Drawing.Size(88, 19);
            this.lblFlightCapacity.TabIndex = 19;
            this.lblFlightCapacity.Text = "Flight Capacity";
            // 
            // txtFlightCapacity
            // 
            this.txtFlightCapacity.Location = new System.Drawing.Point(326, 303);
            this.txtFlightCapacity.Name = "txtFlightCapacity";
            this.txtFlightCapacity.Size = new System.Drawing.Size(160, 20);
            this.txtFlightCapacity.TabIndex = 18;
            // 
            // AddFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(110)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFlightCapacity);
            this.Controls.Add(this.txtFlightCapacity);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFlightDestination);
            this.Controls.Add(this.txtFlightDestination);
            this.Controls.Add(this.lblFlightOrigin);
            this.Controls.Add(this.txtFlightOrigin);
            this.Controls.Add(this.label1);
            this.Name = "AddFlightForm";
            this.Text = "AddFlightForm";
            this.Load += new System.EventHandler(this.AddFlightForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFlightDestination;
        private System.Windows.Forms.TextBox txtFlightDestination;
        private System.Windows.Forms.Label lblFlightOrigin;
        private System.Windows.Forms.TextBox txtFlightOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFlightCapacity;
        private System.Windows.Forms.TextBox txtFlightCapacity;
    }
}