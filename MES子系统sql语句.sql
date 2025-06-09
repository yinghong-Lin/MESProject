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
DROP TABLE IF EXISTS eqp;
DROP TABLE IF EXISTS port;
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
    factory_id VARCHAR(100) PRIMARY KEY COMMENT '工厂编号',
    factory_type VARCHAR(100) COMMENT '工厂类型',
    factory_description TEXT COMMENT '工厂描述',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    event_type VARCHAR(50) COMMENT '事件类型',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间'
);

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

-- 创建设备组表
CREATE TABLE eqp_group (
    eqp_group_id VARCHAR(100) PRIMARY KEY COMMENT '设备组编号',
    eqp_group_type VARCHAR(100) NOT NULL COMMENT '设备组类型',
    eqp_group_description TEXT COMMENT '设备组说明',
    factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 创建设备表
CREATE TABLE eqp (
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
CREATE TABLE port (
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
    factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
);

-- 插入 factories 表数据
INSERT INTO factories (factory_id, factory_type, factory_description, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, 'BW', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create'),
(2, 'DMW', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create'),
(3, 'HONSUN', NULL, NULL, NULL, '2025-04-22 10:00:00', '2025-04-22 10:00:00', 'create');

-- 插入 menus 表数据
INSERT INTO menus (menu_id, menu_name, function_id, menu_description, parent_menu_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, '生产计划', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(2, '工单管理', 'p', NULL, 1, NULL, NULL, NULL, NOW(), NULL),
(3, '创建工单', 'c', NULL, 2, NULL, NULL, NULL, NOW(), NULL),
(4, '取消创建工单', 'c', NULL, 2, NULL, NULL, NULL, NOW(), NULL),
(5, '投工单', 'c', NULL, 2, NULL, NULL, NULL, NOW(), NULL),

(6, '批次管理', 'p', NULL, 1, NULL, NULL, NULL, NOW(), NULL),
(7, '创建批次', 'c', NULL, 6, NULL, NULL, NULL, NOW(), NULL),
(8, '取消创建批次', 'c', NULL, 6, NULL, NULL, NULL, NOW(), NULL),
(9, '投产批次', 'c', NULL, 6, NULL, NULL, NULL, NOW(), NULL),
(10, '取消投产批次', 'c', NULL, 6, NULL, NULL, NULL, NOW(), NULL),

(11, '在制品', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(12, '进出站', 'p', NULL, 11, NULL, NULL, NULL, NOW(), NULL),
(13, '单批次进站', 'c', NULL, 12, NULL, NULL, NULL, NOW(), NULL),
(14, '单批次出战', 'c', NULL, 12, NULL, NULL, NULL, NOW(), NULL),
(15, '跳工站', 'c', NULL, 11, NULL, NULL, NULL, NOW(), NULL),
(16, '生产返修', 'c', NULL, 11, NULL, NULL, NULL, NOW(), NULL),

(17, '载具', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(18, '载具主页面', 'c', NULL, 17, NULL, NULL, NULL, NOW(), NULL),
(19, '创建载具', 'c', NULL, 17, NULL, NULL, NULL, NOW(), NULL),

(20, '物料', 'p', NULL, 0, NULL, NULL, NULL, NOW(), NULL),
(21, '创建物料', 'c', NULL, 20, NULL, NULL, NULL, NOW(), NULL),
(22, '上料', 'c', NULL, 20, NULL, NULL, NULL, NOW(), NULL),
(23, '下物', 'c', NULL, 20, NULL, NULL, NULL, NOW(), NULL);


-- 插入 permission_menu 表数据
INSERT INTO permission_menu (id, permission_id, menu_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
(1, 'BW_MDM', 1, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(2, 'BW_MDM', 2, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(3, 'BW_MDM', 3, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(4, 'BW_MDM', 4, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(5, 'BW_MDM', 5, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(6, 'BW_MDM', 6, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(7, 'BW_MDM', 7, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(8, 'BW_MDM', 8, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(9, 'BW_MDM', 9, NULL, NULL, NULL, '2025-04-22 09:56:17', NULL),
(10, 'BW_MDM', 10, NULL, NULL, NULL, '2025-04-29 09:14:37', NULL),
(11, 'BW_MDM', 11, NULL, NULL, NULL, '2025-04-29 10:55:29', NULL),
(12, 'BW_MDM', 12, NULL, NULL, NULL, '2025-04-29 10:55:41', NULL),
(13, 'BW_MDM', 13, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL),
(14, 'BW_MDM', 14, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL),
(15, 'BW_MDM', 15, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL),
(16, 'BW_MDM', 16, NULL, NULL, NULL, '2025-04-29 09:14:37', NULL),
(17, 'BW_MDM', 17, NULL, NULL, NULL, '2025-04-29 10:55:29', NULL),
(18, 'BW_MDM', 18, NULL, NULL, NULL, '2025-04-29 10:55:41', NULL),
(19, 'BW_MDM', 19, NULL, NULL, NULL, '2025-04-29 10:55:41', NULL),
(20, 'BW_MDM', 20, NULL, NULL, NULL, '2025-04-29 10:55:41', NULL),
(21, 'BW_MDM', 21, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL),
(22, 'BW_MDM', 22, NULL, NULL, NULL, '2025-04-29 10:55:51', NULL),
(23, 'BW_MDM', 23, NULL, NULL, NULL, '2025-04-29 09:14:37', NULL);


-- 插入 permissions 表数据
INSERT INTO permissions (permission_id, permission_name, permission_description, permission_type, system_id, event_user, event_remark, edit_time, create_time, event_type) VALUES
('BW_MDM', 'MDM Administrator', NULL, 'MENU', 'MDM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL),
('DMW_MDM', 'Test', 'Test DMW', 'TEST', 'TEST_SYSTEM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL),
('HONSUN_MDM', 'Test HONSUN', '这是一个测试MDM权限', 'TEST', 'MDM', NULL, NULL, NULL, CURRENT_TIMESTAMP, NULL);

-- 插入设备组表数据
INSERT INTO eqp_group (eqp_group_id, eqp_group_type, eqp_group_description, factory_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('AOI', 'Inspection', 'AOI', 4, NULL, NULL, NULL, NOW(), NULL),
('AQM', 'Measurement', 'AQM', 4, NULL, NULL, NULL, NOW(), NULL),
('ATE', 'Test', 'ATE', 4, NULL, NULL, NULL, NOW(), NULL),
('DB', 'Process', '贴片', 4, NULL, NULL, NULL, NOW(), NULL),
('WB', 'Process', '键合', 3, NULL, NULL, NULL, NOW(), NULL);

-- 插入端口表（Port）数据
INSERT INTO port (port_id, port_type, port_detail_type, eqp_id, event_type)
VALUES 
('P001', 'Input', 'Serial', 'ATE0-0001', 'create'),
('P002', 'Output', 'Ethernet', 'DBA1-0001', 'create');

-- 插入设备组历史记录表数据
INSERT INTO eqp_group_his (eqp_group_id, eqp_group_type, eqp_group_description, factory_id, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('AOI', 'AOI', 'Inspection', 1, NULL, NULL, NULL, NOW(), NULL),
('AOI', 'AOI', 'Inspection', 1, NULL, NULL, NULL, NOW(), NULL),
('AOI', 'AOI', 'Inspection', 1, NULL, NULL, NULL, NOW(), NULL),
('AQM', 'AQM', 'Measurement', 1, NULL, NULL, NULL, NOW(), NULL);

-- 插入设备表数据
INSERT INTO eqp (eqp_id, eqp_type, eqp_detail_type, eqp_description, eqp_group_id, parent_eqp_id, eqp_level, event_user, event_remark, edit_time, create_time, event_type)
VALUES 
('ATE0-0001', 'Test', 'Test', 'LPDDR分选机', 'ATE', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0001-01', 'Test', 'Test', NULL, 'ATE', 'ATE0-0001', 'SUB', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0001-02', 'Test', 'Test', NULL, 'ATE', 'ATE0-0001', 'SUB', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0002', 'Test', 'Test', 'LPDDR分选机', 'ATE', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL),
('ATE0-0002-01', 'Test', 'Test', NULL, 'ATE', 'ATE0-0002', 'SUB', NULL, NULL, NULL, NOW(), NULL),
('DBA1-0001', 'Process', 'DB', 'DB固晶机', 'DB', NULL, 'MAIN', NULL, NULL, NULL, NOW(), NULL);

-- 添加外键约束
ALTER TABLE eqp_group
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

ALTER TABLE eqp
ADD FOREIGN KEY (parent_eqp_id) REFERENCES eqp(eqp_id);

ALTER TABLE eqp
ADD FOREIGN KEY (eqp_group_id) REFERENCES eqp_group(eqp_group_id);

ALTER TABLE port
ADD FOREIGN KEY (eqp_id) REFERENCES eqp(eqp_id);

DROP TABLE IF EXISTS product_group;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS opers;
DROP TABLE IF EXISTS flows;
DROP TABLE IF EXISTS flow_oper;
DROP TABLE IF EXISTS prps;
DROP TABLE IF EXISTS prp_flow;

-- 产品组与产品
CREATE TABLE product_group (
    product_group_id VARCHAR(100) PRIMARY KEY COMMENT '产品组编号',
    product_group_description TEXT COMMENT '产品组说明',
		factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) ;
ALTER TABLE product_group
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

CREATE TABLE products (
    product_id VARCHAR(100) PRIMARY KEY COMMENT '产品编号',
    product_type VARCHAR(100) NOT NULL COMMENT '产品类型',
		product_detail_type VARCHAR(100) NOT NULL COMMENT '详细产品类型',
    product_description TEXT COMMENT '产品说明',		
		product_state VARCHAR(100) COMMENT '产品状态',
		unit  VARCHAR(100) COMMENT '单位',
		bom_id  VARCHAR(100) COMMENT 'BOM编号',
		bom_version  VARCHAR(20) COMMENT 'BOM版本',
		product_group_id VARCHAR(100)  COMMENT '产品组编号',
		factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) ;

ALTER TABLE products
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

ALTER TABLE products
ADD FOREIGN KEY (product_group_id) REFERENCES product_group(product_group_id);

-- 工站
CREATE TABLE opers (
		id INT AUTO_INCREMENT PRIMARY KEY COMMENT '记录编号',
    oper_id VARCHAR(100)  COMMENT '工站号',
		oper_version VARCHAR(20) COMMENT '工站版本',
		is_active TINYINT(1) COMMENT '是否激活',
		oper_description TEXT COMMENT '工站说明',		
		release_state VARCHAR(100) COMMENT '发行状态',
    oper_type VARCHAR(100)  COMMENT '工站类型',
		oper_detail_type VARCHAR(100)  COMMENT '工站详细类型',
		is_trackin TINYINT(1) COMMENT '是否TrackIn',
		scan_carrier_trackin   TINYINT(1) COMMENT '进站扫描载具',
		scan_carrier_trackout  TINYINT(1) COMMENT '出站扫描载具',	
		oper_hour  int COMMENT '标准工时(分)',
		factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) ;
ALTER TABLE opers
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

-- 工艺流程
CREATE TABLE flows (
		id INT AUTO_INCREMENT PRIMARY KEY COMMENT '记录编号',
    flow_id VARCHAR(100) COMMENT '工艺流程号',
		flow_version VARCHAR(20) COMMENT '工艺流程版本',
		is_active TINYINT(1) COMMENT '是否激活',
		flow_description TEXT COMMENT '工艺流程描述',		
		release_state VARCHAR(100) COMMENT '发行状态',
    flow_type VARCHAR(100)  COMMENT '工艺流程类型',
		flow_detail_type VARCHAR(100)  COMMENT '详细类型',
		factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) ;
ALTER TABLE flows
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

-- 工艺路线
CREATE TABLE flow_oper (
		id INT AUTO_INCREMENT PRIMARY KEY COMMENT '记录编号',
   		f_id int COMMENT '工艺流程id',
		op_id int COMMENT '工站id',   
		op_seq int COMMENT '工站序列'
) ;
ALTER TABLE flow_oper
ADD FOREIGN KEY (f_id) REFERENCES flows(id);
ALTER TABLE flow_oper
ADD FOREIGN KEY (op_id) REFERENCES opers(id);

-- 工艺包
CREATE TABLE prps (
		id INT AUTO_INCREMENT PRIMARY KEY COMMENT '记录编号',
    product_id VARCHAR(100)  COMMENT '产品编号',
		prp_version VARCHAR(20) COMMENT '工艺包版本',
		is_active TINYINT(1) COMMENT '是否激活',
		prp_description TEXT COMMENT '工艺包说明',		
		release_state VARCHAR(100) COMMENT '发行状态',
		main_flow VARCHAR(100)  COMMENT '主工艺流程',
    prp_type VARCHAR(100)  COMMENT '工艺包类型',
		flow_prp_type VARCHAR(100) COMMENT '流程工艺包类型',
		factory_id VARCHAR(100) COMMENT '关联的工厂编号',
    event_user VARCHAR(100) COMMENT '事件用户',
    event_remark TEXT COMMENT '事件备注',
    edit_time DATETIME COMMENT '编辑发生时间',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建发生时间',
    event_type VARCHAR(50) COMMENT '事件'
) ;
ALTER TABLE prps
ADD FOREIGN KEY (product_id) REFERENCES products(product_id);
ALTER TABLE prps
ADD FOREIGN KEY (factory_id) REFERENCES factories(factory_id);

-- 工艺包绑定
CREATE TABLE prp_flow (
		id INT AUTO_INCREMENT PRIMARY KEY COMMENT '记录编号',
    prp_id int COMMENT '工艺包id',
		f_id int COMMENT '工艺流程id'
) ;
ALTER TABLE prp_flow
ADD FOREIGN KEY (f_id) REFERENCES flows(id);
ALTER TABLE prp_flow
ADD FOREIGN KEY (prp_id) REFERENCES prps(id);

-- 插入产品组表（product_group)数据
INSERT INTO product_group (product_group_id, product_group_description, factory_id, event_type)
VALUES 
('PG001', '半导体封装产品组', '1', 'create'),
('PG002', '消费电子产品组', '1', 'create');

-- 插入 产品表（products）数据
INSERT INTO products (product_id, product_type, product_detail_type, product_group_id, factory_id, event_type)
VALUES 
('P001', '芯片', '封装芯片', 'PG001', '1', 'create'),
('P002', '传感器', '光学传感器', 'PG002', '1', 'create');

-- 插入工站表（opers）数据
INSERT INTO opers (oper_id, oper_version, is_active, factory_id, event_type)
VALUES 
('OP001', 'V1', 1, '1', 'create'),
('OP002', 'V2', 1, '1', 'create');


-- 插入工艺流程表（flows）数据
INSERT INTO flows (flow_id, flow_version, is_active, factory_id, event_type)
VALUES 
('FLOW001', 'V1.0', 0, '1', 'create'),
('FLOW002', 'V2.0', 1, '1', 'create');

-- 插入工艺路线表（flow_oper）数据
INSERT INTO flow_oper (f_id, op_id, op_seq)
VALUES 
(1, 1, 1),  -- 假设 flows.id=1, opers.id=1
(1, 2, 2),
(2, 1, 1);

-- 插入工艺包表（prps）数据
INSERT INTO prps (product_id, prp_version, is_active, factory_id, event_type)
VALUES 
('P001', 'V1', 1, '1', 'create'),
('P002', 'V2', 1, '1', 'create');

-- 插入工艺包绑定表（prp_flow）数据
INSERT INTO prp_flow (prp_id, f_id)
VALUES 
(1, 1),  -- 假设 prps.id=1, flows.id=1
(2, 2);

-- 重新开启主键检查
SET FOREIGN_KEY_CHECKS = 1;