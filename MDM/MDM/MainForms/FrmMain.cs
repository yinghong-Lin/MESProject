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
using MDM.UI.WorkOrders;
using MDM.UI.Batch;
using MDM.BLL.Carr;
using MDM.DAL.Carr;
using MDM.UI.Carr;
using MDM.UI.Material;

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

            // 添加工单菜单系统
            AddWorkOrderMenuSystem(menuList);

            if (menuList != null && menuList.Count > 0)
            {
                // 步骤1：先找出所有顶级菜单（parent_menu_id=0的菜单）并自定义排序
                var topLevelMenus = menuList.Where(m => m.ParentMenuId == 0)
                    .OrderBy(m => m.MenuName switch
                    {
                        "生产计划" => 1,
                        "在制品" => 2,
                        "载具" => 3,
                        "设备" => 4,
                        "物料" => 5,
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

        // 添加工单菜单系统
        private void AddWorkOrderMenuSystem(List<Menu> menuList)
        {
            // 添加工单顶级菜单（如果不存在）
            if (!menuList.Any(m => m.MenuName == "工单" && m.ParentMenuId == 0))
            {
                menuList.Add(new Menu
                {
                    MenuId = -1000,
                    MenuName = "工单",
                    ParentMenuId = 0,
                    FunctionId = null
                });
            }

            // 获取工单菜单ID
            var workOrderMenuId = menuList.First(m => m.MenuName == "工单" && m.ParentMenuId == 0).MenuId;

            // 添加子菜单（如果不存在）
            string[] subMenus = { "创建工单", "取消创建工单", "投工单" };
            foreach (var menuName in subMenus)
            {
                if (!menuList.Any(m => m.MenuName == menuName && m.ParentMenuId == workOrderMenuId))
                {
                    menuList.Add(new Menu
                    {
                        MenuId = menuList.Min(m => m.MenuId) - 1, // 生成唯一负ID
                        MenuName = menuName,
                        ParentMenuId = workOrderMenuId,
                        FunctionId = "c" // 设置为功能菜单
                    });
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
                case "载具主页面": // 添加载具菜单项的处理逻辑
                    try
                    {
                        var carrierRepository = new CarrierRepository(_connectionString); // 假设你已经实现了CarrierRepository
                        var carrierService = new CarrierService(carrierRepository); // 假设你已经实现了CarrierService
                        childForm = new FrmCarrier(carrierService); // 假设你已经实现了FrmCreateCarrier窗体

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建载具窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建载具窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "创建载具": // 添加载具菜单项的处理逻辑
                    try
                    {
                        var carrierRepository = new CarrierRepository(_connectionString); // 假设你已经实现了CarrierRepository
                        var carrierService = new CarrierService(carrierRepository); // 假设你已经实现了CarrierService
                        childForm = new FrmCreateCarrier(carrierService); // 假设你已经实现了FrmCreateCarrier窗体
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建载具窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建载具窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "单批次进站":
                    try
                    {
                        childForm = new FrmWorkStation();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建工作站窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建工作站窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "生产返修":
                    try
                    {
                        Debug.WriteLine("正在创建生产维修窗体...");
                        // 创建ReworkRepository实例，传入连接字符串
                        var reworkRepository = new ReworkRepository(_connectionString);
                        // 创建ReworkService实例，传入仓储
                        var reworkService = new ReworkService(reworkRepository);
                        // 创建生产维修窗体，传入服务
                        childForm = new FrmRework(reworkService);
                        Debug.WriteLine("生产维修窗体创建成功");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建生产维修窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建生产维修窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "创建工单":
                    try
                    {
                        Debug.WriteLine("正在打开创建工单窗体...");
                        // 使用正确的构造函数创建窗体
                        childForm = new FrmCreateWorkOrder();
                        Debug.WriteLine("创建工单窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建工单窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建工单窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "取消创建工单":
                    try
                    {
                        // 实际项目中这里应创建取消工单相关的窗体
                        // 示例：childForm = new FrmCancelWorkOrder();
                        Debug.WriteLine("正在打开取消创建工单窗体...");
                        childForm = new FrmCancelWorkOrder();
                        Debug.WriteLine("取消创建工单窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"取消创建工单窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"取消创建工单窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "投工单":
                    try
                    {
                        // 实际项目中这里应创建投工单相关的窗体
                        // 示例：childForm = new FrmDispatchWorkOrder();
                        Debug.WriteLine("正在打开投工单窗体...");
                        childForm = new FrmDispatchWorkOrder();
                        Debug.WriteLine("投工单窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"投工单窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"投工单窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "主页面":
                    try
                    {
                        Debug.WriteLine("正在打开主页面窗体...");
                        childForm = new FrmMainPage();
                        Debug.WriteLine("主页面窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"主页面窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"主页面窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "创建批次":
                    childForm = new FrmCreateBatch(_connectionString);
                    break;
                case "取消创建批次":
                    childForm = new FrmCancelCreateBatch();
                    break;
                case "锁定批次":
                    childForm = new FrmLockedBatch();
                    break;
                case "解锁批次":
                    childForm = new FrmUnlockedBatch();
                    break;
                case "上料":
                    try
                    {
                        Debug.WriteLine("正在打开上料窗体...");
                        childForm = new FrmLoadMaterial(); // 假设存在FrmLoadMaterial窗体
                        Debug.WriteLine("上料窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"上料窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"上料窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "下料":
                    try
                    {
                        Debug.WriteLine("正在打开下料窗体...");
                        childForm = new FrmUnloadMaterial(); // 假设存在FrmUnloadMaterial窗体
                        Debug.WriteLine("下料窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"下料窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"下料窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "创建物料":
                    try
                    {
                        Debug.WriteLine("正在打开创建物料窗体...");
                        childForm = new FrmCreateMaterial(); // 假设存在FrmCreateMaterial窗体
                        Debug.WriteLine("创建物料窗体已打开");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"创建物料窗体时发生异常: {ex.Message}");
                        MessageBox.Show($"创建物料窗体时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FrmMain_Load_1(object sender, EventArgs e)
        {

        }
    }
}
