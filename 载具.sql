-- 关闭主键检查
SET FOREIGN_KEY_CHECKS = 0;

-- 删除原有表（如果存在）
DROP TABLE IF EXISTS carriers;
DROP TABLE IF EXISTS durables;

-- 创建耐用品表
CREATE TABLE IF NOT EXISTS durables (
    durable_id VARCHAR(50) PRIMARY KEY COMMENT '耐用品规格号',
    spec_description VARCHAR(100) NOT NULL COMMENT '耐用品规格说明',
    durable_type VARCHAR(50) NOT NULL COMMENT '耐用品类型',
    durable_detail_type VARCHAR(50) NOT NULL COMMENT '耐用品详细类型',
    durable_color VARCHAR(50) COMMENT '耐用品颜色',
    durable_qty INT DEFAULT 0 COMMENT '耐用品数量',
    expected_life INT COMMENT '预期寿命(次)',
    max_usage INT COMMENT '最大使用次数',
    max_usage_days INT COMMENT '最大使用天数',
    post_clean_max_usage INT COMMENT '清洗后最大使用次数',
    post_clean_max_days INT COMMENT '清洗后最长使用天数'
) COMMENT '耐用品信息表';

-- 创建载具表（新增 `capacity_status` 字段）
CREATE TABLE carriers (
    carrier_no VARCHAR(50) PRIMARY KEY COMMENT '载具编号',
    carrier_type VARCHAR(50) NOT NULL COMMENT '载具类型',
    carrier_detail_type VARCHAR(50) NOT NULL COMMENT '详细类型',
    durable_id VARCHAR(50) COMMENT '耐用品规格号',
    equipment_id VARCHAR(100) COMMENT '关联设备ID',
    port_id VARCHAR(100) COMMENT '关联端口ID',
    carrier_status VARCHAR(20) DEFAULT 'Released' COMMENT '载具状态',
    cleaning_status VARCHAR(20) DEFAULT 'Clean' COMMENT '清洗状态',
    lock_status VARCHAR(20) DEFAULT 'NotOnHold' COMMENT '锁定状态',
    batch_capacity INT DEFAULT 0 COMMENT '批次数量',
    current_qty INT DEFAULT 0 COMMENT '当前数量',
    capacity_status VARCHAR(20) DEFAULT 'Normal' COMMENT '容量状态',
    location VARCHAR(50) DEFAULT 'Bank' COMMENT '位置号',
    last_maintenance_date DATE COMMENT '最后维护日期',
    FOREIGN KEY (equipment_id) REFERENCES eqp(eqp_id),
    FOREIGN KEY (port_id) REFERENCES port(port_id),
    FOREIGN KEY (durable_id) REFERENCES durables(durable_id)
) COMMENT '载具信息表';

-- 插入耐用品数据
INSERT INTO durables (
    durable_id, spec_description, durable_type, durable_detail_type, 
    durable_color, durable_qty, expected_life, max_usage, max_usage_days, 
    post_clean_max_usage, post_clean_max_days
) VALUES 
('DUR-001', '标准载具规格', 'Magazine', '标准', '银色', 50, 1000, 1200, 365, 1000, 300),
('DUR-002', '高温载具规格', 'HighTemp', '耐高温', '红色', 30, 500, 600, 200, 400, 150),
('DUR-003', '防静电载具', 'ESD', '防静电', '黑色', 40, 800, 1000, 300, 700, 250);

-- 插入载具数据（新增 `capacity_status`）
INSERT INTO carriers (
    carrier_no, carrier_type, carrier_detail_type, durable_id, 
    equipment_id, port_id, carrier_status, cleaning_status, 
    lock_status, batch_capacity, current_qty, capacity_status, location, last_maintenance_date
) VALUES 
('CA-0001', 'Magazine', '2FUDPZJ', 'DUR-001', 
 'ATE0-0001', 'P001', 'Released', 'Clean', 
 'NotOnHold', 10, 0, 'Normal', 'Bank', '2023-04-01'),

('CA-0002', 'HighTemp', 'HT-001', 'DUR-002',
 'DBA1-0001', 'P002', 'InUse', 'Clean', 
 'NotOnHold', 15, 5, 'HighLoad', 'Line', '2023-05-15'),

('CA-0003', 'ESD', 'ESD-001', 'DUR-003',
 'ATE0-0002', 'P003', 'Maintenance', 'Dirty', 
 'OnHold', 20, 0, 'LowLoad', 'RepairArea', '2023-06-01'),

('CA-0004', 'ESD', 'ESD-002', 'DUR-003',
 'ATE0-0003', 'P004', 'Maintenance', 'Dirty', 
 'OnHold', 20, 0, 'Normal', 'RepairArea', '2023-06-10');

-- 重新开启主键检查
SET FOREIGN_KEY_CHECKS = 1;
