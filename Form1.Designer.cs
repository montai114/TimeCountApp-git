namespace TimeCountApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startOrStopButton = new System.Windows.Forms.Button();
            this.timeNow = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeCount = new System.Windows.Forms.Label();
            this.rapButton = new System.Windows.Forms.Button();
            this.noticeButton = new System.Windows.Forms.Button();
            this.timeUnitBox = new System.Windows.Forms.ComboBox();
            this.noticeTime = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startOrStopButton
            // 
            this.startOrStopButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.startOrStopButton.Location = new System.Drawing.Point(138, 170);
            this.startOrStopButton.Name = "startOrStopButton";
            this.startOrStopButton.Size = new System.Drawing.Size(45, 23);
            this.startOrStopButton.TabIndex = 6;
            this.startOrStopButton.Text = "開始";
            this.startOrStopButton.UseVisualStyleBackColor = true;
            this.startOrStopButton.Click += new System.EventHandler(this.startOrStopButton_Click);
            // 
            // timeNow
            // 
            this.timeNow.AutoSize = true;
            this.timeNow.Font = new System.Drawing.Font("メイリオ", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeNow.Location = new System.Drawing.Point(80, 33);
            this.timeNow.Name = "timeNow";
            this.timeNow.Size = new System.Drawing.Size(88, 34);
            this.timeNow.TabIndex = 1;
            this.timeNow.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeCount
            // 
            this.timeCount.AutoSize = true;
            this.timeCount.Enabled = false;
            this.timeCount.Font = new System.Drawing.Font("メイリオ", 20F, System.Drawing.FontStyle.Bold);
            this.timeCount.Location = new System.Drawing.Point(91, 95);
            this.timeCount.Name = "timeCount";
            this.timeCount.Size = new System.Drawing.Size(148, 41);
            this.timeCount.TabIndex = 3;
            this.timeCount.Text = "00:00:00";
            // 
            // rapButton
            // 
            this.rapButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.rapButton.Location = new System.Drawing.Point(189, 170);
            this.rapButton.Name = "rapButton";
            this.rapButton.Size = new System.Drawing.Size(45, 23);
            this.rapButton.TabIndex = 7;
            this.rapButton.Text = "ラップ";
            this.rapButton.UseVisualStyleBackColor = true;
            this.rapButton.Click += new System.EventHandler(this.rapButton_Click);
            // 
            // noticeButton
            // 
            this.noticeButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.noticeButton.Location = new System.Drawing.Point(54, 219);
            this.noticeButton.Name = "noticeButton";
            this.noticeButton.Size = new System.Drawing.Size(78, 23);
            this.noticeButton.TabIndex = 8;
            this.noticeButton.Text = "通知する";
            this.noticeButton.UseVisualStyleBackColor = true;
            this.noticeButton.Click += new System.EventHandler(this.noticeButton_Click);
            // 
            // timeUnitBox
            // 
            this.timeUnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeUnitBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeUnitBox.FormattingEnabled = true;
            this.timeUnitBox.Items.AddRange(new object[] {
            "秒後",
            "分後",
            "時後"});
            this.timeUnitBox.Location = new System.Drawing.Point(197, 220);
            this.timeUnitBox.Name = "timeUnitBox";
            this.timeUnitBox.Size = new System.Drawing.Size(56, 23);
            this.timeUnitBox.TabIndex = 10;
            this.timeUnitBox.SelectedIndexChanged += new System.EventHandler(this.timeUnitBox_SelectedIndexChanged);
            // 
            // noticeTime
            // 
            this.noticeTime.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.noticeTime.FormattingEnabled = true;
            this.noticeTime.Location = new System.Drawing.Point(138, 219);
            this.noticeTime.Name = "noticeTime";
            this.noticeTime.Size = new System.Drawing.Size(53, 23);
            this.noticeTime.TabIndex = 9;
            this.noticeTime.SelectedIndexChanged += new System.EventHandler(this.noticeTime_SelectedIndexChanged);
            this.noticeTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noticeTime_KeyPress);
            this.noticeTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.noticeTime_KeyUp);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clearButton.Location = new System.Drawing.Point(76, 170);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 269);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.noticeTime);
            this.Controls.Add(this.timeUnitBox);
            this.Controls.Add(this.noticeButton);
            this.Controls.Add(this.rapButton);
            this.Controls.Add(this.timeCount);
            this.Controls.Add(this.timeNow);
            this.Controls.Add(this.startOrStopButton);
            this.Name = "Form1";
            this.Text = "時間計測アプリ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startOrStopButton;
        private System.Windows.Forms.Label timeNow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeCount;
        private System.Windows.Forms.Button rapButton;
        private System.Windows.Forms.Button noticeButton;
        private System.Windows.Forms.ComboBox timeUnitBox;
        private System.Windows.Forms.ComboBox noticeTime;
        private System.Windows.Forms.Button clearButton;
    }
}

