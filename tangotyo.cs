using System;
using GUIConfig;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms.Design;

namespace TANGO
{
	//720行目あたりで使用
	public class GroupBoxEX : GroupBox
	{
		public int Count = 0;
		public Color col = Color.Black;

		public Color FrameColor
		{
			set{	col = value;	}
			get{	return col;		}
		}

		public GroupBoxEX(int count)
		{
			Count = count;
			Console.WriteLine("Hello GropuBoxEX");

			base.Size = new Size(200, 100);
			base.BackColor = Color.White;

			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
		}
		protected override void OnClick(EventArgs e)
		{
			Console.WriteLine("Click!{0}", Count);
		}

		//ここでプロパティで設定した色の枠線を付ける
		//豆知識！Graphicsクラスの関数...Drawは線の描画で、Fillは面の塗りつぶし...らしいです
		protected override void OnPaint(PaintEventArgs e)
		{
			//描画した文字列の大きさを計測
			Size TextSize = TextRenderer.MeasureText(base.Text, base.Font);

			//描画した矩形の取得
			Rectangle BorderRect = e.ClipRectangle;
			//取得した矩形のY座標を設定
			BorderRect.Y += TextSize.Height / 2;
			//取得した矩形の高さを設定
			BorderRect.Height -= TextSize.Height / 2;
			//GroupBoxEXの場合...
			//GroupBoxEXの輪郭を指定した大きさ、色、スタイルで描画する(難しいね)
			ControlPaint.DrawBorder(e.Graphics, BorderRect, this.col, ButtonBorderStyle.Solid);

			//描画した矩形の取得
			Rectangle TextRect = e.ClipRectangle;
			//取得した矩形のX座標を指定(6とは？)
			TextRect.X += 5;
			//取得した矩形の横幅と高さを設定
			TextRect.Width = TextSize.Width;
			TextRect.Height = TextSize.Height;

			//これはよくわからん(Fillだから塗りつぶすってことはわかる)
			e.Graphics.FillRectangle(new SolidBrush(base.BackColor), TextRect);
			//その名の通り文字列を描画する。描画するテキスト、フォント、ブラシ(?)、矩形で描画する
			e.Graphics.DrawString(base.Text, base.Font, new SolidBrush(base.ForeColor), TextRect);
		}
//		protected virtual PutHiglight()
//		{
//			Console.WriteLine("Hello!");
//		}
	}

	public class GridConf
	{
		public bool ConsoleBool = false;
		public enum LabelEnum
		{
			Four = 4,
			Six = 6,
			Eight = 8,
			Ten = 10,
			Twelve = 12,
			MAX = 12,
		};
		public LabelEnum _LabelCount = LabelEnum.Four;

		[Category("表示")]
		[DefaultValue(LabelEnum.Four)]
		[Description("ラベルの数なんぼにする？")]
		public LabelEnum LabelCount
		{
			get{ return _LabelCount; }
			set{ _LabelCount = value; }
		}
		[Category("表示")]
		[DefaultValue(false)]
		[Description("コンソールを表示する？(True : 表示)")]
		public bool ConsoleDraw
		{
			get{ return ConsoleBool; }
			set{ ConsoleBool = value; }
		}
	}
	public class Dialog : Form
	{
		private Button Apply = new Button();
		private PropertyGrid pg = new PropertyGrid();
		private static GridConf gc = new GridConf();

		public Dialog()
		{
			ClientSize = new Size(500, 500);
			Text = "Config Test";

			pg.SelectedObject = gc;
			pg.Location = new Point(0, 0);
			pg.Size = new Size(500, 450);
			Controls.Add(pg);

			Apply.Text = "保存";
			Apply.Size = new Size(100, 50);
			Apply.Location = new Point(400, 450);
			Apply.Click += onApply;
			Controls.Add(Apply);
		}
		public static void onApply(object sender, EventArgs e)
		{
			ConfigFile.RemoveKey("LabelCount");
			ConfigFile.RemoveKey("ConsoleDraw");
				ConfigFile.Write("LabelCount", gc.LabelCount.ToString());
				ConfigFile.Write("ConsoleDraw", gc.ConsoleDraw);
			ConfigFile.Save();
		}
	}
	public class Program : Form
	{
		public static List<string> console = new List<string>();
		private const int WND_WIDTH  = 1280;
		private const int WND_HEIGHT = 960;
		private const int COL_WIDTH  = 300;
		private const int COL_HEIGHT = 100;
		private const int TEB_WIDTH	 = 300;
		private const int TEB_HEIGHT = 40; 
		private const int LBL_COUNT = 12;
		private const int Space = 150; 
		private int fsCount = 0; //FileStreamCatch
		private int rsCount = 0; //ResetCount
		private int frCount = 0; //FormCatch
		private int rlCount = 0; //ReloadCount
        private int wrCount = 0; //WriteCount
		private int svCount = 0; //SaveAsCount
		private int opCount = 0; //OpenCount
		private int GC;			 //GroupsCount

//		private static int ArrayCount = 4;
		private string path = @"tangotyo.csv";
		private Form consoleWindow 	= new Form();
		private Form configWindow 	= new Form();
		private TextBox DebugConsole = new TextBox();
		//private TextBox Grid		= new TextBox();
		



