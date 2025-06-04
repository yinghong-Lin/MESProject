-- 关闭主键检查
SET FOREIGN_KEY_CHECKS = 0;

-- 删除原有表（如果存在）
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS factories;
DROP TABLE IF EXISTS permissions;
DROP TABLE IF EXISTS user_permissions;
DROP TABLE IF EXISTS menus;
DROP TABLE IF EXISTS permission_menu;
DROP TABLE IF EXISTS permission_user;
DROP TABLE IF EXISTS eqp_group;
DROP TABLE IF EXISTS eqps;
DROP TABLE IF EXISTS ports;
DROP TABLE IF EXISTS eqp_group_his;

-- 创建用户表
CREATE TABLE users (
    user_id VARCHAR(50) PRIMARY KEY COMMENT '用户编号',
    user_type VARCHAR(50) NOT NULL COMMENT '用户类型',
    user_name VARCHAR(100) NOT NULL COMMENT '用户名',
    user_password VARCHAR(100) NOT NULL COMMENT '用户密码',
    user_english_name VARCHAR(100) COMMENT '用户英文名',
    display_language VARCHAR(20) COMMENT '显示语言',
    last_login_time DATETIME COMMENT '最近登录时间',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) COMMENT='用户信息表，存储用户的基本信息及相关事件信息';

-- 创建工厂表
CREATE TABLE factories (
    factory_id INT PRIMARY KEY COMMENT '工厂编号',
    factory_type VARCHAR(100) COMMENT '工厂类型',
    factory_description TEXT COMMENT '工厂描述',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    event_type VARCHAR(50) COMMENT '事件类型',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间'
);

