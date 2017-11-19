using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace WakeUpVectorWorks10J
{
    public partial class Form1 : Form
    {
        private String BATCH_NAME_CLOSE = "close";
        private String BATCH_NAME_OPEN = "open";
        private String VECTOR_PATH = "C:\\Program Files\\VectorWorks10J\\VectorWorks.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ネットワーク切断ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CallBatch(BATCH_NAME_CLOSE);
        }

        /// <summary>
        /// VectorWorks10J起動ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            CallVectorWorks(VECTOR_PATH);
        }

        /// <summary>
        /// ネットワーク接続ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CallBatch(BATCH_NAME_OPEN);
        }

        /// <summary>
        /// バッチファイル起動用メソッド（開閉兼用）
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private int CallBatch(string arg)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = string.Format(@"/c {0}.bat", arg);

            Process process = Process.Start(startInfo);
            process.WaitForExit();
            return process.ExitCode;
        }

        /// <summary>
        /// VectorWorks起動
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private void CallVectorWorks(string arg)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = arg;
            Process process = Process.Start(startInfo);
            process.WaitForInputIdle();
        }

        /// <summary>
        /// 本アプリを終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