		private Panel Grid			= new Panel();
		





		//private TextBox[] configTB = new TextBox[LBL_COUNT];
		private TextBox configTB1  = new TextBox();
		private TextBox configTB2  = new TextBox();
		private TextBox configTB3  = new TextBox();
		private TextBox configTB4  = new TextBox();
		private TextBox configTB5  = new TextBox();
		private TextBox configTB6  = new TextBox();
		private TextBox configTB7  = new TextBox();
		private TextBox configTB8  = new TextBox();
		private TextBox configTB9  = new TextBox();
		private TextBox configTB10 = new TextBox();
		private TextBox configTB11 = new TextBox();
		private TextBox configTB12 = new TextBox();
		private TextBox column 		= new TextBox();	//1
		private TextBox greek 		= new TextBox();	//2
		private TextBox japanese 	= new TextBox();	//3
		private TextBox english 	= new TextBox();	//4
		private TextBox tb5			= new TextBox();	//5
		private TextBox tb6			= new TextBox();	//6
		private TextBox tb7			= new TextBox();	//7
		private TextBox tb8			= new TextBox();	//8
		private TextBox tb9			= new TextBox();	//9
		private TextBox tb10		= new TextBox();	//10
		private TextBox tb11		= new TextBox();	//11
		private TextBox tb12		= new TextBox();	//12
		private Label columnL 		= new Label();		//1
		private Label greekL 		= new Label();		//2
		private Label japaneseL 	= new Label();		//3
		private Label englishL 		= new Label();		//4
		private Label Label5		= new Label();		//5
		private Label Label6		= new Label();		//6
		private Label Label7		= new Label();		//7
		private Label Label8		= new Label();		//8
		private Label Label9		= new Label();		//9
		private Label Label10		= new Label();		//10
		private Label Label11		= new Label();		//11
		private Label Label12		= new Label();		//12
		private Label configLabel1 	= new Label();
		private Label configLabel2 	= new Label();
		private Label configLabel3 	= new Label();
		private Label configLabel4 	= new Label();
		private Label configLabel5 	= new Label();
		private Label configLabel6 	= new Label();
		private Label configLabel7 	= new Label();
		private Label configLabel8 	= new Label();
		private Label configLabel9 	= new Label();
		private Label configLabel10 = new Label();
		private Label configLabel11 = new Label();
		private Label configLabel12 = new Label();
		private Label List 			= new Label();
		private Label Line 			= new Label();
		private Button button 		= new Button();
		private Button Reload		= new Button();
		private Button Reset		= new Button();
		private Button Apply 		= new Button();
		private Button SettingSave	= new Button();
		private Button OK 			= new Button();
		




		//private List<Panel> Panel 	= new List<Panel>(4);
		//private Panel[] Panel 		= new Panel[ConfigFile.ReadToInt("LabelCount")];
		




		private ToolStripMenuItem mf 		= new ToolStripMenuItem();
		private ToolStripMenuItem mi_f0 	= new ToolStripMenuItem();
		private ToolStripMenuItem mi_f1 	= new ToolStripMenuItem();
		private ToolStripMenuItem mi_f2 	= new ToolStripMenuItem();
		private ToolStripMenuItem mi3 		= new ToolStripMenuItem();
		private ToolStripMenuItem mc 		= new ToolStripMenuItem();
		private ToolStripMenuItem mc_f0 	= new ToolStripMenuItem();
		private ToolStripMenuItem mc_f1 	= new ToolStripMenuItem();
		private ToolStripSeparator menuLine = new ToolStripSeparator();
		private MenuStrip ms 				= new MenuStrip();

