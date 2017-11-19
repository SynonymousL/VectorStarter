using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace WakeUpVectorWorks10J
{
    /// <summary>
    /// 共通ユーティリティクラス
    /// 　外部プログラムの検索、実行などを行うメソッド
    /// </summary>
    public class CommonUtil : Form1
    {
        // ネットワークアダプタ接続状況 "Up" (接続中)
        private static String ADAPTER_STATUS_UP = "Up";
        // ネットワークアダプタ接続状況 "Down" (切断中)
        private static String ADAPTER_STATUS_DOWN = "Down";
        
        /// <summary>
        /// (unused) インストール済みプログラム名の一覧を返すメソッド
        /// 　※毎回起動時に確認に行くのは負荷になるため使用を中止
        /// 　（業務端末から取得されるプログラム名一覧は恐らく少ないが、冗長なため）
        /// 　　VectorWorks10Jがインストールされていない場合、ネットワークのON/OFFのみ行う。
        /// </summary>
        /// <returns>string[] ret インストール済みプログラム名の一覧の配列</returns>
        public static string[] GetUninstallList()
        {
            List<string> ret = new List<string>();

            string uninstall_path = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            Microsoft.Win32.RegistryKey uninstall = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(uninstall_path, false);
            if (uninstall != null)
            {
                foreach (string subKey in uninstall.GetSubKeyNames())
                {
                    string appName = null;
                    Microsoft.Win32.RegistryKey appkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(uninstall_path + "\\" + subKey, false);

                    if (appkey.GetValue("DisplayName") != null)
                        appName = appkey.GetValue("DisplayName").ToString();
                    else
                        appName = subKey;

                    ret.Add(appName);
                }
            }
            return ret.ToArray();
        }

        /// <summary>
        /// (unused) ネットワークアダプタの一覧を取得し、有効な接続を全て切断するメソッド
        /// 　切断したアダプタ名は再接続時に別途必要になるため、戻り値としてリストに入れて返す。
        /// 　　※アダプタの切断と接続はAPIが必要で面倒なので用途を限定させた仕様に変更、本メソッドは未使用とする
        /// 　　※nullが帰るので使わないこと。
        /// </summary>
        public static List<string> NetworkAdapterCloser()
        {
            // 戻り値のリスト
            List<string> ret = new List<string>();

            // ネットワークアダプタ一覧を取得
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            
            // それぞれ名称(Name)と接続状況()を取得し、接続状況が"Up"の場合のみ名称を戻り値のリストに格納する
            foreach (NetworkInterface adapter in nics)
            {
                // 接続中のアダプタのみ切断し、アダプタ名をリストに格納
                if (adapter.OperationalStatus.ToString() == ADAPTER_STATUS_UP)
                {
                    // 可能ならここで切断APIを呼ぶクラス、メソッドをコール
                    ret.Add(adapter.Name);
                }
            }
            return null;
        }
    }
}
