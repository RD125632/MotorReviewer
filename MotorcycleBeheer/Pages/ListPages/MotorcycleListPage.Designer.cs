namespace MRL.Desktop.Pages
{
    partial class MotorcycleListPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            motorcycleListDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)motorcycleListDataGridView).BeginInit();
            SuspendLayout();
            // 
            // motorcycleListDataGridView
            // 
            motorcycleListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            motorcycleListDataGridView.Dock = DockStyle.Fill;
            motorcycleListDataGridView.Location = new Point(0, 0);
            motorcycleListDataGridView.Name = "motorcycleListDataGridView";
            motorcycleListDataGridView.Size = new Size(150, 150);
            motorcycleListDataGridView.TabIndex = 0;
            // 
            // MotorcycleListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(motorcycleListDataGridView);
            Name = "MotorcycleListPage";
            ((System.ComponentModel.ISupportInitialize)motorcycleListDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView motorcycleListDataGridView;
    }
}
