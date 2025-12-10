namespace MRL.Desktop.Pages.DetailPages
{
    partial class MotorcycleDetailForm
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
            comfortLabel = new Label();
            EngineLabel = new Label();
            handlingLabel = new Label();
            reviewDateLabel = new Label();
            powerTextBox = new TextBox();
            ccTextBox = new TextBox();
            yearTextBox = new TextBox();
            userIdLabel = new Label();
            categoryComboBox = new ComboBox();
            motorcycleIdLabel = new Label();
            brandComboBox = new ComboBox();
            cancelButton = new Button();
            saveButton = new Button();
            idValueLabel = new Label();
            idLabel = new Label();
            modelTextBox = new TextBox();
            SuspendLayout();
            // 
            // comfortLabel
            // 
            comfortLabel.AutoSize = true;
            comfortLabel.Location = new Point(12, 199);
            comfortLabel.Name = "comfortLabel";
            comfortLabel.Size = new Size(43, 15);
            comfortLabel.TabIndex = 54;
            comfortLabel.Text = "Power:";
            // 
            // EngineLabel
            // 
            EngineLabel.AutoSize = true;
            EngineLabel.Location = new Point(12, 167);
            EngineLabel.Name = "EngineLabel";
            EngineLabel.Size = new Size(26, 15);
            EngineLabel.TabIndex = 51;
            EngineLabel.Text = "CC:";
            // 
            // handlingLabel
            // 
            handlingLabel.AutoSize = true;
            handlingLabel.Location = new Point(12, 138);
            handlingLabel.Name = "handlingLabel";
            handlingLabel.Size = new Size(29, 15);
            handlingLabel.TabIndex = 50;
            handlingLabel.Text = "Year";
            // 
            // reviewDateLabel
            // 
            reviewDateLabel.AutoSize = true;
            reviewDateLabel.Location = new Point(12, 109);
            reviewDateLabel.Name = "reviewDateLabel";
            reviewDateLabel.Size = new Size(44, 15);
            reviewDateLabel.TabIndex = 49;
            reviewDateLabel.Text = "Model:";
            // 
            // powerTextBox
            // 
            powerTextBox.Location = new Point(91, 193);
            powerTextBox.Name = "powerTextBox";
            powerTextBox.Size = new Size(85, 23);
            powerTextBox.TabIndex = 44;
            // 
            // ccTextBox
            // 
            ccTextBox.Location = new Point(91, 164);
            ccTextBox.Name = "ccTextBox";
            ccTextBox.Size = new Size(85, 23);
            ccTextBox.TabIndex = 43;
            // 
            // yearTextBox
            // 
            yearTextBox.Location = new Point(91, 135);
            yearTextBox.Name = "yearTextBox";
            yearTextBox.Size = new Size(85, 23);
            yearTextBox.TabIndex = 42;
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new Point(12, 77);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new Size(58, 15);
            userIdLabel.TabIndex = 40;
            userIdLabel.Text = "Category:";
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(91, 74);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(228, 23);
            categoryComboBox.TabIndex = 39;
            // 
            // motorcycleIdLabel
            // 
            motorcycleIdLabel.AutoSize = true;
            motorcycleIdLabel.Location = new Point(12, 43);
            motorcycleIdLabel.Name = "motorcycleIdLabel";
            motorcycleIdLabel.Size = new Size(41, 15);
            motorcycleIdLabel.TabIndex = 38;
            motorcycleIdLabel.Text = "Brand:";
            // 
            // brandComboBox
            // 
            brandComboBox.FormattingEnabled = true;
            brandComboBox.Location = new Point(91, 40);
            brandComboBox.Name = "brandComboBox";
            brandComboBox.Size = new Size(228, 23);
            brandComboBox.TabIndex = 37;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(244, 230);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 36;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(163, 230);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 35;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // idValueLabel
            // 
            idValueLabel.AutoSize = true;
            idValueLabel.Location = new Point(91, 12);
            idValueLabel.Name = "idValueLabel";
            idValueLabel.Size = new Size(73, 15);
            idValueLabel.TabIndex = 34;
            idValueLabel.Text = "idValueLabel";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 12);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 15);
            idLabel.TabIndex = 33;
            idLabel.Text = "ID: ";
            // 
            // modelTextBox
            // 
            modelTextBox.Location = new Point(91, 106);
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(228, 23);
            modelTextBox.TabIndex = 55;
            // 
            // MotorcycleDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 282);
            Controls.Add(modelTextBox);
            Controls.Add(comfortLabel);
            Controls.Add(EngineLabel);
            Controls.Add(handlingLabel);
            Controls.Add(reviewDateLabel);
            Controls.Add(powerTextBox);
            Controls.Add(ccTextBox);
            Controls.Add(yearTextBox);
            Controls.Add(userIdLabel);
            Controls.Add(categoryComboBox);
            Controls.Add(motorcycleIdLabel);
            Controls.Add(brandComboBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(idValueLabel);
            Controls.Add(idLabel);
            Name = "MotorcycleDetailForm";
            Text = "MotorcycleDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label comfortLabel;
        private Label EngineLabel;
        private Label handlingLabel;
        private Label reviewDateLabel;
        private TextBox powerTextBox;
        private TextBox ccTextBox;
        private TextBox yearTextBox;
        private Label userIdLabel;
        private ComboBox categoryComboBox;
        private Label motorcycleIdLabel;
        private ComboBox brandComboBox;
        private Button cancelButton;
        private Button saveButton;
        private Label idValueLabel;
        private Label idLabel;
        private TextBox modelTextBox;
    }
}