using System;

namespace Alarm501_GUI
{
    partial class Alarm501
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
            this.uxEditAlarm = new System.Windows.Forms.Button();
            this.uxAddAlarm = new System.Windows.Forms.Button();
            this.uxAlarmList = new System.Windows.Forms.ListBox();
            this.uxSnoozeAlarm = new System.Windows.Forms.Button();
            this.uxStopAlarm = new System.Windows.Forms.Button();
            this.uxStateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxEditAlarm
            // 
            this.uxEditAlarm.Location = new System.Drawing.Point(36, 26);
            this.uxEditAlarm.Name = "uxEditAlarm";
            this.uxEditAlarm.Size = new System.Drawing.Size(108, 57);
            this.uxEditAlarm.TabIndex = 0;
            this.uxEditAlarm.Text = "Edit";
            this.uxEditAlarm.UseVisualStyleBackColor = true;
            this.uxEditAlarm.Click += new System.EventHandler(this.OnEditAlarmClicked);
            // 
            // uxAddAlarm
            // 
            this.uxAddAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddAlarm.Location = new System.Drawing.Point(216, 26);
            this.uxAddAlarm.Name = "uxAddAlarm";
            this.uxAddAlarm.Size = new System.Drawing.Size(105, 57);
            this.uxAddAlarm.TabIndex = 1;
            this.uxAddAlarm.Text = "+";
            this.uxAddAlarm.UseVisualStyleBackColor = true;
            this.uxAddAlarm.Click += new System.EventHandler(this.OnAddAlarmClicked);
            // 
            // uxAlarmList
            // 
            this.uxAlarmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAlarmList.FormattingEnabled = true;
            this.uxAlarmList.ItemHeight = 37;
            this.uxAlarmList.Location = new System.Drawing.Point(36, 134);
            this.uxAlarmList.Name = "uxAlarmList";
            this.uxAlarmList.ScrollAlwaysVisible = true;
            this.uxAlarmList.Size = new System.Drawing.Size(284, 189);
            this.uxAlarmList.TabIndex = 2;
            this.uxAlarmList.Click += new System.EventHandler(this.OnAlarmSelected);
            // 
            // uxSnoozeAlarm
            // 
            this.uxSnoozeAlarm.Location = new System.Drawing.Point(36, 458);
            this.uxSnoozeAlarm.Name = "uxSnoozeAlarm";
            this.uxSnoozeAlarm.Size = new System.Drawing.Size(108, 57);
            this.uxSnoozeAlarm.TabIndex = 3;
            this.uxSnoozeAlarm.Text = "Snooze";
            this.uxSnoozeAlarm.UseVisualStyleBackColor = true;
            this.uxSnoozeAlarm.Click += new System.EventHandler(this.OnSnoozeAlarmClicked);
            // 
            // uxStopAlarm
            // 
            this.uxStopAlarm.Location = new System.Drawing.Point(213, 458);
            this.uxStopAlarm.Name = "uxStopAlarm";
            this.uxStopAlarm.Size = new System.Drawing.Size(108, 57);
            this.uxStopAlarm.TabIndex = 4;
            this.uxStopAlarm.Text = "Stop";
            this.uxStopAlarm.UseVisualStyleBackColor = true;
            this.uxStopAlarm.Click += new System.EventHandler(this.OnStopAlarmClicked);
            // 
            // uxStateLabel
            // 
            this.uxStateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uxStateLabel.AutoSize = true;
            this.uxStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStateLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.uxStateLabel.Location = new System.Drawing.Point(56, 375);
            this.uxStateLabel.MinimumSize = new System.Drawing.Size(250, 50);
            this.uxStateLabel.Name = "uxStateLabel";
            this.uxStateLabel.Size = new System.Drawing.Size(250, 50);
            this.uxStateLabel.TabIndex = 6;
            this.uxStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Alarm501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 552);
            this.Controls.Add(this.uxStateLabel);
            this.Controls.Add(this.uxStopAlarm);
            this.Controls.Add(this.uxSnoozeAlarm);
            this.Controls.Add(this.uxAlarmList);
            this.Controls.Add(this.uxAddAlarm);
            this.Controls.Add(this.uxEditAlarm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Alarm501";
            this.Text = "Alarm501";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFromClosed);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxEditAlarm;
        private System.Windows.Forms.Button uxAddAlarm;
        private System.Windows.Forms.ListBox uxAlarmList;
        private System.Windows.Forms.Button uxSnoozeAlarm;
        private System.Windows.Forms.Button uxStopAlarm;
        private System.Windows.Forms.Label uxStateLabel;
    }
}

