namespace MotorcycleBeheer
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
            contentPanel = new Panel();
            sideMenuPanel = new Panel();
            categoryMenuButton = new Button();
            userMenuButton = new Button();
            reviewsMenuButton = new Button();
            motorcyclesMenuButton = new Button();
            brandsMenuButton = new Button();
            contentTableLayoutPanel = new TableLayoutPanel();
            sideMenuPanel.SuspendLayout();
            contentTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // contentPanel
            // 
            contentPanel.Location = new Point(218, 3);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1379, 844);
            contentPanel.TabIndex = 1;
            // 
            // sideMenuPanel
            // 
            sideMenuPanel.Controls.Add(categoryMenuButton);
            sideMenuPanel.Controls.Add(userMenuButton);
            sideMenuPanel.Controls.Add(reviewsMenuButton);
            sideMenuPanel.Controls.Add(motorcyclesMenuButton);
            sideMenuPanel.Controls.Add(brandsMenuButton);
            sideMenuPanel.Location = new Point(3, 3);
            sideMenuPanel.Name = "sideMenuPanel";
            sideMenuPanel.Size = new Size(209, 844);
            sideMenuPanel.TabIndex = 1;
            // 
            // categoryMenuButton
            // 
            categoryMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            categoryMenuButton.FlatAppearance.BorderSize = 0;
            categoryMenuButton.FlatStyle = FlatStyle.Flat;
            categoryMenuButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            categoryMenuButton.ForeColor = SystemColors.ButtonHighlight;
            categoryMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            categoryMenuButton.Location = new Point(0, 3);
            categoryMenuButton.Name = "categoryMenuButton";
            categoryMenuButton.Size = new Size(209, 40);
            categoryMenuButton.TabIndex = 4;
            categoryMenuButton.Text = "Category";
            categoryMenuButton.TextAlign = ContentAlignment.MiddleLeft;
            categoryMenuButton.UseVisualStyleBackColor = false;
            // 
            // userMenuButton
            // 
            userMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            userMenuButton.FlatAppearance.BorderSize = 0;
            userMenuButton.FlatStyle = FlatStyle.Flat;
            userMenuButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userMenuButton.ForeColor = SystemColors.ButtonHighlight;
            userMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            userMenuButton.Location = new Point(0, 187);
            userMenuButton.Name = "userMenuButton";
            userMenuButton.Size = new Size(209, 40);
            userMenuButton.TabIndex = 3;
            userMenuButton.Text = "User";
            userMenuButton.TextAlign = ContentAlignment.MiddleLeft;
            userMenuButton.UseVisualStyleBackColor = false;
            // 
            // reviewsMenuButton
            // 
            reviewsMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            reviewsMenuButton.FlatAppearance.BorderSize = 0;
            reviewsMenuButton.FlatStyle = FlatStyle.Flat;
            reviewsMenuButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reviewsMenuButton.ForeColor = SystemColors.ButtonHighlight;
            reviewsMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            reviewsMenuButton.Location = new Point(0, 141);
            reviewsMenuButton.Name = "reviewsMenuButton";
            reviewsMenuButton.Size = new Size(209, 40);
            reviewsMenuButton.TabIndex = 2;
            reviewsMenuButton.Text = "Reviews";
            reviewsMenuButton.TextAlign = ContentAlignment.MiddleLeft;
            reviewsMenuButton.UseVisualStyleBackColor = false;
            // 
            // motorcyclesMenuButton
            // 
            motorcyclesMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            motorcyclesMenuButton.FlatAppearance.BorderSize = 0;
            motorcyclesMenuButton.FlatStyle = FlatStyle.Flat;
            motorcyclesMenuButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            motorcyclesMenuButton.ForeColor = SystemColors.ButtonHighlight;
            motorcyclesMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            motorcyclesMenuButton.Location = new Point(0, 95);
            motorcyclesMenuButton.Name = "motorcyclesMenuButton";
            motorcyclesMenuButton.Size = new Size(209, 40);
            motorcyclesMenuButton.TabIndex = 1;
            motorcyclesMenuButton.Text = "Motorcycles";
            motorcyclesMenuButton.TextAlign = ContentAlignment.MiddleLeft;
            motorcyclesMenuButton.UseVisualStyleBackColor = false;
            // 
            // brandsMenuButton
            // 
            brandsMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            brandsMenuButton.FlatAppearance.BorderSize = 0;
            brandsMenuButton.FlatStyle = FlatStyle.Flat;
            brandsMenuButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            brandsMenuButton.ForeColor = SystemColors.ButtonHighlight;
            brandsMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            brandsMenuButton.Location = new Point(0, 49);
            brandsMenuButton.Name = "brandsMenuButton";
            brandsMenuButton.Size = new Size(209, 40);
            brandsMenuButton.TabIndex = 0;
            brandsMenuButton.Text = "Brands";
            brandsMenuButton.TextAlign = ContentAlignment.MiddleLeft;
            brandsMenuButton.UseVisualStyleBackColor = false;
            // 
            // contentTableLayoutPanel
            // 
            contentTableLayoutPanel.ColumnCount = 2;
            contentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 215F));
            contentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentTableLayoutPanel.Controls.Add(sideMenuPanel, 0, 0);
            contentTableLayoutPanel.Controls.Add(contentPanel, 1, 0);
            contentTableLayoutPanel.Dock = DockStyle.Fill;
            contentTableLayoutPanel.Location = new Point(0, 0);
            contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            contentTableLayoutPanel.RowCount = 1;
            contentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentTableLayoutPanel.Size = new Size(1600, 900);
            contentTableLayoutPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1600, 900);
            Controls.Add(contentTableLayoutPanel);
            Name = "MainForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Motorcycle Review List";
            sideMenuPanel.ResumeLayout(false);
            contentTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel contentPanel;
        private Panel sideMenuPanel;
        private Button categoryMenuButton;
        private Button userMenuButton;
        private Button reviewsMenuButton;
        private Button motorcyclesMenuButton;
        private Button brandsMenuButton;
        private TableLayoutPanel contentTableLayoutPanel;
    }
}