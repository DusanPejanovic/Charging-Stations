
namespace App
{
    partial class App
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
            this.label1 = new System.Windows.Forms.Label();
            this.chargingPlaceCreate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.loggedUserLabel = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naplatna mesta:";
            // 
            // chargingPlaceCreate
            // 
            this.chargingPlaceCreate.Location = new System.Drawing.Point(62, 90);
            this.chargingPlaceCreate.Name = "chargingPlaceCreate";
            this.chargingPlaceCreate.Size = new System.Drawing.Size(103, 44);
            this.chargingPlaceCreate.TabIndex = 1;
            this.chargingPlaceCreate.Text = "Kreiranje mesta";
            this.chargingPlaceCreate.UseVisualStyleBackColor = true;
            this.chargingPlaceCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.Location = new System.Drawing.Point(62, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Prikaz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(62, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 44);
            this.button3.TabIndex = 3;
            this.button3.Text = "Izmena";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(62, 304);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 44);
            this.button4.TabIndex = 4;
            this.button4.Text = "Brisanje";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Naplatne stanice:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(251, 90);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(103, 44);
            this.button8.TabIndex = 6;
            this.button8.Text = "Kreiranje mesta";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.DarkBlue;
            this.button7.Location = new System.Drawing.Point(251, 162);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 44);
            this.button7.TabIndex = 7;
            this.button7.Text = "Prikaz";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(251, 234);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 44);
            this.button6.TabIndex = 8;
            this.button6.Text = "Izmena";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(251, 304);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 44);
            this.button5.TabIndex = 9;
            this.button5.Text = "Brisanje";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // loggedUserLabel
            // 
            this.loggedUserLabel.AutoSize = true;
            this.loggedUserLabel.Location = new System.Drawing.Point(468, 418);
            this.loggedUserLabel.Name = "loggedUserLabel";
            this.loggedUserLabel.Size = new System.Drawing.Size(98, 13);
            this.loggedUserLabel.TabIndex = 10;
            this.loggedUserLabel.Text = "Ulogovan korisnik: ";
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(683, 410);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(105, 28);
            this.logOutButton.TabIndex = 11;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.loggedUserLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chargingPlaceCreate);
            this.Controls.Add(this.label1);
            this.Name = "App";
            this.Text = "App";
            this.Load += new System.EventHandler(this.App_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chargingPlaceCreate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label loggedUserLabel;
        private System.Windows.Forms.Button logOutButton;
    }
}