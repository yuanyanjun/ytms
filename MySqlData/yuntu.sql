-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        5.6.11 - MySQL Community Server (GPL)
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 导出 yuntu 的数据库结构
CREATE DATABASE IF NOT EXISTS `yuntu` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `yuntu`;


-- 导出  表 yuntu.admins 结构
CREATE TABLE IF NOT EXISTS `admins` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `name` varchar(50) NOT NULL,
  `sex` varchar(10) NOT NULL DEFAULT '男',
  `phone` varchar(20) NOT NULL,
  `img` varchar(255) DEFAULT NULL,
  `wxchat` varchar(100) DEFAULT NULL,
  `openid` varchar(255) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `created_name` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统用户表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.append_types 结构
CREATE TABLE IF NOT EXISTS `append_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `sort` int(11) NOT NULL DEFAULT '1',
  `created_name` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `is_divide` tinyint(4) DEFAULT '0' COMMENT '是否算入分成',
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='附加项目类型';

-- 数据导出被取消选择。


-- 导出  表 yuntu.configs 结构
CREATE TABLE IF NOT EXISTS `configs` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `info` text NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='全局配置';

-- 数据导出被取消选择。


-- 导出  表 yuntu.document_types 结构
CREATE TABLE IF NOT EXISTS `document_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `sort` int(11) NOT NULL DEFAULT '1',
  `created_name` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='证件类型';

-- 数据导出被取消选择。


-- 导出  表 yuntu.public_fees 结构
CREATE TABLE IF NOT EXISTS `public_fees` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `property_fee` decimal(9,2) DEFAULT '0.00' COMMENT '物业费',
  `water_fee` decimal(9,2) DEFAULT '0.00' COMMENT '水费',
  `electricity_fee` decimal(9,2) DEFAULT '0.00' COMMENT '电费',
  `gas_fee` decimal(9,2) DEFAULT '0.00' COMMENT '气费',
  `created_name` varchar(255) DEFAULT NULL,
  `date_time` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房间图片类型';

-- 数据导出被取消选择。


-- 导出  表 yuntu.rooms 结构
CREATE TABLE IF NOT EXISTS `rooms` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `user_id` bigint(20) NOT NULL,
  `serial_no` varchar(255) NOT NULL,
  `room_no` varchar(255) DEFAULT NULL,
  `room_type_id` int(11) NOT NULL,
  `floor_num` int(11) DEFAULT NULL,
  `bed_num` int(11) NOT NULL DEFAULT '1',
  `control_status` int(11) NOT NULL DEFAULT '1' COMMENT '1闲,2控,3住',
  `created_name` varchar(255) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `area` float DEFAULT '1' COMMENT '面积',
  `discount_fee` decimal(9,2) DEFAULT '0.00' COMMENT '折扣费用',
  `base_fee` decimal(9,2) DEFAULT '100.00' COMMENT '基本房费',
  `loss_fee` decimal(9,2) DEFAULT '50.00' COMMENT '固定损耗',
  `property_fee` decimal(9,2) DEFAULT '0.00' COMMENT '物业费',
  `platform_rate` float DEFAULT '0' COMMENT '平台扣点',
  `min_fee` decimal(9,2) DEFAULT '0.00' COMMENT '保底收入',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房间';

-- 数据导出被取消选择。


-- 导出  表 yuntu.room_images 结构
CREATE TABLE IF NOT EXISTS `room_images` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `url` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房间图片';

-- 数据导出被取消选择。


-- 导出  表 yuntu.room_prices 结构
CREATE TABLE IF NOT EXISTS `room_prices` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `price` decimal(9,2) DEFAULT '0.00',
  `created_name` varchar(100) NOT NULL,
  `day_time` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房价';

-- 数据导出被取消选择。


-- 导出  表 yuntu.room_relation_tags 结构
CREATE TABLE IF NOT EXISTS `room_relation_tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `tag_id` bigint(20) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房间关联客房配置';

-- 数据导出被取消选择。


-- 导出  表 yuntu.room_tags 结构
CREATE TABLE IF NOT EXISTS `room_tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `url` varchar(255) DEFAULT NULL,
  `num` int(11) DEFAULT '0',
  `sort` int(11) DEFAULT '1',
  `created_name` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客房配置';

