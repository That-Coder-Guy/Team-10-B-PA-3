namespace Alarm501_GUI
{
    partial class AddEditAlarm
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
            this.uxTimePicker = new System.Windows.Forms.DateTimePicker();
            this.UXSetAlarmBtn = new System.Windows.Forms.Button();
            this.UxCancelEditAlarmBtn = new System.Windows.Forms.Button();
            this.uxOnCheckBox = new System.Windows.Forms.CheckBox();
            this.uxSundayCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uxMondayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxTuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxWednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxThursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxFridayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxSaturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.uxSoundComboBox = new System.Windows.Forms.ComboBox();
            this.uxSnoozePeriodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozePeriodNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uxTimePicker
            // 
            this.uxTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxTimePicker.Location = new System.Drawing.Point(42, 12);
            this.uxTimePicker.Name = "uxTimePicker";
            this.uxTimePicker.Size = new System.Drawing.Size(273, 26);
            this.uxTimePicker.TabIndex = 0;
            this.uxTimePicker.Value = new System.DateTime(2021, 1, 29, 22, 30, 0, 0);
            // 
            // UXSetAlarmBtn
            // 
            this.UXSetAlarmBtn.Location = new System.Drawing.Point(305, 217);
            this.UXSetAlarmBtn.Name = "UXSetAlarmBtn";
            this.UXSetAlarmBtn.Size = new System.Drawing.Size(86, 46);
            this.UXSetAlarmBtn.TabIndex = 1;
            this.UXSetAlarmBtn.Text = "Set";
            this.UXSetAlarmBtn.UseVisualStyleBackColor = true;
            this.UXSetAlarmBtn.Click += new System.EventHandler(this.SetPressed);
            // 
            // UxCancelEditAlarmBtn
            // 
            this.UxCancelEditAlarmBtn.Location = new System.Drawing.Point(42, 217);
            this.UxCancelEditAlarmBtn.Name = "UxCancelEditAlarmBtn";
            this.UxCancelEditAlarmBtn.Size = new System.Drawing.Size(86, 46);
            this.UxCancelEditAlarmBtn.TabIndex = 2;
            this.UxCancelEditAlarmBtn.Text = "Cancel";
            this.UxCancelEditAlarmBtn.UseVisualStyleBackColor = true;
            this.UxCancelEditAlarmBtn.Click += new System.EventHandler(this.CancelPressed);
            // 
            // uxOnCheckBox
            // 
            this.uxOnCheckBox.AutoSize = true;
            this.uxOnCheckBox.Location = new System.Drawing.Point(335, 16);
            this.uxOnCheckBox.Name = "uxOnCheckBox";
            this.uxOnCheckBox.Size = new System.Drawing.Size(56, 24);
            this.uxOnCheckBox.TabIndex = 3;
            this.uxOnCheckBox.Text = "On";
            this.uxOnCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxSundayCheckBox
            // 
            this.uxSundayCheckBox.AutoSize = true;
            this.uxSundayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxSundayCheckBox.Location = new System.Drawing.Point(3, 3);
            this.uxSundayCheckBox.Name = "uxSundayCheckBox";
            this.uxSundayCheckBox.Size = new System.Drawing.Size(24, 45);
            this.uxSundayCheckBox.TabIndex = 5;
            this.uxSundayCheckBox.Text = "S";
            this.uxSundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.uxSundayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxMondayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxTuesdayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxWednesdayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxThursdayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxFridayCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.uxSaturdayCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(123, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 58);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // uxMondayCheckBox
            // 
            this.uxMondayCheckBox.AutoSize = true;
            this.uxMondayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxMondayCheckBox.Location = new System.Drawing.Point(33, 3);
            this.uxMondayCheckBox.Name = "uxMondayCheckBox";
            this.uxMondayCheckBox.Size = new System.Drawing.Size(26, 45);
            this.uxMondayCheckBox.TabIndex = 6;
            this.uxMondayCheckBox.Text = "M";
            this.uxMondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxTuesdayCheckBox
            // 
            this.uxTuesdayCheckBox.AutoSize = true;
            this.uxTuesdayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxTuesdayCheckBox.Location = new System.Drawing.Point(65, 3);
            this.uxTuesdayCheckBox.Name = "uxTuesdayCheckBox";
            this.uxTuesdayCheckBox.Size = new System.Drawing.Size(22, 45);
            this.uxTuesdayCheckBox.TabIndex = 7;
            this.uxTuesdayCheckBox.Text = "T";
            this.uxTuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxWednesdayCheckBox
            // 
            this.uxWednesdayCheckBox.AutoSize = true;
            this.uxWednesdayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxWednesdayCheckBox.Location = new System.Drawing.Point(93, 3);
            this.uxWednesdayCheckBox.Name = "uxWednesdayCheckBox";
            this.uxWednesdayCheckBox.Size = new System.Drawing.Size(28, 45);
            this.uxWednesdayCheckBox.TabIndex = 8;
            this.uxWednesdayCheckBox.Text = "W";
            this.uxWednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxThursdayCheckBox
            // 
            this.uxThursdayCheckBox.AutoSize = true;
            this.uxThursdayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxThursdayCheckBox.Location = new System.Drawing.Point(127, 3);
            this.uxThursdayCheckBox.Name = "uxThursdayCheckBox";
            this.uxThursdayCheckBox.Size = new System.Drawing.Size(22, 45);
            this.uxThursdayCheckBox.TabIndex = 9;
            this.uxThursdayCheckBox.Text = "T";
            this.uxThursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxFridayCheckBox
            // 
            this.uxFridayCheckBox.AutoSize = true;
            this.uxFridayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxFridayCheckBox.Location = new System.Drawing.Point(155, 3);
            this.uxFridayCheckBox.Name = "uxFridayCheckBox";
            this.uxFridayCheckBox.Size = new System.Drawing.Size(23, 45);
            this.uxFridayCheckBox.TabIndex = 10;
            this.uxFridayCheckBox.Text = "F";
            this.uxFridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxSaturdayCheckBox
            // 
            this.uxSaturdayCheckBox.AutoSize = true;
            this.uxSaturdayCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uxSaturdayCheckBox.Location = new System.Drawing.Point(184, 3);
            this.uxSaturdayCheckBox.Name = "uxSaturdayCheckBox";
            this.uxSaturdayCheckBox.Size = new System.Drawing.Size(24, 45);
            this.uxSaturdayCheckBox.TabIndex = 11;
            this.uxSaturdayCheckBox.Text = "S";
            this.uxSaturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxSoundComboBox
            // 
            this.uxSoundComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSoundComboBox.FormattingEnabled = true;
            this.uxSoundComboBox.Location = new System.Drawing.Point(160, 114);
            this.uxSoundComboBox.Name = "uxSoundComboBox";
            this.uxSoundComboBox.Size = new System.Drawing.Size(120, 28);
            this.uxSoundComboBox.TabIndex = 7;
            // 
            // uxSnoozePeriodNumericUpDown
            // 
            this.uxSnoozePeriodNumericUpDown.Location = new System.Drawing.Point(160, 167);
            this.uxSnoozePeriodNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxSnoozePeriodNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxSnoozePeriodNumericUpDown.Name = "uxSnoozePeriodNumericUpDown";
            this.uxSnoozePeriodNumericUpDown.Size = new System.Drawing.Size(60, 26);
            this.uxSnoozePeriodNumericUpDown.TabIndex = 8;
            this.uxSnoozePeriodNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Snooze Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alarm Sound";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Schedule";
            // 
            // AddEditAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 283);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxSnoozePeriodNumericUpDown);
            this.Controls.Add(this.uxSoundComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.uxOnCheckBox);
            this.Controls.Add(this.UxCancelEditAlarmBtn);
            this.Controls.Add(this.UXSetAlarmBtn);
            this.Controls.Add(this.uxTimePicker);
            this.Name = "AddEditAlarm";
            this.Text = "Add/Edit Alarm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozePeriodNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uxTimePicker;
        private System.Windows.Forms.Button UXSetAlarmBtn;
        private System.Windows.Forms.Button UxCancelEditAlarmBtn;
        private System.Windows.Forms.CheckBox uxOnCheckBox;
        private System.Windows.Forms.CheckBox uxSundayCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox uxMondayCheckBox;
        private System.Windows.Forms.CheckBox uxTuesdayCheckBox;
        private System.Windows.Forms.CheckBox uxWednesdayCheckBox;
        private System.Windows.Forms.CheckBox uxThursdayCheckBox;
        private System.Windows.Forms.CheckBox uxFridayCheckBox;
        private System.Windows.Forms.CheckBox uxSaturdayCheckBox;
        private System.Windows.Forms.ComboBox uxSoundComboBox;
        private System.Windows.Forms.NumericUpDown uxSnoozePeriodNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}