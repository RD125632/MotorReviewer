namespace MRL.Desktop.Pages.DetailPages
{
    partial class BrandDetailForm
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
            nameTextBox = new TextBox();
            nameLabel = new Label();
            idLabel = new Label();
            idValueLabel = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(76, 34);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(171, 23);
            nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 37);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 15);
            idLabel.TabIndex = 2;
            idLabel.Text = "ID: ";
            // 
            // idValueLabel
            // 
            idValueLabel.AutoSize = true;
            idValueLabel.Location = new Point(76, 9);
            idValueLabel.Name = "idValueLabel";
            idValueLabel.Size = new Size(73, 15);
            idValueLabel.TabIndex = 3;
            idValueLabel.Text = "idValueLabel";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(91, 75);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(172, 75);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // BrandDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 123);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(idValueLabel);
            Controls.Add(idLabel);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Name = "BrandDetailForm";
            Text = "BrandDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Label nameLabel;
        private Label idLabel;
        private Label idValueLabel;
        private Button saveButton;
        private Button cancelButton;
    }
}