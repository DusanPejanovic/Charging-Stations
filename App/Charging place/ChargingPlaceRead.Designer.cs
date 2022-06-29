
namespace Charging_place
{
    partial class ChargingPlaceRead
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
            this.chargingPlacesTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chargingPlacesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // chargingPlacesTable
            // 
            this.chargingPlacesTable.AllowUserToOrderColumns = true;
            this.chargingPlacesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chargingPlacesTable.Location = new System.Drawing.Point(40, 35);
            this.chargingPlacesTable.Name = "chargingPlacesTable";
            this.chargingPlacesTable.Size = new System.Drawing.Size(683, 409);
            this.chargingPlacesTable.TabIndex = 0;
            // 
            // ChargingPlaceRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 559);
            this.Controls.Add(this.chargingPlacesTable);
            this.Name = "ChargingPlaceRead";
            this.Text = "ChargingPlaceRead";
            this.Load += new System.EventHandler(this.ChargingPlaceRead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chargingPlacesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView chargingPlacesTable;
    }
}