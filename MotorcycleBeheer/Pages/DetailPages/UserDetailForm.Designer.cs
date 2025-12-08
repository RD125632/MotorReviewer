namespace MRL.Desktop.Pages.DetailPages
{
    partial class UserDetailForm
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
            cancelButton = new Button();
            saveButton = new Button();
            idValueLabel = new Label();
            idLabel = new Label();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            this.experienceLevelLabel = new Label();
            experienceLevelTextBox = new TextBox();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(172, 97);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(91, 97);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // idValueLabel
            // 
            idValueLabel.AutoSize = true;
            idValueLabel.Location = new Point(76, 13);
            idValueLabel.Name = "idValueLabel";
            idValueLabel.Size = new Size(73, 15);
            idValueLabel.TabIndex = 9;
            idValueLabel.Text = "idValueLabel";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 13);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 15);
            idLabel.TabIndex = 8;
            idLabel.Text = "ID: ";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 41);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 7;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(76, 38);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(171, 23);
            nameTextBox.TabIndex = 6;
            // 
            // experienceLevelLabel
            // 
            this.experienceLevelLabel.AutoSize = true;
            this.experienceLevelLabel.Location = new Point(12, 70);
            this.experienceLevelLabel.Name = "experienceLevelLabel";
            this.experienceLevelLabel.Size = new Size(66, 15);
            this.experienceLevelLabel.TabIndex = 13;
            this.experienceLevelLabel.Text = "Experience:";
            // 
            // experienceLevelTextBox
            // 
            experienceLevelTextBox.Location = new Point(76, 67);
            experienceLevelTextBox.Name = "experienceLevelTextBox";
            experienceLevelTextBox.Size = new Size(171, 23);
            experienceLevelTextBox.TabIndex = 12;
            // 
            // UserDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 149);
            Controls.Add(this.experienceLevelLabel);
            Controls.Add(experienceLevelTextBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(idValueLabel);
            Controls.Add(idLabel);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Name = "UserDetailForm";
            Text = "UserDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private Label idValueLabel;
        private Label idLabel;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label experienceLevelLabel;
        private TextBox experienceLevelTextBox;
    }
}