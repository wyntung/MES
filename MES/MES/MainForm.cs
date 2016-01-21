using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace MES
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private MainMenu mainMenu;
        private StatusBar statusBar;
        private StatusBarPanel statusBarPanel1;
        private StatusBarPanel statusBarPanel2;
        private StatusBarPanel statusBarPanel3;
        private StatusBarPanel statusBarPanel4;
        private StatusBarPanel statusBarPanel5;
        private StatusBarPanel statusBarPanel6;
        private StatusBarPanel statusBarPanel7;
        private StatusBarPanel statusBarPanel8;
        private MenuItem menuItemS1;
        private MenuItem menuItemP1;
        private MenuItem menuItemS101;
        private MenuItem menuItemS102;
        private MenuItem menuItemS103;
        private MenuItem menuItemP101;
        private MenuItem menuItemP102;
        private MenuItem menuItemP103;
        private MenuItem menuItemP1031;
        private MenuItem menuItemP1032;

        public struct LoginUserInfo
        {
            //登录人员信息
            public int userID;			//登录人员ID
            public int roleID;			//登录人员角色
            public string userBarCode;	//登录人员条码
        }

        //数据库连接
        private SqlConnection mainConnection;
        //通用函数库实例
        private Global global;
        //数据集
        private DataSet dataSet;
        private string DBConnString;
        //初始化用户结构体实例
        private LoginUserInfo loginUserInfo = new LoginUserInfo();
        //初始化流程结构体实例
        private CurFlowConfig curFlowConfig = new CurFlowConfig();


        static class Program
        {
            /// <summary>
            /// 应用程序的主入口点。
            /// </summary>
            [STAThread]
            static void Main()
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        public MainForm()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitMainMenu();
        }

        private void InitMainMenu()
        {
            menuItemS1.Visible = true;
            menuItemP1.Visible = true;
            LoginForm loginForm = new LoginForm(mainConnection);

        }

        /// <summary>
        /// 初始化登录后主菜单
        /// </summary>
        public void InitialLoginInMainMenu()
        {
            //获取登录用户信息到数据集中
            global.GetUserLoginPopedomViewData(dataSet, loginUserInfo.userBarCode);

            menuItemS1.Visible = true;
            menuItemP1.Visible = true;

            int roleID = loginUserInfo.roleID;
            switch (roleID)
            {
                case 1:	//工艺员
                    menuItemS1.Visible = true;
                    menuItemP1.Visible = true;
                    break;
                case 2:	//工序组长
                    menuItemS1.Visible = true;
                    menuItemP1.Visible = true;
                    break;
                case 3:	//维修人员
                    menuItemS1.Visible = true;
                    menuItemP1.Visible = true;
                    break;
                case 4:	//操作人员
                    menuItemS1.Visible = true;
                    menuItemP1.Visible = true;
                    break;
            }

            int flowID = global.GetFlowID(curFlowConfig.flowName);
            switch (flowID)
            {
                case 1: //订单导入
                    this.menuItemP102.Visible = true;
                    this.menuItemP103.Visible = true;
                    break;
                case 2:
                    this.menuItemP101.Visible = true;
                    this.menuItemP102.Visible = true;
                    this.menuItemP103.Visible = true;
                    break;
                default:
                    this.menuItemS101.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemS1 = new System.Windows.Forms.MenuItem();
            this.menuItemS101 = new System.Windows.Forms.MenuItem();
            this.menuItemS102 = new System.Windows.Forms.MenuItem();
            this.menuItemS103 = new System.Windows.Forms.MenuItem();
            this.menuItemP1 = new System.Windows.Forms.MenuItem();
            this.menuItemP101 = new System.Windows.Forms.MenuItem();
            this.menuItemP102 = new System.Windows.Forms.MenuItem();
            this.menuItemP103 = new System.Windows.Forms.MenuItem();
            this.menuItemP1031 = new System.Windows.Forms.MenuItem();
            this.menuItemP1032 = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel6 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel7 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel8 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel8)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemS1,
            this.menuItemP1});
            // 
            // menuItemS1
            // 
            this.menuItemS1.Index = 0;
            this.menuItemS1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemS101,
            this.menuItemS102,
            this.menuItemS103});
            this.menuItemS1.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemS1.Text = "系统(S)";
            // 
            // menuItemS101
            // 
            this.menuItemS101.Index = 0;
            this.menuItemS101.Text = "登陆";
            this.menuItemS101.Click += new System.EventHandler(this.menuItemS101_Click);
            // 
            // menuItemS102
            // 
            this.menuItemS102.Index = 1;
            this.menuItemS102.Text = "退出";
            this.menuItemS102.Click += new System.EventHandler(this.menuItemS102_Click);
            // 
            // menuItemS103
            // 
            this.menuItemS103.Index = 2;
            this.menuItemS103.Text = "用户信息";
            this.menuItemS103.Click += new System.EventHandler(this.menuItemS102_Click);
            // 
            // menuItemP1
            // 
            this.menuItemP1.Index = 1;
            this.menuItemP1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemP101,
            this.menuItemP102,
            this.menuItemP103});
            this.menuItemP1.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItemP1.Text = "管理(P)";
            // 
            // menuItemP101
            // 
            this.menuItemP101.Index = 0;
            this.menuItemP101.Text = "权限管理";
            this.menuItemP101.Click += new System.EventHandler(this.menuItemP102_Click);
            // 
            // menuItemP102
            // 
            this.menuItemP102.Index = 1;
            this.menuItemP102.Text = "人员管理";
            // 
            // menuItemP103
            // 
            this.menuItemP103.Index = 2;
            this.menuItemP103.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemP1031,
            this.menuItemP1032});
            this.menuItemP103.Text = "订单管理";
            // 
            // menuItemP1031
            // 
            this.menuItemP1031.Index = 0;
            this.menuItemP1031.Text = "新建";
            this.menuItemP1031.Click += new System.EventHandler(this.menuItemP1031_Click);
            // 
            // menuItemP1032
            // 
            this.menuItemP1032.Index = 1;
            this.menuItemP1032.Text = "导入";
            this.menuItemP1032.Click += new System.EventHandler(this.menuItemP1032_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 229);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5,
            this.statusBarPanel6,
            this.statusBarPanel7,
            this.statusBarPanel8});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(801, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.TabStop = true;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "数据库状态";
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "操作员";
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Text = "登陆时间";
            // 
            // statusBarPanel6
            // 
            this.statusBarPanel6.Name = "statusBarPanel6";
            // 
            // statusBarPanel7
            // 
            this.statusBarPanel7.Name = "statusBarPanel7";
            this.statusBarPanel7.Text = "当前工序";
            // 
            // statusBarPanel8
            // 
            this.statusBarPanel8.Name = "statusBarPanel8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 251);
            this.Controls.Add(this.statusBar);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "终端生产管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel8)).EndInit();
            this.ResumeLayout(false);

        }
        //
        //登陆
        //
        private void menuItemS101_Click(object sender, EventArgs e)
        {
            LogInOut();

        }
        //
        //退出
        //
        private void menuItemS102_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //用户信息
        //
        private void menuItemS103_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //
        //权限管理
        //
        private void menuItemP101_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //
        //人员管理
        //
        private void menuItemP102_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //
        //订单管理-新建
        //
        private void menuItemP1031_Click(object sender, EventArgs e)
        {

        }
        //
        //订单管理-手工导入
        //
        private void menuItemP1032_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        //
        //登陆
        //
        public void LogInOut()
        {
            GetConfig();
            GetCurrentFlow(dataSet);
            GetSqlConnection(dataSet);

            global = new Global(mainConnection);
            //
            //显示登陆界面
            //
            LoginForm loginForm = new LoginForm(mainConnection);
            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                loginUserInfo.userBarCode = loginForm.strUserName;
                loginUserInfo.userID = global.GetUserID(loginUserInfo.userBarCode);
                loginUserInfo.roleID = global.GetRoleID(loginUserInfo.userBarCode);
                if (global.IsFlowUser(loginUserInfo.userBarCode, curFlowConfig.flowName))
                {
                    global.InsertLoginRecord(loginUserInfo.userID, "登录", DateTime.Now.ToString(), statusBarPanel8.Text, "成功");
                    statusBarPanel4.Text = loginForm.strUserName;
                    statusBarPanel6.Text = DateTime.Now.ToString();

                    InitialLoginInMainMenu();
                }
                else
                {
                    global.InsertLoginRecord(loginUserInfo.userID, "登录", DateTime.Now.ToString(), curFlowConfig.flowName, "失败");
                }

            }
            else
            {

            }

        }

        public void GetConfig()
        {
            dataSet = new DataSet();
            dataSet.ReadXml("Config.xml");
        }

        public void GetCurrentFlow(DataSet ds)
        {
            statusBarPanel8.Text = ds.Tables["FlowConfig"].Rows[0]["CurrentFlow"].ToString();
        }

        public void GetSqlConnection(DataSet ds)
        {
            string strSqlConnection = @"server=";
            string serverName;
            string database;
            string userName;
            string password;
            int connectionFlag = Convert.ToInt16(ds.Tables["DBConfig"].Rows[0][0]);

            switch (connectionFlag)
            {
                //本地连接
                case 0:
                    serverName = ds.Tables["DBConfig"].Rows[0][1].ToString();
                    break;
                //远程连接
                case 1:
                    serverName = ds.Tables["DBConfig"].Rows[0][2].ToString();
                    break;
                default:
                    serverName = ds.Tables["DBConfig"].Rows[0][1].ToString();
                    break;
            }

            database = ds.Tables["DBConfig"].Rows[0][3].ToString();
            userName = ds.Tables["DBConfig"].Rows[0][4].ToString();
            password = ds.Tables["DBConfig"].Rows[0][5].ToString();

            //得到数据库连接字符串
            DBConnString = strSqlConnection + serverName + ";uid=" + userName + ";pwd=" + password + ";database=" + database + ";";

            mainConnection = new SqlConnection(DBConnString);

            //打开数据库连接
            try
            {
                mainConnection.StateChange += new StateChangeEventHandler(mainConnection_StateChange);
                mainConnection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
                mainConnection.Close();
            }
        }
        private void ProductImport(String flowName)
        {
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show("Error opening" + e.Message, flowName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserInfo()
        {
            throw new NotImplementedException();
        }

        public void mainConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            //显示数据库当前状态
            string strCurrentStatus;
            if (e.CurrentState.ToString().Equals("Open"))
                strCurrentStatus = "已连接";
            else if (e.CurrentState.ToString().Equals("Closed"))
                strCurrentStatus = "已关闭";
            else if (e.CurrentState.ToString().Equals("Connecting"))
                strCurrentStatus = "正在连接";
            else if (e.CurrentState.ToString().Equals("Executing"))
                strCurrentStatus = "正在执行";
            else if (e.CurrentState.ToString().Equals("Fetching"))
                strCurrentStatus = "正在检索";
            else if (e.CurrentState.ToString().Equals("Broken"))
                strCurrentStatus = "连接中断";
            else
                strCurrentStatus = "未知";

            statusBarPanel2.Text = strCurrentStatus;
        }

    }
}
