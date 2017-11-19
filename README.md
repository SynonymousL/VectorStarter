# VectorStarter
SetUpForVectorWorks10J

特定条件下で起動できないため一時的に認証を回避するツールです。
起動には別途、以下のバッチファイル２点が必要になります。各自ご用意下さい。
　close.bat  （特定のネットワークアダプタの接続を切るバッチプログラム）
　open.bat   （特定のネットワークアダプタの接続を行うバッチプログラム）
 
 なおWindows10環境で管理者以外のユーザでログオンしていると、
 ネットワークアダプタの設定変更にUAC関連の画面暗転が生じる場合があります。
 回避策もあるかもしれませんが面倒なのでバッチプログラム側では制御していません。
 
 バッチプログラムは会社のNAS（ファイルサーバ）に入れてあります。
 ※ここでの公開はしません
 

追伸。
 VectorWorks10Jがない環境で同アプリをキックすると多分エラー落ちします。
 面倒なので汎用性は考えていません。あくまでも同社内で同様のネットワークアダプタ名、
 VectorWorks10Jがインストール済みである環境に向けたソフトウェアである旨、ご理解下さい。
 
