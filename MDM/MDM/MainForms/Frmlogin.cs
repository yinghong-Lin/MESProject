using MDM.BLL.Factory;
using MDM.BLL.Users;
using MDM.Model.UserEntities;
using MDM.UI.Admin;
using System;
using System.Windows.Forms;

namespace MDM.UI.MainForms
{
    // 登录窗体类，继承自Form类
    public partial class Frmlogin : Form
    {
        // 登录服务接口实例，用于处理登录逻辑
        private readonly ILoginService _loginService;
        private readonly IFactoryService _factoryService;
        private const string ConnectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=123456;Port=3306;";

        // 认证后的用户对象，包含已登录用户的详细信息
        public User AuthenticatedUser { get; private set; }

        // 构造函数，注入登录服务实例和工厂服务实例
        public Frmlogin(ILoginService loginService, IFactoryService factoryService)
        {
            InitializeComponent(); // 调用设计器生成的代码，初始化窗体控件
            _loginService = loginService; // 将登录服务实例保存到私有变量中
            _factoryService = factoryService; // 将工厂服务实例保存到私有变量中

            // 窗体加载事件
            this.Load += Frmlogin_Load;
        }

        // 窗体加载事件处理方法
        private void Frmlogin_Load(object sender, EventArgs e)
        {
            // 加载工厂数据到下拉框
            LoadFactoryTypes();
        }

        // 加载工厂类型到下拉框
        private void LoadFactoryTypes()
        {
            try
            {
                // 清空下拉框
                FactorySelection.Items.Clear();

                // 从工厂服务获取所有工厂
                var factories = _factoryService.GetAllFactories();

                // 将工厂类型添加到下拉框
                foreach (var factory in factories)
                {
                    FactorySelection.Items.Add(factory.FactoryType);
                }

                // 如果有工厂类型，选择第一个
                if (FactorySelection.Items.Count > 0)
                {
                    FactorySelection.SelectedIndex = 0;
                }
                else
                {
                    // 如果没有工厂类型，添加一个默认选项
                    FactorySelection.Items.Add("默认工厂");
                    FactorySelection.SelectedIndex = 0;
                    MessageBox.Show("未找到工厂类型数据，已添加默认选项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载工厂类型失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 添加一个默认选项，确保下拉框不为空
                FactorySelection.Items.Add("默认工厂");
                FactorySelection.SelectedIndex = 0;
            }
        }

        // 用户名文本框内容改变事件处理方法
        public void username_TextChanged(object sender, EventArgs e)
        {
            // 用户名文本框内容改变事件处理
        }

        // 密码文本框内容改变事件处理方法
        private void password_TextChanged(object sender, EventArgs e)
        {
            // 密码文本框内容改变事件处理
        }

        // 登录按钮点击事件处理方法
        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取并去除用户名和密码文本框内容的前后空白字符
                string inputUserName = username.Text.Trim();
                string inputPassword = password.Text.Trim();

                // 检查用户名是否为空
                if (string.IsNullOrEmpty(inputUserName))
                {
                    MessageBox.Show("请输入用户名，用户名不能为空！"); // 显示错误信息
                    username.Focus(); // 将焦点设置到用户名文本框
                    return; // 结束方法
                }

                // 检查密码是否为空
                if (string.IsNullOrEmpty(inputPassword))
                {
                    MessageBox.Show($"用户[{inputUserName}]请输入密码，密码不能为空！"); // 显示错误信息
                    password.Focus(); // 将焦点设置到密码文本框
                    return; // 结束方法
                }

                // 检查是否选择了工厂
                if (FactorySelection.SelectedItem == null)
                {
                    MessageBox.Show("请选择工厂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FactorySelection.Focus();
                    return;
                }

                User user;
                // 获取工厂选择的值
                string factoryType = FactorySelection.SelectedItem.ToString();

                // 调用登录服务的ValidateUserWithDetail方法验证用户信息，传入工厂类型
                string loginResult = _loginService.ValidateUserWithDetail(inputUserName, inputPassword, out user, factoryType);

                AuthenticatedUser = user;

                // 如果loginResult为空字符串，表示登录成功
                if (string.IsNullOrEmpty(loginResult))
                {
                    this.DialogResult = DialogResult.OK; // 设置窗体的对话结果为OK
                    MessageBox.Show("登录成功！"); // 显示登录成功信息

                    // 创建主窗体实例，传递正确的参数
                    FrmMain mainForm = new FrmMain(
                        this,
                        _loginService,
                        AuthenticatedUser,
                        factoryType,
                        ConnectionString,
                        AuthenticatedUser,
                        factoryType
                    );
                    mainForm.Show(); // 显示主窗体
                    this.Hide(); // 隐藏登录窗体
                }
                else
                {
                    // 处理登录失败的情况
                    if (loginResult == "用户名不存在，请重试！" || loginResult == "密码错误，请重试！")
                    {
                        MessageBox.Show("用户名或密码错误，请重试！"); // 显示用户名或密码错误信息
                        username.Focus(); // 将焦点设置到用户名文本框
                    }
                    else
                    {
                        MessageBox.Show(loginResult); // 显示其他登录错误信息
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统错误：{ex.Message}"); // 捕获并显示系统错误信息
            }
        }

        // 取消按钮点击事件处理方法
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // 清空用户名和密码文本框内容
            username.Text = string.Empty;
            password.Text = string.Empty;

            // 关闭当前登录窗体
            this.Close();
        }

        private void FactorySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 工厂选择变更事件处理
        }
    }
}