		public Program()
		{
			Console.WriteLine("Program::" + ConfigFile.Read("LabelCount"));
			Console.WriteLine("Program::" + ConfigFile.Read("ConsoleDraw"));
			Console.WriteLine("ReadToInt::"+ ConfigFile.ReadToInt("LabelCount"));

			Text = "単語帳";
			ClientSize = new Size(1280, 960);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			AutoScroll = true;
				
			//=============TEXTBOX=============
			//Font... "Font name", "Font Size"
			//Location..."Width", "Height"
			//Size... "Width", "Height"
			switch(ConfigFile.Read("LabelCount"))
			{
				case "Four":
					//ArrayCount = 4;
					//===========TEXTBOX===========
					column.Location		= new Point(500, 100);
					greek.Location 		= new Point(850, 100);
					japanese.Location 	= new Point(500, 300);
					english.Location 	= new Point(850, 300);
					
					//===========LABEL===========
					columnL.Location 	= new Point(500, 60);
					greekL.Location 	= new Point(850, 60);
					japaneseL.Location 	= new Point(500, 260);
					englishL.Location 	= new Point(850, 260);
					
					Line.Location 		= new Point(450, 0);
					button.Location 	= new Point(900, 350);
					Reload.Location 	= new Point(700, 350);
					Reset.Location 		= new Point(500, 350);
				break;

				case "Six":
					//ArrayCount = 6;
					//===========TEXTBOX===========
					column.Location 	= new Point(500, 100);
					greek.Location 		= new Point(850, 100);
					japanese.Location 	= new Point(500, 100 + (1 * Space));
					english.Location 	= new Point(850, 100 + (1 * Space));
					tb5.Location 		= new Point(500, 100 + (2 * Space));
					tb6.Location 		= new Point(850, 100 + (2 * Space));
					Controls.Add(tb5);
					Controls.Add(tb6);
					
					//===========LABEL===========
					columnL.Location	= new Point(500, 60);
					greekL.Location 	= new Point(850, 60);
					japaneseL.Location 	= new Point(500, 60 + (1 * Space));
					englishL.Location	= new Point(850, 60 + (1 * Space));
					Label5.Location 	= new Point(500, 60 + (2 * Space));
					Label6.Location 	= new Point(850, 60 + (2 * Space));

					//===========BUTTON===========
					button.Location 	= new Point(900, 60 + (3 * Space));
					Reload.Location 	= new Point(700, 60 + (3 * Space));
					Reset.Location 		= new Point(500, 60 + (3 * Space));
					
					Line.Location 		= new Point(450, 0);
					
					Controls.Add(Label5);
					Controls.Add(Label6);
				break;

				case "Eight":
					//ArrayCount = 8;
					//===========TEXTBOX===========
					column.Location 	= new Point(500, 100);
					greek.Location	 	= new Point(850, 100);
					japanese.Location 	= new Point(500, 100 + (1 * Space));
					english.Location	= new Point(850, 100 + (1 * Space));
					tb5.Location 		= new Point(500, 100 + (2 * Space));
					tb6.Location 		= new Point(850, 100 + (2 * Space));
					tb7.Location 		= new Point(500, 100 + (3 * Space));
					tb8.Location 		= new Point(850, 100 + (3 * Space));
					Controls.Add(tb5);
					Controls.Add(tb6);
					Controls.Add(tb7);
					Controls.Add(tb8);
					
					//===========LABEL===========
					columnL.Location 	= new Point(500, 60);
					greekL.Location 	= new Point(850, 60);
					japaneseL.Location 	= new Point(500, 60 + (1 * Space));
					englishL.Location 	= new Point(850, 60 + (1 * Space));
					Label5.Location 	= new Point(500, 60 + (2 * Space));
					Label6.Location 	= new Point(850, 60 + (2 * Space));
					Label7.Location 	= new Point(500, 60 + (3 * Space));
					Label8.Location 	= new Point(850, 60 + (3 * Space));
					Controls.Add(Label5);
					Controls.Add(Label6);
					Controls.Add(Label7);
					Controls.Add(Label8);
					
					Line.Location 		= new Point(450, 0);
					button.Location 	= new Point(900, 60 + (4 * Space));
					Reload.Location 	= new Point(700, 60 + (4 * Space));
					Reset.Location 		= new Point(500, 60 + (4 * Space));
				break;

				case "Ten":
					//ArrayCount = 10;
					//===========TEXTBOX===========
					column.Location 	= new Point(500, 100);
					greek.Location 		= new Point(850, 100);
					japanese.Location 	= new Point(500, 100 + (1 * Space));
					english.Location	= new Point(850, 100 + (1 * Space));
					tb5.Location 		= new Point(500, 100 + (2 * Space));
					tb6.Location 		= new Point(850, 100 + (2 * Space));
					tb7.Location 		= new Point(500, 100 + (3 * Space));
					tb8.Location 		= new Point(850, 100 + (3 * Space));
					tb9.Location 		= new Point(500, 100 + (4 * Space));
					tb10.Location 		= new Point(850, 100 + (4 * Space));
					Controls.Add(tb5);
					Controls.Add(tb6);
					Controls.Add(tb7);
					Controls.Add(tb8);
					Controls.Add(tb9);
					Controls.Add(tb10);
					
					//===========LABEL===========
					columnL.Location 	= new Point(500, 60);
					greekL.Location 	= new Point(850, 60);
					japaneseL.Location 	= new Point(500, 60 + (1 * Space));
					englishL.Location 	= new Point(850, 60 + (1 * Space));
					Label5.Location 	= new Point(500, 60 + (2 * Space));
					Label6.Location 	= new Point(850, 60 + (2 * Space));
					Label7.Location 	= new Point(500, 60 + (3 * Space));
					Label8.Location 	= new Point(850, 60 + (3 * Space));
					Label9.Location 	= new Point(500, 60 + (4 * Space));
					Label10.Location 	= new Point(850, 60 + (4 * Space));
					Controls.Add(Label5);
					Controls.Add(Label6);
					Controls.Add(Label7);
					Controls.Add(Label8);
					Controls.Add(Label9);
					Controls.Add(Label10);
					
					Line.Location 		= new Point(450, 0);
					button.Location 	= new Point(900, 60 + (5 * Space));
					Reload.Location 	= new Point(700, 60 + (5 * Space));
					Reset.Location 		= new Point(500, 60 + (5 * Space));
				break;

				case "Twelve":
					//ArrayCount = 12;
					//===========TEXTBOX===========
					column.Location 	= new Point(500, 100);
					greek.Location 		= new Point(850, 100);
					japanese.Location 	= new Point(500, 100 + (1 * Space));
					english.Location	= new Point(850, 100 + (1 * Space));
					tb5.Location 		= new Point(500, 100 + (2 * Space));
					tb6.Location 		= new Point(850, 100 + (2 * Space));
					tb7.Location 		= new Point(500, 100 + (3 * Space));
					tb8.Location 		= new Point(850, 100 + (3 * Space));
					tb9.Location 		= new Point(500, 100 + (4 * Space));
					tb10.Location 		= new Point(850, 100 + (4 * Space));
					tb11.Location 		= new Point(500, 100 + (5 * Space));
					tb12.Location		= new Point(850, 100 + (5 * Space));
					Controls.Add(tb5);
					Controls.Add(tb6);
					Controls.Add(tb7);
					Controls.Add(tb8);
					Controls.Add(tb9);
					Controls.Add(tb10);
					Controls.Add(tb11);
					Controls.Add(tb12);
					
					//===========LABEL===========
					columnL.Location 	= new Point(500, 60);
					greekL.Location 	= new Point(850, 60);
					japaneseL.Location 	= new Point(500, 60 + (1 * Space));
					englishL.Location 	= new Point(850, 60 + (1 * Space));
					Label5.Location 	= new Point(500, 60 + (2 * Space));
					Label6.Location 	= new Point(850, 60 + (2 * Space));
					Label7.Location 	= new Point(500, 60 + (3 * Space));
					Label8.Location 	= new Point(850, 60 + (3 * Space));
					Label9.Location 	= new Point(500, 60 + (4 * Space));
					Label10.Location 	= new Point(850, 60 + (4 * Space));//誕生日列目！！！！！
					Label11.Location 	= new Point(500, 60 + (5 * Space));
					Label12.Location 	= new Point(850, 60 + (5 * Space));
					Controls.Add(Label5);
					Controls.Add(Label6);
					Controls.Add(Label7);
					Controls.Add(Label8);
					Controls.Add(Label9);
					Controls.Add(Label10);
					Controls.Add(Label11);
					Controls.Add(Label12);
					
					Line.Location 		= new Point(450, 0);
					button.Location 	= new Point(900, 60 + (6 * Space));
					Reload.Location 	= new Point(700, 60 + (6 * Space));
					Reset.Location 		= new Point(500, 60 + (6 * Space));
				break;
			}
			//===============TEXTBOX=============
			column.Font = new Font("YU Gothic UI", 15);
			column.Size = new Size(COL_WIDTH, COL_HEIGHT);
			column.Multiline = true;
			Controls.Add(column);

			greek.Font = new Font("YU Gothic UI", 15);
			greek.Size = new Size(COL_WIDTH, COL_HEIGHT);
			Controls.Add(greek);

			japanese.Font = new Font("YU Gothic UI", 15);
			japanese.Size = new Size(COL_WIDTH, COL_HEIGHT);
			Controls.Add(japanese);

			english.Font = new Font("YU Gothic UI", 15);
			english.Size = new Size(COL_WIDTH, COL_HEIGHT);
			Controls.Add(english);

			tb5.Font = new Font("YU Gothic UI", 15);
			tb5.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb6.Font = new Font("YU Gothic UI", 15);
			tb6.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb7.Font = new Font("YU Gothic UI", 15);
			tb7.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb8.Font = new Font("YU Gothic UI", 15);
			tb8.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb9.Font = new Font("YU Gothic UI", 15);
			tb9.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb10.Font = new Font("YU Gothic UI", 15);
			tb10.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb11.Font = new Font("YU Gothic UI", 15);
			tb11.Size = new Size(COL_WIDTH, COL_HEIGHT);

			tb12.Font = new Font("YU Gothic UI", 15);
			tb12.Size = new Size(COL_WIDTH, COL_HEIGHT);

			//===============LABEL=============
			columnL.Text = "Column";
			columnL.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			columnL.Font = new Font("YU Gothic UI", 20);
			Controls.Add(columnL);

			greekL.Text = "Greek";
			greekL.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			greekL.Font = new Font("YU Gothic UI", 20);
			Controls.Add(greekL);

			japaneseL.Text = "Japanese";
			japaneseL.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			japaneseL.Font = new Font("YU Gothic UI", 20);
			Controls.Add(japaneseL);

			englishL.Text = "English";
			englishL.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			englishL.Font = new Font("YU Gothic UI", 20);
			Controls.Add(englishL);

			Label5.Text = "Label5";
			Label5.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label5.Font = new Font("YU Gothic UI", 20);

			Label6.Text = "Label6";
			Label6.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label6.Font = new Font("YU Gothic UI", 20);

			Label7.Text = "Label7";
			Label7.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label7.Font = new Font("YU Gothic UI", 20);

			Label8.Text = "Label8";
			Label8.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label8.Font = new Font("YU Gothic UI", 20);

			Label9.Text = "Label9";
			Label9.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label9.Font = new Font("YU Gothic UI", 20);

			Label10.Text = "Label10";
			Label10.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label10.Font = new Font("YU Gothic UI", 20);

			Label11.Text = "Label11";
			Label11.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label11.Font = new Font("YU Gothic UI", 20);

			Label12.Text = "Label12";
			Label12.Size = new Size(TEB_WIDTH, TEB_HEIGHT);
			Label12.Font = new Font("YU Gothic UI", 20);
			//===============Line==============
			Line.Text = "";
			Line.Size = new Size(1, 960);
			Line.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(Line);

			//==============BUTTON=============
			button.Text = "書き込み";
			button.Size = new Size(200, 50);
			button.Font = new Font("YU Gothic UI", 20);
			button.Click += Write_Click;
			Controls.Add(button);

			Reload.Text = "再読み込み";
			Reload.Size = new Size(200, 50);
			Reload.Font = new Font("YU Gothic UI", 20);
			Reload.Click += Reload_Click;
			Reload.PerformClick();
			Controls.Add(Reload);

			Reset.Text = "ファイルを削除";
			Reset.Size = new Size(200, 50);
			Reset.Font = new Font("YU Gothic UI", 20);
			Reset.Click += Reset_Click;
			Controls.Add(Reset);

			//==============FILEMENU==============//
			mf.Text = "ファイル(&F)";								//表示名
			mf.ShortcutKeys = Keys.Control | Keys.F;			//ショートカットをCTRL + Fに

			mi_f0.Text = "開く...(&0)";							//表示名
			mi_f0.ShortcutKeys = Keys.Control | Keys.O;			//ショートカットをCTRL + 0に
			mi_f0.Click += onOpen;								//選択時に呼び出される関数
			mf.DropDownItems.Add(mi_f0);						//ファイルメニューに追加

			mi_f1.Text = "名前をつけて保存...(&A)";						//表示名
			mi_f1.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;	//ショートカットをCTRL+Shift+sに
			mi_f1.Click += onSaveAs;							//選択時に呼び出される関数
			mf.DropDownItems.Add(mi_f1);						//ファイルメニューに追加

			mf.DropDownItems.Add(menuLine);						//この位置に区切り線を追加

			mi_f2.Text = "終了(&X)";								//表示名
			mi_f2.Click += onExit;								//選択時に呼び出される関数
			mf.DropDownItems.Add(mi_f2);						//ファイルメニューに追加

			ms.Items.Add(mf);									//メニュー項目にだいるめにゅーを作成
			Controls.Add(ms);
			
			//==============FILEMENU==============//
			mc.Text = "詳細(&T?)";
			mc.ShortcutKeys = Keys.Control | Keys.D;

			mc_f0.Text = "デバッグコンソール(&D)";
			mc_f0.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
			mc_f0.Click += onConsole;
			mc.DropDownItems.Add(mc_f0);

			mc_f1.Text = "設定";
			mc_f1.Click += onConfig;
			mc.DropDownItems.Add(mc_f1);

			ms.Items.Add(mc);
			Controls.Add(ms);
		}

