-- 关闭主键检查
SET FOREIGN_KEY_CHECKS = 0;

-- 删除原有表（如果存在）
DROP TABLE IF EXISTS carriers;
DROP TABLE IF EXISTS durables;

-- 创建耐用品表
CREATE TABLE IF NOT EXISTS durables (
    durable_id VARCHAR(50) PRIMARY KEY COMMENT '耐用品ID',
    spec_description VARCHAR(100) NOT NULL COMMENT '规格说明',
    durable_type VARCHAR(50) NOT NULL COMMENT '耐用品类型',
    expected_life INT COMMENT '预期寿命(次)',
    current_usage INT DEFAULT 0 COMMENT '当前使用次数',
    purchase_date DATE COMMENT '采购日期',
    supplier VARCHAR(100) COMMENT '供应商'
) COMMENT '耐用品信息表';

-- 创建载具表
CREATE TABLE carriers (
    carrier_no VARCHAR(50) PRIMARY KEY COMMENT '载具编号',
    carrier_type VARCHAR(50) NOT NULL COMMENT '载具类型',
    carrier_detail_type VARCHAR(50) NOT NULL COMMENT '详细类型',
    durable_id VARCHAR(50) COMMENT '耐用品ID',
    equipment_id VARCHAR(100) COMMENT '关联设备ID',
    port_id VARCHAR(100) COMMENT '关联端口ID',
    handling_status VARCHAR(20) DEFAULT 'Released' COMMENT '搬运状态',
    cleaning_status VARCHAR(20) DEFAULT 'Clean' COMMENT '清洗状态',
    lock_status VARCHAR(20) DEFAULT 'NotOnHold' COMMENT '锁定状态',
    batch_capacity INT NOT NULL COMMENT '批次容量',
    current_qty INT DEFAULT 0 COMMENT '当前数量',
    location VARCHAR(50) COMMENT '当前位置',
    last_maintenance_date DATE COMMENT '最后维护日期',
    FOREIGN KEY (equipment_id) REFERENCES eqp(eqp_id),
    FOREIGN KEY (port_id) REFERENCES port(port_id),
    FOREIGN KEY (durable_id) REFERENCES durables(durable_id)
) COMMENT '载具信息表';

-- 插入耐用品数据
INSERT INTO durables (durable_id, spec_description, durable_type, expected_life)
VALUES 
('DUR-001', '标准载具规格', 'Magazine', 1000),
('DUR-002', '高温载具规格', 'HighTemp', 500),
('DUR-003', '防静电载具', 'ESD', 800);

-- 插入载具数据
INSERT INTO carriers (
    carrier_no, carrier_type, carrier_detail_type, durable_id, 
    equipment_id, port_id, handling_status, cleaning_status, 
    lock_status, batch_capacity, current_qty, location
) VALUES (
    'CA-0001', 'Magazine', '2FUDPZJ', 'DUR-001',
    'ATE0-0001', 'P001', 'Released', 'Clean',
    'NotOnHold', 10, 0, 'Bank1'
);
INSERT INTO carriers (
    carrier_no, carrier_type, carrier_detail_type, durable_id,
    equipment_id, port_id, handling_status, cleaning_status,
    lock_status, batch_capacity, current_qty, location, last_maintenance_date
) VALUES (
    'CA-0002', 'HighTemp', 'HT-001', 'DUR-002',
    'DBA1-0001', 'P002', 'InUse', 'Clean',
    'NotOnHold', 15, 5, 'Line1', '2023-05-15'
);
INSERT INTO carriers (
    carrier_no, carrier_type, carrier_detail_type, durable_id,
    equipment_id, handling_status, cleaning_status,
    lock_status, batch_capacity, current_qty, location
) VALUES (
    'CA-0003', 'ESD', 'ESD-001', 'DUR-003',
    'ATE0-0002', 'Maintenance', 'Dirty',
    'OnHold', 20, 0, 'RepairArea'
);

-- 重新开启主键检查
SET FOREIGN_KEY_CHECKS = 1;