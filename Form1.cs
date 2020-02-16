using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Windows.UI.Notifications;

namespace TimeCountApp
{
    public partial class Form1 : Form
    {
        private DataGridView rapListGridView;
        private DataTable rapListDataTable;
        private Button csvOutputButton;

        private DateTime? startTime;
        private ToastNotification toastNotice;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDisplayTime();
            timeUnitBox.SelectedIndex = 0;
            noticeButton.Enabled = false;
            rapButton.Enabled = false;
        }

        private void startOrStopButton_Click(object sender, EventArgs e)
        {
            if (startOrStopButton.Text.Equals("開始"))
            {
                startOrStopButton.Text = "停止";
                timeCount.Enabled = true;
                rapButton.Enabled = true;
            }
            else
            {
                startOrStopButton.Text = "開始";
                timeCount.Enabled = false;
                rapButton.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetDisplayTime();
            if (timeCount.Enabled)
            {
                timeCount.Text = (TimeSpan.Parse(timeCount.Text) + TimeSpan.FromMilliseconds(1000)).ToString();
            }
            if (noticeButton.Text.Equals("通知しない") && startTime != null)
            {
                int? diffTime = null;
                switch (timeUnitBox.SelectedIndex)
                {
                    case 0:
                        diffTime = ((TimeSpan)(DateTime.Now - startTime)).Seconds;
                        break;
                    case 1:
                        diffTime = ((TimeSpan)(DateTime.Now - startTime)).Minutes;
                        break;
                    case 2:
                        diffTime = ((TimeSpan)(DateTime.Now - startTime)).Hours;
                        break;
                }

                if (!String.IsNullOrWhiteSpace(noticeTime.Text) && diffTime.ToString().Equals(noticeTime.Text))
                {

                    var type = ToastTemplateType.ToastText02;
                    var content = ToastNotificationManager.GetTemplateContent(type);
                    var texts = content.GetElementsByTagName("text");
                    texts[0].AppendChild(content.CreateTextNode("TimeCountApp"));
                    texts[1].AppendChild(content.CreateTextNode(noticeTime.Text + timeUnitBox.Text + "です。"));
                    var notifier = ToastNotificationManager.CreateToastNotifier("TimeCountApp");
                    if (toastNotice != null)
                    {
                        notifier.Hide(toastNotice);
                    }
                    toastNotice = new ToastNotification(content);
                    notifier.Show(toastNotice);
                    startTime = DateTime.Now;
                }
            }
        }

        private void SetDisplayTime()
        {
            timeNow.Text = DateTime.Now.ToString("HH時mm分ss秒");
        }

        private void rapButton_Click(object sender, EventArgs e)
        {
            if (!isCreateObjcet(rapListGridView))
            {
                changeFormSize(588, 315);
                rapListGridView = new DataGridView
                {
                    Location = new Point(300, 60),
                    Size     = new Size(240, 183),
                    Font = new Font("Yu Gothic UI", 9F)
                };
                rapListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Controls.Add(rapListGridView);
                csvOutputButton = new Button
                {
                    Location = new Point(300, 37),
                    Text = "csv出力",
                    Font = new Font("Yu Gothic UI", 9F)
                };
                csvOutputButton.Click += new EventHandler(csvOutputButton_Click);
                Controls.Add(csvOutputButton);
                rapListDataTable = new DataTable("Table");
                rapListDataTable.Columns.Add("ラップ");
                rapListDataTable.Columns.Add("計測時間");
                rapListDataTable.Columns.Add("メモ");
      
            }

            DataRow row = rapListDataTable.NewRow();   
            if(rapListDataTable.Rows.Count == 0)
            {
                row["ラップ"] = timeCount.Text;
            }
            else
            {
                row["ラップ"] = (TimeSpan.Parse(timeCount.Text) - TimeSpan.Parse((string)rapListDataTable.Rows[rapListDataTable.Rows.Count - 1]["計測時間"])).ToString();                
            }
            row["計測時間"] = timeCount.Text;
            rapListDataTable.Rows.Add(row);
            rapListGridView.DataSource = rapListDataTable;

        }

        private void csvOutputButton_Click(object sender, EventArgs e)
        {
            selectSaveFile("csv");
        }

        private Boolean isCreateObjcet(Object item)
        {
            return item != null;
        }

        private void noticeButton_Click(object sender, EventArgs e)
        {
            if (noticeButton.Text.Equals("通知する"))
            {
                noticeButton.Text = "通知しない";
                startTime = DateTime.Now;
                noticeTime.Enabled = false;
                timeUnitBox.Enabled = false;
            }
            else
            {
                noticeButton.Text = "通知する";
                startTime = null;
                noticeTime.Enabled = true;
                timeUnitBox.Enabled = true;
            }

        }

        private void timeUnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            noticeTime.Items.Clear();
            switch (timeUnitBox.SelectedIndex)
            {
                case 0:
                case 1:
                    noticeTime.Items.AddRange(createTimeList(60));
                    break;
                case 2:
                    noticeTime.Items.AddRange(createTimeList(24));
                    break;
            }
        }