-- 数据导出被取消选择。


-- 导出  表 yuntu.room_types 结构
CREATE TABLE IF NOT EXISTS `room_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `sort` int(11) NOT NULL DEFAULT '1',
  `created_name` varchar(255) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房型类型';

-- 数据导出被取消选择。


-- 导出  表 yuntu.settle_accounts 结构
CREATE TABLE IF NOT EXISTS `settle_accounts` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `user_id` bigint(20) NOT NULL,
  `room_no` varchar(255) DEFAULT '',
  `base_fee` decimal(9,2) NOT NULL COMMENT '房费总计',
  `loss_fee` decimal(9,2) DEFAULT '0.00' COMMENT '固定损耗总计',
  `other_fee` decimal(9,2) DEFAULT '0.00' COMMENT '其他费用总计',
  `property_fee` decimal(9,2) DEFAULT '0.00' COMMENT '物业费',
  `water_fee` decimal(9,2) DEFAULT '0.00' COMMENT '水费',
  `electricity_fee` decimal(9,2) DEFAULT '0.00' COMMENT '电费',
  `gas_fee` decimal(9,2) DEFAULT '0.00' COMMENT '气费',
  `platform_fee` decimal(9,2) DEFAULT '0.00' COMMENT '平台扣点',
  `divide_fee` decimal(9,2) DEFAULT '0.00' COMMENT '分成',
  `total_money` decimal(9,2) DEFAULT '0.00' COMMENT '总金额',
  `real_money` decimal(9,2) DEFAULT '0.00' COMMENT '实际收入',
  `user_money` decimal(9,2) DEFAULT '0.00' COMMENT '业主收入',
  `diff_user_money` decimal(9,2) DEFAULT '0.00' COMMENT '补贴',
  `is_finished` tinyint(1) DEFAULT '0' COMMENT '是否已结算',
  `remark` varchar(1024) DEFAULT NULL,
  `created_name` varchar(255) DEFAULT NULL,
  `finished_at` timestamp NULL DEFAULT NULL COMMENT '结算日期',
  `date_time` timestamp NULL DEFAULT NULL COMMENT '结账月',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='结算';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_config 结构
CREATE TABLE IF NOT EXISTS `t_config` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Proportion` int(11) NOT NULL DEFAULT '0' COMMENT '分成比例   平台与业主的分成比例 4表示业主分成40%',
  `FixedLoss` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '固定损耗',
  `PlatformPoint` float NOT NULL DEFAULT '0' COMMENT '第三方平台扣点  0.15表示15%',
  `FloorEarnings` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '业主保底收益',
  `RoomCoverMaxNum` int(11) NOT NULL DEFAULT '0' COMMENT '客房可上传图片最大数量',
  `CreateBy` varchar(50) DEFAULT NULL COMMENT '配置创建人',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyBy` varchar(50) DEFAULT NULL COMMENT '配置最后修改人',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '配置最后修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统配置表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_month_settles 结构
CREATE TABLE IF NOT EXISTS `t_month_settles` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `datakey` varchar(50) NOT NULL COMMENT '结算月份 201804',
  `ower_id` bigint(20) NOT NULL COMMENT '业主id',
  `actual_amount` decimal(10,0) DEFAULT '0' COMMENT '业主实际分成金额  按分成比例计算 ',
  `sys_compensation_amount` decimal(10,0) DEFAULT '0' COMMENT '系统补差金额',
  `sys_compensation_model` decimal(10,0) DEFAULT '0' COMMENT '系统补差标准 如1800保底 此处存储就是1800',
  `createdate` datetime DEFAULT NULL COMMENT '创建日期',
  `createid` bigint(20) NOT NULL COMMENT '创建人id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='月结算表 通过业主的维度';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_orders 结构
CREATE TABLE IF NOT EXISTS `t_orders` (
  `id` bigint(20) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `OrderNo` varchar(50) NOT NULL COMMENT '订单编号',
  `CustomerName` varchar(50) NOT NULL COMMENT '客户姓名',
  `CustomerMobileNo` varchar(50) NOT NULL COMMENT '客户联系电话',
  `CardType` int(10) unsigned zerofill NOT NULL COMMENT '证件类型',
  `CardNo` varchar(50) NOT NULL COMMENT '证件号码',
  `EtaDate` datetime NOT NULL COMMENT '预抵时间',
  `DueoutDate` datetime NOT NULL COMMENT '预离时间',
  `OrderStatus` bit(1) NOT NULL COMMENT '订单状态 0预定 1入住  2结帐退房  3.结算 4取消预定',
  `OrderType` bit(1) NOT NULL COMMENT '订单类型  0普通 1会员 2 团购',
  `OrderAmount` decimal(10,2) NOT NULL COMMENT '订单总金额',
  `OrderDisCount` decimal(10,2) DEFAULT '0.00' COMMENT '订单折扣',
  `OrderRemark` varchar(1000) DEFAULT NULL COMMENT '订单备注',
  `CreateBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyBy` varchar(50) DEFAULT NULL COMMENT '最后修改人',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  PRIMARY KEY (`id`),
  KEY `orderno` (`OrderNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_order_products 结构