-- 插入 factories 表数据
INSERT INTO factories (factory_id, factory_type, factory_description, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, 'BE', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create'),
(2, 'DMW', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create'),
(3, 'HONSUN', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create'),
(4, 'ADMIN', NULL, NULL, NULL, '2025-04-28 14:00:00', '2025-04-28 14:00:00', 'create');

-- 创建权限表
CREATE TABLE permissions (
    permission_id VARCHAR(50) PRIMARY KEY COMMENT '权限号',
    permission_name VARCHAR(100) NOT NULL COMMENT '权限名',
    permission_description TEXT COMMENT '权限说明',
    permission_type VARCHAR(50) COMMENT '权限类型',
    system_id VARCHAR(50) COMMENT '系统号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) COMMENT='权限信息表，存储权限的相关信息';

-- 创建用户-权限关联表（用户和权限暂时设置为一多关系，后续可拓展改为多对多）
CREATE TABLE permission_user (
    id INT AUTO_INCREMENT PRIMARY KEY COMMENT '关联记录编号',
    permission_id VARCHAR(50) COMMENT '权限编号',
    user_id VARCHAR(50) COMMENT '用户编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件',
    FOREIGN KEY (permission_id) REFERENCES permissions(permission_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
) COMMENT='权限与用户关联表，存储权限和用户的一对多关系';

-- 创建菜单表
CREATE TABLE menus (
    menu_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '菜单号',
    menu_name VARCHAR(100) NOT NULL COMMENT '菜单名',
    function_id VARCHAR(10) COMMENT '功能ID',
    menu_description TEXT COMMENT '菜单说明',
    parent_menu_id INT COMMENT '上级菜单号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) COMMENT='菜单信息表，存储菜单的相关信息及事件信息';

-- 插入 menus 表数据
INSERT INTO menus (menu_id, menu_name, function_id, menu_description, parent_menu_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, '工厂', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(2, '工厂', 'c', NULL, 1, NULL, NULL, NULL, NOW(), NULL),
(3, '生产地信息', 'c', NULL, 1, NULL, NULL, NULL, NOW(), NULL),
(4, '管理员', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(5, '菜单', 'c', NULL, 4, NULL, NULL, NULL, NOW(), NULL),
(6, '用户', 'c', NULL, 4, NULL, NULL, NULL, NOW(), NULL),
(7, '权限', 'p', NULL, 4, NULL, NULL, NULL, NOW(), NULL),
(8, '权限', 'c', NULL, 7, NULL, NULL, NULL, NOW(), NULL),
(9, '菜单权限', 'c', NULL, 7, NULL, NULL, NULL, NOW(), NULL),
(10, '用户权限', 'c', NULL, 7, NULL, NULL, NULL, NOW(), NULL),
(11, '设备', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(12, '设备组', 'c', NULL, 11, NULL, NULL, NULL, NOW(), NULL),
(13, '设备', 'c', NULL, 11, NULL, NULL, NULL, NOW(), NULL),
(14, '物料', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(15, '产品组', 'c', NULL, 14, NULL, NULL, NULL, NOW(), NULL);

-- 创建权限-菜单关联表（因为权限和菜单是多对多关系）
CREATE TABLE permission_menu (
    id INT AUTO_INCREMENT PRIMARY KEY COMMENT '关联记录编号',
    permission_id VARCHAR(50) COMMENT '权限编号',
    menu_id INT COMMENT '菜单编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件',
    FOREIGN KEY (permission_id) REFERENCES permissions(permission_id),
    FOREIGN KEY (menu_id) REFERENCES menus(menu_id)
) COMMENT='权限与菜单关联表，存储权限和菜单的多对多关系';

-- 插入 permissions 表数据
INSERT INTO permissions (permission_id, permission_name, permission_description, permission_type, system_id, event_user, event_remark, edit_time, create_time, event_type) VALUES
('ADMIN_MDM', 'MDM Administrator', NULL, 'MENU', 'MDM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL),
('TEST_PERMISSION', 'Test', '这是一个测试权限', 'TEST', 'TEST_SYSTEM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL),
('BW_MDM', 'BW MDM Permission', '这是一个BW MDM权限', 'MENU', 'MDM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL),
('Test_MDM', 'Test MDM', '这是一个测试MDM权限', 'TEST', 'MDM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL);

-- 插入 permission_menu 表数据
INSERT INTO permission_menu (id, permission_id, menu_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, 'ADMIN_MDM', 1, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(2, 'ADMIN_MDM', 2, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(3, 'ADMIN_MDM', 4, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(4, 'ADMIN_MDM', 6, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(5, 'ADMIN_MDM', 7, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(6, 'ADMIN_MDM', 8, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(7, 'ADMIN_MDM', 9, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(8, 'BW_MDM', 3, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(9, 'Test_MDM', 5, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(10, 'ADMIN_MDM', 17, NULL, NULL, NULL, '2025-04-29 09:14:37', NULL),
(11, 'ADMIN_MDM', 11, NULL, NULL, NULL, '2025-04-29 10:55:29', NULL),
(12, 'ADMIN_MDM', 12, NULL, NULL, NULL, '2025-04-29 10:55:41', NULL),
(13, 'ADMIN_MDM', 13, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL);

-- 创建设备组表
CREATE TABLE eqp_group (
    eqp_group_id VARCHAR(100) PRIMARY KEY COMMENT '设备组编号',
    eqp_group_type VARCHAR(100) NOT NULL COMMENT '设备组类型',
    eqp_group_description TEXT COMMENT '设备组说明',
    factory_id INT COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 插入设备组表数据
INSERT INTO eqp_group (eqp_group_id, eqp_group_type, eqp_group_description, factory_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('AOI', 'Inspection', 'AOI', 4, NULL, NULL, NULL, NOW(), NULL),
('AQM', 'Measurement', 'AQM', 4, NULL, NULL, NULL, NOW(), NULL),
('ATE', 'Test', 'ATE', 4, NULL, NULL, NULL, NOW(), NULL),
('DB', 'Process', '贴片', 4, NULL, NULL, NULL, NOW(), NULL),
('WB', 'Process', '键合', 3, NULL, NULL, NULL, NOW(), NULL);

-- 创建设备表
CREATE TABLE eqps (
    eqp_id VARCHAR(100) PRIMARY KEY COMMENT '设备号',
    eqp_type VARCHAR(100) NOT NULL COMMENT '设备类型',
    eqp_detail_type VARCHAR(100) NOT NULL COMMENT '设备详细类型',
    eqp_description TEXT COMMENT '设备说明',
    eqp_group_id VARCHAR(100) COMMENT '关联的设备组号',
    parent_eqp_id VARCHAR(100) COMMENT '上级设备号',
    eqp_level VARCHAR(100) COMMENT '设备层次',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 创建端口表
CREATE TABLE ports (
    port_id VARCHAR(100) PRIMARY KEY COMMENT '端口',
    port_type VARCHAR(100) NOT NULL COMMENT '端口类型',
    port_detail_type VARCHAR(100) NOT NULL COMMENT '端口详细类型',
    port_description TEXT COMMENT '端口说明',
    eqp_id VARCHAR(100) COMMENT '关联的设备号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 创建设备组历史表
CREATE TABLE eqp_group_his (
    id INT AUTO_INCREMENT PRIMARY KEY COMMENT '历史记录编号',
    eqp_group_id VARCHAR(100) COMMENT '设备组编号',
    eqp_group_type VARCHAR(100) NOT NULL COMMENT '设备组类型',
    eqp_group_description TEXT COMMENT '设备组说明',
    factory_id INT COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 插入设备组历史记录表数据
INSERT INTO eqp_group_his (eqp_group_id, eqp_group_type, eqp_group_description, factory_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('AOI', 'AOI', 'Inspection', 4, NULL, NULL, NULL, NOW(), NULL),
('AOI', 'AOI', 'Inspection', 4, NULL, NULL, NULL, NOW(), NULL),
('AOI', 'AOI', 'Inspection', 4, NULL, NULL, NULL, NOW(), NULL),
('AQM', 'AQM', 'Measurement', 4, NULL, NULL, NULL, NOW(), NULL);

-- 插入设备表数据
INSERT INTO eqps (eqp_id, eqp_type, eqp_detail_type, eqp_description, eqp_group_id, parent_eqp_id, eqp_level, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('ATE0-0001', 'Test', 'Test', 'LPDDR分选机', 'ATE', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0001-01', 'Test', 'Test', NULL, 'ATE', 'ATE0-0001', 'SUB', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0001-02', 'Test', 'Test', NULL, 'ATE', 'ATE0-0001', 'SUB', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0002', 'Test', 'Test', 'LPDDR分选机', 'ATE', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL),
('DBA1-0001', 'Process', 'DB', 'DB固晶机', 'DB', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL);

-- 添加外键约束
ALTER TABLE eqp_group
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

ALTER TABLE eqps
ADD FOREIGN KEY (parent_eqp_id) REFERENCES eqps(eqp_id);

ALTER TABLE eqps
ADD FOREIGN KEY (eqp_group_id) REFERENCES eqp_group(eqp_group_id);

ALTER TABLE ports
ADD FOREIGN KEY (eqp_id) REFERENCES eqps(eqp_id);

-- 重新开启主键检查
SET FOREIGN_KEY_CHECKS = 1;