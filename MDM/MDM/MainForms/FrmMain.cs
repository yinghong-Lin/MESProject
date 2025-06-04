using System; // 引入系统命名空间
using System.Windows.Forms; // 引入Windows Forms命名空间
using System.Linq;
using System.Collections.Generic;
using MDM.UI.Admin; // 引入管理员相关的UI组件
using MDM.UI.Factory; // 引入工厂相关的UI组件
using MDM.BLL.Users; // 引入用户相关的业务逻辑层组件
using MDM.BLL.Equipment; // 引入设备相关的业务逻辑层组件
using MDM.Model.UserEntities; // 引入用户实体相关的模型层组件
using MDM.DAL.Equipment;
using System.Diagnostics;
using MDM.BLL.Process;
using MDM.DAL.Process;
using MDM.Model;
using MDM.UI.Process;

namespace MDM.UI.MainForms
{
    public partial class FrmMain : Form
    {
        private readonly Frmlogin _loginForm;
        private readonly ILoginService _loginService;
        private readonly User _authenticatedUser;
        private readonly string _factoryType;
        private readonly string _connectionString;
        private readonly User _currentUser;
        private readonly string _currentFactoryId;

        public FrmMain(Frmlogin loginForm, ILoginService loginService, User authenticatedUser, string factoryType, string connectionString, User currentUser, string factoryId = null)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _loginService = loginService;
            _authenticatedUser = authenticatedUser;
            _factoryType = factoryType;
            _connectionString = connectionString;
            _currentUser = currentUser;
            _currentFactoryId = factoryId ?? factoryType; // 如果factoryId为空，使用factoryType

            InitMenuSystem();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 窗体加载事件处理
            this.Text = $"MDM系统 - 用户: {_currentUser.UserName}";
            if (!string.IsNullOrEmpty(_currentFactoryId))
            {
                this.Text += $" - 工厂: {_currentFactoryId}";
            }
        }

        private void InitMenuSystem()
        {
            // 创建主菜单栏
            MenuStrip menuStrip = new MenuStrip();
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // 获取当前用户有权限的菜单列表
            List<Menu> menuList = _loginService.GetUserPermissionMenus(_currentUser.UserId, _currentFactoryId);

            if (menuList != null && menuList.Count > 0)
            {
                // 步骤1：先找出所有顶级菜单（parent_menu_id=0的菜单）并自定义排序
                var topLevelMenus = menuList.Where(m => m.ParentMenuId == 0)
                    .OrderBy(m => m.MenuName switch
                    {
                        "工厂" => 1,
                        "工艺" => 2,
                        "管理员" => 3,
                        "设备" => 4,
                        _ => 99
                    }).ToList();

                // 步骤2：为每个顶级菜单创建菜单项
                foreach (Menu topMenu in topLevelMenus)
                {
                    // 创建顶级菜单项
                    ToolStripMenuItem topMenuItem = new ToolStripMenuItem(topMenu.MenuName);
                    menuStrip.Items.Add(topMenuItem);

                    // 步骤3：递归查找并添加子菜单
                    AddChildMenuItems(topMenuItem, topMenu.MenuId, menuList);
                }
            }
        }

        // 递归添加子菜单的方法
        private void AddChildMenuItems(ToolStripMenuItem parentMenuItem, int parentMenuId, List<Menu> allMenus)
        {
            // 找出当前父菜单下的所有直接子菜单
            var childMenus = allMenus.Where(m => m.ParentMenuId == parentMenuId).ToList();

            foreach (Menu childMenu in childMenus)
            {
                // 创建子菜单项
                ToolStripMenuItem childMenuItem = new ToolStripMenuItem(childMenu.MenuName);

                // 如果是功能菜单（function_id='c'），添加点击事件
                if (childMenu.FunctionId == "c")
                {
                    childMenuItem.Click += MenuItem_Click;
                }

                // 将子菜单项添加到父菜单
                parentMenuItem.DropDownItems.Add(childMenuItem);

                // 递归处理，为当前子菜单继续查找下一级子菜单
                AddChildMenuItems(childMenuItem, childMenu.MenuId, allMenus);
            }
        }

        // 菜单项点击事件处理方法
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string tabText = menuItem.Text;
            Form childForm = null;

            switch (tabText)
            {
                case "工厂":
                    childForm = new Frm_Factory();
                    break;
                case "设备组":
                    try
                    {
                        Debug.WriteLine("正在创建设备组窗体...");
                        // 创建EqpGroupRepository实例，传入连接字符串
                        var eqpGroupRepository = new EqpGroupRepository(_connectionString);
                        // 创建EqpGroupService实例，传入仓储
                        var eqpGroupService = new EqpGroupService(eqpGroupRepository);
                        // 创建设备组窗体，传入服务和仓储
                        childForm = new FrmEqpGroup(eqpGroupService, eqpGroupRepository);
                        Debug.WriteLine("设备组窗体创建成功");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建设备组窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建设备组窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "设备":
                    try
                    {
                        Debug.WriteLine("正在创建设备窗体...");
                        // 创建EqpRepository实例，传入连接字符串
                        var eqpRepository = new EqpRepository(_connectionString);
                        // 创建EqpService实例，传入仓储
                        var eqpService = new EqpService(eqpRepository);
                        // 创建设备窗体，传入服务
                        childForm = new FrmEqp(eqpService);
                        Debug.WriteLine("设备窗体创建成功");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建设备窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建设备窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "用户":
                    var userRepository = _loginService.UserRepository;
                    if (userRepository != null)
                    {
                        childForm = new Frm_User(_loginService, _currentUser, userRepository);
                    }
                    break;
                case "生产地信息":
                    childForm = new Frm_Area();
                    break;
                case "权限":
                    childForm = new Frm_Permission();
                    break;
                case "工艺包":
                    try
                    {
                        Debug.WriteLine("正在创建工艺包窗体...");
                        // 创建ProcessRepository实例，传入连接字符串
                        var processRepository = new ProcessRepository(_connectionString);
                        // 创建ProcessService实例，传入仓储
                        var processService = new ProcessService(processRepository);
                        // 创建工艺包窗体，传入服务
                        childForm = new FrmProcess(processService);
                        Debug.WriteLine("工艺包窗体创建成功");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建工艺包窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建工艺包窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "工艺路线":
                    try
                    {
                        Debug.WriteLine("正在创建工艺路线窗体...");
                        // 创建ProcessRepository实例，传入连接字符串
                        var processRepository = new ProcessRepository(_connectionString);
                        // 创建ProcessService实例，传入仓储
                        var processService = new ProcessService(processRepository);
                        // 创建工艺路线窗体，传入服务
                        childForm = new FrmProcessRoute(processService, _currentFactoryId);
                        Debug.WriteLine("工艺路线窗体创建成功");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建工艺路线窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建工艺路线窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

            if (childForm != null)
            {
                // 检查是否已经存在相同的标签页
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tabText)
                    {
                        tabControl1.SelectedTab = tabPage;
                        return;
                    }
                }

                // 创建新的标签页
                TabPage newTabPage = new TabPage(tabText);
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                newTabPage.Controls.Add(childForm);
                childForm.Show();

                tabControl1.TabPages.Add(newTabPage);
                tabControl1.SelectedTab = newTabPage;
            }
        }

        // 重写 Form 的 FormClosing 事件，处理窗体关闭时的逻辑
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_loginForm != null)
            {
                _loginForm.Show();
                this.Hide();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 标签页选择变更事件处理
        }
    }
}
