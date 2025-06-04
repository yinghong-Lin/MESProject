using System.Security.Cryptography; // 引用系统加密服务的命名空间
using System.Text; // 引用系统文本处理的命名空间

namespace MDM.BLL.Security
{
    // 定义一个静态类 PasswordHasher，用于密码的哈希处理
    public static class PasswordHasher
    {
        // 生成指定大小的随机盐值
        // 参数 size: 盐值的字节大小
        // 返回值: 生成的盐值，以 Base64 编码的字符串形式
        public static string GenerateSalt(int size)
        {
            // 创建一个字节数组，大小为指定的 size
            var salt = new byte[size];
            // 使用 RandomNumberGenerator 填充盐值数组，确保其随机性
            RandomNumberGenerator.Fill(salt);
            // 将盐值数组转换为 Base64 编码的字符串并返回
            return Convert.ToBase64String(salt);
        }

        // 对密码进行哈希处理，结合盐值以增加安全性
        // 参数 password: 需要哈希的原始密码
        // 参数 salt: 在哈希过程中使用的盐值
        // 返回值: 哈希后的密码和盐值的组合字符串，格式为 "哈希值:盐值"
        public static string HashPassword(string password, string salt)
        {
            // 使用 SHA256 哈希算法创建一个 SHA256 对象
            using (var sha256 = SHA256.Create())
            {
                // 将密码和盐值连接后转换为字节数组
                var saltedHashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                // 将哈希后的字节数组转换为 Base64 编码的字符串
                // 并与盐值一起返回，盐值以 Base64 编码的形式附加在哈希值后面，中间用冒号分隔
                return $"{Convert.ToBase64String(saltedHashBytes)}:{salt}";
            }
        }
    }
}