        private void noticeTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!('0' <= e.KeyChar && e.KeyChar <= '9') && e.KeyChar != '\b') e.Handled = true;
        }

        private void noticeTime_KeyUp(object sender, KeyEventArgs e)
        {
            changeEnabledNoticeButton();
        }

        private string[] createTimeList(int timeNumber)
        {
            string[] items = new string[timeNumber];
            for(var i=1; i<=timeNumber; i++)
            {
                items[i-1] = i.ToString();
            }
            return items;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            timeCount.Text = "00:00:00";
            startOrStopButton.Text = "開始";
            timeCount.Enabled = false;
            rapButton.Enabled = false;
            Controls.Remove(rapListGridView);
            Controls.Remove(csvOutputButton);
            rapListGridView = null;
            rapListDataTable = null;
            csvOutputButton = null;
            changeFormSize(332, 269);
        }

        private void noticeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeEnabledNoticeButton();
        }

        private void changeEnabledNoticeButton()
        {

            if (String.IsNullOrWhiteSpace(noticeTime.Text.Trim('0')) && noticeButton.Text.Equals("通知する"))
            {
                noticeButton.Enabled = false;
            }
            else
            {
                noticeButton.Enabled = true;
            }
        }

        private void changeFormSize(int width, int height)
        {
            ClientSize = new Size(width, height);
        }

        private void selectSaveFile(string extension)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "新しいファイル." + extension;
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "CSVファイル|*.csv";
            //[ファイルの種類]ではじめに選択されるものを指定する
            sfd.FilterIndex = 0;
            //タイトルを設定する
            sfd.Title = "保存先のフォルダを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = false;
           
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                outputDgvCsvFile(sfd.FileName, rapListGridView);
                startProcess(sfd.FileName);
               
            }
        }

        private void outputDgvCsvFile(string fileName, DataGridView dataGridView)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.GetEncoding("shift_jis")))
            {

                int rowCount = dataGridView.Rows.Count;

                // ユーザによる行追加が許可されている場合は、最後の新規入力用の
                // 1行分を差し引く
                if (dataGridView.AllowUserToAddRows == true)
                {
                    rowCount = rowCount - 1;
                }

                List<String> headerList = new List<String>();
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    headerList.Add(dataGridView.Columns[j].HeaderText);
                }

                writer.WriteLine(String.Join(",", headerList));
                // 行
                for (int i = 0; i < rowCount; i++)
                {
                    // リストの初期化
                    List<String> strList = new List<String>();

                    // 列
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        strList.Add(dataGridView[j, i].Value.ToString());
                    }
                    String[] strArray = strList.ToArray(); // 配列へ変換

                    // CSV 形式に変換
                    String strCsvData = String.Join(",", strArray);

                    writer.WriteLine(strCsvData);
                }
            }
        }

        private void startProcess(string filePath)
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = filePath;
            process.Start();
        }
    }
}
