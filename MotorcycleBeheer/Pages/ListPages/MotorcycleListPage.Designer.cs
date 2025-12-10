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
            dataGridView = new DataGridView();
            contentTableLayoutHeader = new TableLayoutPanel();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contentTableLayoutHeader.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 41);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(794, 556);
            dataGridView.TabIndex = 0;
            // 
            // contentTableLayoutHeader
            // 
            contentTableLayoutHeader.BackColor = SystemColors.ButtonFace;
            contentTableLayoutHeader.ColumnCount = 1;
            contentTableLayoutHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentTableLayoutHeader.Controls.Add(dataGridView, 0, 1);
            contentTableLayoutHeader.Controls.Add(addButton, 0, 0);
            contentTableLayoutHeader.Dock = DockStyle.Fill;
            contentTableLayoutHeader.Location = new Point(0, 0);
            contentTableLayoutHeader.Name = "contentTableLayoutHeader";
            contentTableLayoutHeader.RowCount = 2;
            contentTableLayoutHeader.RowStyles.Add(new RowStyle());
            contentTableLayoutHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentTableLayoutHeader.Size = new Size(800, 600);
            contentTableLayoutHeader.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.BackgroundImage = Properties.Resources.add;
            addButton.BackgroundImageLayout = ImageLayout.Stretch;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Location = new Point(3, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(32, 32);
            addButton.TabIndex = 1;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += AddButton_Click;
            // 
            // MotorcycleListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentTableLayoutHeader);
            Name = "MotorcycleListPage";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contentTableLayoutHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private TableLayoutPanel contentTableLayoutHeader;
        private Button addButton;
    }
}