CREATE TABLE IF NOT EXISTS `t_order_products` (
  `Id` bigint(20) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `OrderNo` varchar(50) NOT NULL DEFAULT '0' COMMENT '订单编号',
  `DateKey` varchar(50) NOT NULL COMMENT '日期关键字，表示某个房间某天（算作一个商品）如:20180409',
  `RoomId` bigint(20) NOT NULL COMMENT '客房id',
  `RoomPrice` decimal(10,2) DEFAULT '0.00' COMMENT '客房价格',
  `RoomWastageAmount` decimal(10,2) DEFAULT '0.00' COMMENT '客房固定损耗',
  `PlatformPointAmount` decimal(10,2) DEFAULT '0.00' COMMENT '平台扣点金额  订单产生时，通过设置的扣点比例计算出的扣点金额',
  `Discount` decimal(10,2) unsigned DEFAULT '0.00' COMMENT '房价的折扣金额 此字段暂做保留',
  `IsSettle` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否结算 是否已经月结算',
  `SettleTime` datetime DEFAULT NULL COMMENT '结算日期',
  `SettleBy` varchar(50) DEFAULT NULL COMMENT '结算人',
  PRIMARY KEY (`Id`),
  KEY `room_id` (`RoomId`),
  KEY `datekey` (`DateKey`),
  KEY `OrderNo` (`OrderNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单产品表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.users 结构
CREATE TABLE IF NOT EXISTS `users` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `sex` varchar(10) NOT NULL DEFAULT '男',
  `id_card` varchar(50) DEFAULT NULL,
  `phone` varchar(20) NOT NULL,
  `wxchat` varchar(100) DEFAULT NULL,
  `openid` varchar(255) DEFAULT NULL,
  `img` varchar(255) DEFAULT NULL,
  `created_name` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `bank_name` varchar(100) NOT NULL,
  `bank_deposit` varchar(255) NOT NULL,
  `bank_account` varchar(255) NOT NULL,
  `room_num` int(11) NOT NULL DEFAULT '0',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_card` (`id_card`,`name`,`phone`,`wxchat`,`created_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='业主表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.user_reserves 结构
CREATE TABLE IF NOT EXISTS `user_reserves` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `room_id` bigint(20) NOT NULL,
  `reserve_no` varchar(100) NOT NULL COMMENT '预定号',
  `day_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '预定时间',
  `base_fee` decimal(9,2) DEFAULT '0.00' COMMENT '房费',
  `loss_fee` decimal(9,2) DEFAULT '0.00' COMMENT '固定损耗',
  `other_fee` decimal(9,2) DEFAULT '0.00' COMMENT '其他费用',
  `name` varchar(100) NOT NULL COMMENT '用户名称',
  `is_checked` tinyint(1) DEFAULT '0' COMMENT '是否已入住',
  `phone` varchar(20) DEFAULT NULL,
  `id_card` varchar(20) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `created_name` varchar(255) DEFAULT NULL,
  `finished_at` timestamp NULL DEFAULT NULL COMMENT '结账时间',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `cash_fee` decimal(9,2) DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预定';

-- 数据导出被取消选择。
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
