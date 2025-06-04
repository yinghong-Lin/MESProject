using MDM.BLL.Users;
using MDM.DAL.Users;
using MDM.Model.UserEntities;
using MDM.BLL.Security;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MDM.UI.Admin
{
    public partial class Frm_User : Form
    {
        private readonly ILoginService _loginService;
        private readonly User _authenticatedUser;
        private readonly UserRepository _userRepository;
        private bool isUserInfoVisible = true; // 用于标记当前显示的是用户信息还是添加用户界面
        private User _selectedUser = null; // To track the currently selected user

        public Frm_User(ILoginService loginService, User authenticatedUser, UserRepository userRepository)
        {
            InitializeComponent();
            _loginService = loginService;
            _authenticatedUser = authenticatedUser;
            _userRepository = userRepository;

            // 初始化面板状态
            panelAddUser.Visible = false;
        }

        private void Confirmbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = UserIDTextBox.Text.Trim();
                string userType = UserTypeTextBox.Text.Trim();
                string userName = UserNameTextBox.Text.Trim();
                string password = UserPasswordTextBox.Text.Trim();
                string userEnglishName = UserEnglishNameTextBox.Text.Trim();
                string displayLanguage = DisplayLanguageTextBox.Text.Trim();
                string eventUser = _authenticatedUser.UserName; // 使用当前登录用户名

                if (string.IsNullOrEmpty(userId))
                {
                    MessageBox.Show("用户编号是必填项！");
                    UserIDTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(userType))
                {
                    MessageBox.Show("用户类型是必填项！");
                    UserTypeTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("用户名是必填项！");
                    UserNameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show($"用户[{userName}]请输入密码，密码不能为空！");
                    UserPasswordTextBox.Focus();
                    return;
                }

                if (_loginService.CreateUser(userId, userType, userName, password, userEnglishName, displayLanguage, eventUser))
                {
                    MessageBox.Show("用户创建成功！");
                    ClearInputs();
                    LoadUsers();
                    ToggleView(); // 切换回显示用户信息界面
                }
                else
                {
                    MessageBox.Show("用户创建失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统错误：{ex.Message}");
            }
        }

        private void Cancelbutton1_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            UserIDTextBox.Clear();
            UserTypeTextBox.Clear();
            UserNameTextBox.Clear();
            UserPasswordTextBox.Clear();
            UserEnglishNameTextBox.Clear();
            DisplayLanguageTextBox.Clear();
            // 不清除EventUserTextBox，保持显示当前登录用户
            EventRemarkTextBox.Clear();
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            // Set initial panel visibility
            panelUserInfo.Visible = true;
            panelAddUser.Visible = false;
            isUserInfoVisible = true;

            // 设置操作用户字段为只读并显示当前登录用户
            EventUser.ReadOnly = true;
            EventUserTextBox.ReadOnly = true;
            EventUser.Text = _authenticatedUser.UserName;
            EventUserTextBox.Text = _authenticatedUser.UserName;

            LoadUsers(); // 加载用户数据

            // Initialize buttons state
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// 加载所有用户数据到DataGridView
        /// </summary>
        private void LoadUsers()
        {
            try
            {
                // 使用新方法获取包含密码的用户列表
                var users = _loginService.GetAllUsers();
                dataGridView1.DataSource = users;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载用户数据失败：{ex.Message}"); // 异常处理
            }
        }

        /// <summary>
        /// 搜索按钮点击事件处理
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text.Trim(); // 获取搜索关键词
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // 根据用户ID过滤用户列表(不区分大小写)
                var users = _loginService.GetAllUsers()
                    .Where(u => u.UserId.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                dataGridView1.DataSource = users; // 绑定过滤后的数据
            }
            else
            {
                LoadUsers(); // 搜索框为空时重新加载全部用户
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && isUserInfoVisible) // 只有在显示用户信息界面时才处理行点击事件
            {
                // 获取选中行的用户数据
                _selectedUser = (User)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // 显示用户数据到右边的控件
                UserID.Text = _selectedUser.UserId;
                UserType.Text = _selectedUser.UserType;
                UserName.Text = _selectedUser.UserName;
                UserPassword.Text = _selectedUser.UserPassword;
                UserEnglishName.Text = _selectedUser.UserEnglishName ?? string.Empty;
                DisplayLanguage.Text = _selectedUser.DisplayLanguage ?? string.Empty;
                // 操作用户始终显示当前登录用户，不显示选中用户的操作用户
                EventUser.Text = _authenticatedUser.UserName;
                EventRemark.Text = _selectedUser.EventRemark ?? string.Empty;

                // Enable update and delete buttons
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }


        private void ToggleView()
        {
            isUserInfoVisible = !isUserInfoVisible;

            // Ensure only one panel is visible at a time
            panelUserInfo.Visible = isUserInfoVisible;
            panelAddUser.Visible = !isUserInfoVisible;

            if (isUserInfoVisible)
            {
                btnToggleView.Text = "切换到添加用户";
                LoadUsers(); // 切换回显示用户信息界面时重新加载数据
            }
            else
            {
                btnToggleView.Text = "切换到显示用户";
                ClearInputs(); // 清空添加用户的输入框

                // Reset the selected user when switching to add mode
                _selectedUser = null;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnToggleView_Click_1(object sender, EventArgs e)
        {
            ToggleView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("请先选择要更新的用户！");
                return;
            }

            try
            {
                // Get values from the right panel
                string userId = UserID.Text.Trim();
                string userType = UserType.Text.Trim();
                string userName = UserName.Text.Trim();
                string userEnglishName = UserEnglishName.Text.Trim();
                string displayLanguage = DisplayLanguage.Text.Trim();
                string eventUser = _authenticatedUser.UserName; // 使用当前登录用户名
                string eventRemark = EventRemark.Text.Trim();

                // Validate required fields
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userType) || string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("用户ID、用户类型和用户名是必填项！");
                    return;
                }

                // Create updated user object
                User updatedUser = new User
                {
                    UserId = userId,
                    UserType = userType,
                    UserName = userName,
                    UserEnglishName = userEnglishName,
                    DisplayLanguage = displayLanguage,
                    EventUser = eventUser,
                    EventRemark = eventRemark,
                    EditTime = DateTime.Now,
                    EventType = "Update"
                };

                // Call repository to update user
                if (_userRepository.UpdateUser(updatedUser))
                {
                    MessageBox.Show("用户更新成功！");
                    LoadUsers(); // Reload the user list
                    _selectedUser = null; // Clear selection
                    ClearUserInfoPanel(); // Clear the right panel
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("用户更新失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统错误：{ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("请先选择要删除的用户！");
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show($"确定要删除用户 {_selectedUser.UserName} 吗？", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call repository to delete user
                    if (_userRepository.DeleteUser(_selectedUser.UserId))
                    {
                        MessageBox.Show("用户删除成功！");
                        LoadUsers(); // Reload the user list
                        _selectedUser = null; // Clear selection
                        ClearUserInfoPanel(); // Clear the right panel
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("用户删除失败！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"系统错误：{ex.Message}");
                }
            }
        }

        // Add this method to clear the user info panel
        private void ClearUserInfoPanel()
        {
            UserID.Text = string.Empty;
            UserType.Text = string.Empty;
            UserName.Text = string.Empty;
            UserEnglishName.Text = string.Empty;
            DisplayLanguage.Text = string.Empty;
            // 不清除EventUser，保持显示当前登录用户
            EventRemark.Text = string.Empty;
        }

        // Add this method to handle the clear selection button click
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            _selectedUser = null;
            ClearUserInfoPanel();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dataGridView1.ClearSelection();
        }
    }
}