		//「フォームを閉じる」関数
		private void onExit(object sender, EventArgs e)
		{
			Close();
		}

		//「開く」関数
		private void onOpen(object sender, EventArgs e)
		{
			opCount++;
			var ofd = new OpenFileDialog();              //ファイルを開くダイアログを作成
			ofd.Title = "開く";                           //ダイアログの名前
			ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath); // 初期表示するディレクトリー
			if (ofd.ShowDialog() == DialogResult.OK)//ダイアログを表示して結果がOKの場合...↓
			{
				//Console.WriteLine(ofd.FileName);
				console.Add("[onOpen #" + ofd.FileName +" ]\n");
				path = ofd.FileName;
			}
			ofd.ShowDialog();
			console.Add("[Open #" + opCount + "]\n");
		}

		//「名前をつけて保存」関数
		private void onSaveAs(object sender, EventArgs e)
		{
			svCount++;
			var sfd = new SaveFileDialog();              //ファイルを保存するダイアログを作成
			sfd.Title = "名前をつけて保存";                           //ダイアログの名前
			sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath); // 初期表示するディレクトリー
			if (sfd.ShowDialog() == DialogResult.OK)//ダイアログを表示して結果がOKの場合...↓
			{
				File.WriteAllText(sfd.FileName, Controls[1].Text); //ダイアログで取得したファイル名に内容を保存
			}
			console.Add("[SaveAs #" + svCount + "]\n");
        }

		private void Write_Click(object sender, EventArgs e)
		{
			string columnT = column.Text;
			string greekT = greek.Text;
			string japaneseT = japanese.Text;
			string englishT = english.Text;
			string tb5T		= tb5.Text;
			string tb6T		= tb6.Text;
			string tb7T		= tb7.Text;
			string tb8T		= tb8.Text;
			string tb9T		= tb9.Text;
			string tb10T	= tb10.Text;
			string tb11T	= tb11.Text;
			string tb12T	= tb12.Text;
			string TEXT = columnT + ", " 
						+ greekT + ", " 
						+ japaneseT + ", " 
						+ englishT + ", " 
						+ tb5T + ", " 
						+ tb6T + ", " 
						+ tb7T + ", "
						+ tb8T + ", " 
						+ tb9T + ", " 
						+ tb10T + ", " 
						+ tb11T + ", " 
						+ tb12T;

			ConfigCSV.WriteCSV(TEXT, path, true);

            MessageBox.Show("書き込みました", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            console.Add("[Write #" + wrCount + "]\n");
		}

		private void Reload_Click(object sender, EventArgs e)
		{
			GroupBoxEX[] Groups	= new GroupBoxEX[ConfigCSV.GetLength(path)];

//			GroupBoxEX[ConfigCSV.GetLength(path)] Groups;
//			for(int i = 1; i < Groups.Length; i++)
//			{
//				Groups = new GroupsBoxEX(i);
//			}

			Console.WriteLine("Length::" + Groups.Length);
			Console.WriteLine("GetLength::" + ConfigCSV.GetLength(path));

			Grid.Font = new Font("YU Gothic UI", 20);         //文字のフォントを遊ゴシックでサイズを20に
			Grid.Location = new Point(10, 50);
			Grid.Top = ms.ClientSize.Height;
			Grid.BackColor = Color.White;
			Grid.BorderStyle = BorderStyle.Fixed3D;
//			Grid.Font = new Font("YU Gothic UI", 10);
			Grid.Size = new Size(430, ClientRectangle.Height - Grid.Top - Grid.Top);
//			Grid.Multiline = true;
			Grid.AutoScroll = true;
			Grid.Anchor   = AnchorStyles.Left  | //フォームの大きさ変わっても連動するように設定
							AnchorStyles.Right |
							AnchorStyles.Top   |
							AnchorStyles.Bottom;

			Controls.Add(Grid);
			
			rlCount++;
			console.Add("[Reload #" + rlCount + "]\n");

			//GC : GroupsCount;
			for(GC = 0; GC < Groups.Length; GC++)
			{
				Groups[GC] = new GroupBoxEX(GC);
				Groups[GC].Text = "Group" + GC;
				Groups[GC].Size = new Size(400, 200);
				Groups[GC].FrameColor = Color.Red;
				Groups[GC].Location = new Point(10, 200 * GC);
				Grid.Controls.Add(Groups[GC]);
			}
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			rsCount++;
			try
			{
				ConfigCSV.ResetCSV(path);
				/*using(FileStream fs = new FileStream("tangotyo.csv", FileMode.Open))
				{
					fs.SetLength(0);
				}*/
			}
			catch(FileNotFoundException)
			{
				console.Add("[FileStream #" + fsCount + "]System.FileNotFoundException\n");
				fsCount++;
			}
			console.Add("[Reset #" + rsCount + "]\n");
		}

		private void onConsole(object sender, EventArgs e)
		{
			TextBox DebugConsole = new TextBox();
			Form consoleWindow = new Form();
			try
			{
				//=============Window=============
				consoleWindow.TopLevel = false;
				consoleWindow.Text = "Console";
				consoleWindow.Size = new Size(WND_WIDTH / 2 + 100, 400);
				consoleWindow.Location = new Point(500, 400);
				Controls.Add(consoleWindow);
				consoleWindow.Show();
				consoleWindow.BringToFront();
				
				//consoleWindow.
				{
					DebugConsole.Text = "";
					for(int i = 0; i < console.Count; i++)
					{
						DebugConsole.AppendText(console[i]);
					}
					DebugConsole.Font = new Font("YU Gothic UI", 10);
					DebugConsole.Location = new Point(0, 0);
					DebugConsole.Size = new Size(WND_WIDTH / 2 + 100, 400);
					DebugConsole.MaximumSize = new Size(WND_WIDTH / 2 + 100, 400);
					DebugConsole.MinimumSize = new Size(WND_WIDTH / 2 + 100, 400);
					DebugConsole.BackColor = Color.Black;
					DebugConsole.ForeColor = Color.White;
					DebugConsole.Multiline = true;
					consoleWindow.Controls.Add(DebugConsole);
				}
			}
			catch(ObjectDisposedException)
			{
				fsCount++;
				console.Add("[Form #" + frCount + "]System.ObjectDisposedException\n");
			}
		}

		private void onConfig(object sender, EventArgs e)
		{
			int oc = 0;
			configWindow.Text = "ラベル設定";
			configWindow.ClientSize = new Size(500, 500);
			configWindow.AutoScroll = true;

			try
			{
				configTB1.Text = "Label";
				configTB1.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB1.Location = new Point(100, Space);
				configWindow.Controls.Add(configTB1);

				configTB2.Text = "Label";
				configTB2.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB2.Location = new Point(100, Space + (1 * Space));
				configWindow.Controls.Add(configTB2);

				configTB3.Text = "Label";
				configTB3.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB3.Location = new Point(100, Space + (2 * Space));
				configWindow.Controls.Add(configTB3);

				configTB4.Text = "Label";
				configTB4.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB4.Location = new Point(100, Space + (3 * Space));
				configWindow.Controls.Add(configTB4);

				configTB5.Text = "Label";
				configTB5.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB5.Location = new Point(100, Space + (4 * Space));
				configWindow.Controls.Add(configTB5);

				configTB6.Text = "Label";
				configTB6.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB6.Location = new Point(100, Space + (5 * Space));
				configWindow.Controls.Add(configTB6);

				configTB7.Text = "Label";
				configTB7.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB7.Location = new Point(100, Space + (6 * Space));
				configWindow.Controls.Add(configTB7);

				configTB8.Text = "Label";
				configTB8.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB8.Location = new Point(100, Space + (7 * Space));
				configWindow.Controls.Add(configTB8);

				configTB9.Text = "Label";
				configTB9.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB9.Location = new Point(100, Space + (8 * Space));
				configWindow.Controls.Add(configTB9);

				configTB10.Text = "Label";
				configTB10.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB10.Location = new Point(100, Space + (9 * Space));
				configWindow.Controls.Add(configTB10);

				configTB11.Text = "Label";
				configTB11.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB11.Location = new Point(100, Space + (10 * Space));
				configWindow.Controls.Add(configTB11);

				configTB12.Text = "Label";
				configTB12.Size = new Size(COL_WIDTH, COL_HEIGHT);
				configTB12.Location = new Point(100, Space + (11 * Space));
				configWindow.Controls.Add(configTB12);

				configLabel1.Text = "Label1";
				configLabel1.Font = new Font("YU Gothic UI", 30);
				configLabel1.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel1);

				configLabel2.Text = "Label1";
				configLabel2.Font = new Font("YU Gothic UI", 30);
				configLabel2.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel2);

				configLabel3.Text = "Label1";
				configLabel3.Font = new Font("YU Gothic UI", 30);
				configLabel3.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel3);

				configLabel4.Text = "Label1";
				configLabel4.Font = new Font("YU Gothic UI", 30);
				configLabel4.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel4);

				configLabel5.Text = "Label1";
				configLabel5.Font = new Font("YU Gothic UI", 30);
				configLabel5.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel5);

				configLabel6.Text = "Label1";
				configLabel6.Font = new Font("YU Gothic UI", 30);
				configLabel6.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel6);

				configLabel7.Text = "Label1";
				configLabel7.Font = new Font("YU Gothic UI", 30);
				configLabel7.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel7);

				configLabel8.Text = "Label1";
				configLabel8.Font = new Font("YU Gothic UI", 30);
				configLabel8.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel8);

				configLabel9.Text = "Label1";
				configLabel9.Font = new Font("YU Gothic UI", 30);
				configLabel9.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel9);

				configLabel10.Text = "Label1";
				configLabel10.Font = new Font("YU Gothic UI", 30);
				configLabel10.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel10);

				configLabel11.Text = "Label1";
				configLabel11.Font = new Font("YU Gothic UI", 30);
				configLabel11.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel11);

				configLabel12.Text = "Label1";
				configLabel12.Font = new Font("YU Gothic UI", 30);
				configLabel12.Size = new Size(TEB_WIDTH, TEB_HEIGHT + 10);
				configWindow.Controls.Add(configLabel12);

				configLabel1.Location  = new Point(100, 70);
				configLabel2.Location  = new Point(100, 70 + (1 * Space));
				configLabel3.Location  = new Point(100, 70 + (2 * Space));
				configLabel4.Location  = new Point(100, 70 + (3 * Space));
				configLabel5.Location  = new Point(100, 70 + (4 * Space));
				configLabel6.Location  = new Point(100, 70 + (5 * Space));
				configLabel7.Location  = new Point(100, 70 + (6 * Space));
				configLabel8.Location  = new Point(100, 70 + (7 * Space));
				configLabel9.Location  = new Point(100, 70 + (8 * Space));
				configLabel10.Location = new Point(100, 70 + (9 * Space));
				configLabel11.Location = new Point(100, 70 + (10 * Space));
				configLabel12.Location = new Point(100, 70 + (11 * Space));

				OK.Text = "OK!";
				OK.Size = new Size(100, 50);
				OK.Location = new Point(100, 70 + (12 * Space));
				OK.Click += onConfigClose;
				configWindow.Controls.Add(OK);

				Apply.Text = "適応";
				Apply.Size = new Size(100, 50);
				Apply.Location = new Point(200, 70 + (12 * Space));
				Apply.Click += onConfigSave;
				configWindow.Controls.Add(Apply);

				SettingSave.Text = "設定して保存する";
				SettingSave.Size = new Size(100, 50);
				SettingSave.Location = new Point(300, 70 + (12 * Space));
				SettingSave.Click += onLabelSetting;
				configWindow.Controls.Add(SettingSave);
			}
			catch(NullReferenceException)
			{
				oc++;
				Console.WriteLine("[System.NullReferenceException]#" + oc);
			}
			configWindow.Show();
		}
		private void onConfigSave(object sender, EventArgs e)
		{
			columnL.Text 	= configTB1.Text;
			greekL.Text 	= configTB2.Text;
			japaneseL.Text 	= configTB3.Text;
			englishL.Text 	= configTB4.Text;
			Label5.Text 	= configTB5.Text;
			Label6.Text 	= configTB6.Text;
			Label7.Text 	= configTB7.Text;
			Label8.Text 	= configTB8.Text;
			Label9.Text 	= configTB9.Text;
			Label10.Text 	= configTB10.Text;
			Label11.Text 	= configTB11.Text;
			Label12.Text 	= configTB12.Text;
		}

		private void onLabelSetting(object sender, EventArgs e)
		{
			string[] TEXT = new string[12];
			for(int i = 0; i < 12; i++)
			{
				ConfigFile.RemoveKey("Label" + i);
			}
			ConfigFile.Begen();
				ConfigFile.Write("Label" + 1, configTB1.Text);
				ConfigFile.Write("Label" + 2, configTB2.Text);
				ConfigFile.Write("Label" + 3, configTB3.Text);
				ConfigFile.Write("Label" + 4, configTB4.Text);
				ConfigFile.Write("Label" + 5, configTB5.Text);
				ConfigFile.Write("Label" + 6, configTB6.Text);
				ConfigFile.Write("Label" + 7, configTB7.Text);
				ConfigFile.Write("Label" + 8, configTB8.Text);
				ConfigFile.Write("Label" + 9, configTB9.Text);
				ConfigFile.Write("Label" + 10, configTB10.Text);
				ConfigFile.Write("Label" + 11, configTB11.Text);
				ConfigFile.Write("Label" + 12, configTB12.Text);
			ConfigFile.Save();

			for(int i = 0; i < 12; i++)
			{
				TEXT[i] = ConfigFile.Read("Label" + i);
			}

			columnL.Text 	= TEXT[1];
			greekL.Text 	= TEXT[2];
			japaneseL.Text 	= TEXT[3];
			englishL.Text 	= TEXT[4];
			Label5.Text 	= TEXT[5];
			Label6.Text 	= TEXT[6];
			Label7.Text 	= TEXT[7];
			Label8.Text 	= TEXT[8];
			Label9.Text 	= TEXT[9];
			Label10.Text 	= TEXT[10];
			Label11.Text 	= TEXT[11];
			Label12.Text 	= TEXT[12];
		}

		private void onConfigClose(object sender, EventArgs e)
		{
			configWindow.Close();
		}

		[STAThread]
		public static void Main()
		{
			Application.Run(new Dialog());
			Application.Run(new Program());
		}
	}
}
