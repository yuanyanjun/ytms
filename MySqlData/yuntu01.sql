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


-- 导出  表 yuntu.t_configs 结构
CREATE TABLE IF NOT EXISTS `t_configs` (
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


-- 导出  表 yuntu.t_room_checkout_settles 结构
CREATE TABLE IF NOT EXISTS `t_room_checkout_settles` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `RecordId` bigint(20) NOT NULL COMMENT '记录ID',
  `RoomId` bigint(20) NOT NULL COMMENT '房价ID ',
  `Year` int(11) NOT NULL COMMENT '年',
  `Month` int(11) NOT NULL COMMENT '月',
  `TotalAmount` decimal(10,2) NOT NULL COMMENT '入住产生总收入',
  `WastageAmount` decimal(10,2) NOT NULL COMMENT '总的固定损耗',
  `ExtraFee` decimal(10,2) NOT NULL COMMENT '附加费用',
  `ThirdFee` decimal(10,2) NOT NULL COMMENT '第三方平台费用',
  `ActualAmount` decimal(10,2) NOT NULL COMMENT '实际盈利 = 总收入 - 固定损耗 - 第三方费用',
  `CreateBy` varchar(50) NOT NULL COMMENT '创建人',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `RecordId` (`RecordId`),
  KEY `RoomId` (`RoomId`),
  KEY `Year` (`Year`),
  KEY `Month` (`Month`),
  KEY `Year_Month` (`Year`,`Month`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='退房结算表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_room_consumed_records 结构
CREATE TABLE IF NOT EXISTS `t_room_consumed_records` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `RecordId` bigint(20) NOT NULL COMMENT '入住记录ID',
  `ItemKey` varchar(50) DEFAULT NULL COMMENT '消费记录key 如 20180510',
  `ItemDesc` varchar(100) DEFAULT NULL COMMENT '消费记录描述',
  `Year` int(11) NOT NULL COMMENT '消费年',
  `Month` int(11) NOT NULL COMMENT '消费月',
  `Day` int(11) NOT NULL COMMENT '消费日',
  `Monetary` decimal(10,2) NOT NULL COMMENT '消费金额',
  `WastageFee` decimal(10,2) NOT NULL COMMENT '固定损耗',
  `ExtraFee` decimal(10,2) NOT NULL COMMENT '附加费用',
  PRIMARY KEY (`Id`),
  KEY `Year` (`Year`),
  KEY `Month` (`Month`),
  KEY `Day` (`Day`),
  KEY `RecordId` (`RecordId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='入住消费记录表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_room_fixedcharge 结构
CREATE TABLE IF NOT EXISTS `t_room_fixedcharge` (
  `RoomId` bigint(20) NOT NULL COMMENT '客房ID',
  `Year` int(11) NOT NULL COMMENT '年',
  `Month` int(11) NOT NULL COMMENT '月',
  `PropertyFee` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '物业费',
  `WaterFee` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '水费',
  `PowerFee` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '电费',
  `GasFee` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT '燃气费',
  `CreateBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`RoomId`,`Year`,`Month`),
  KEY `Year_Month` (`Year`,`Month`),
  KEY `RoomId` (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客房固定开支 物业、水电气费';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_room_owner_month_settles 结构
CREATE TABLE IF NOT EXISTS `t_room_owner_month_settles` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL COMMENT '结算年',
  `Month` int(11) NOT NULL COMMENT '结算月',
  `OwerId` bigint(20) NOT NULL COMMENT '业主id',
  `ActualAmount` decimal(10,2) DEFAULT '0.00' COMMENT '业主实际分成金额  按分成比例计算 ',
  `CompensationAmount` decimal(10,2) DEFAULT '0.00' COMMENT '系统补差金额',
  `FloorAmount` decimal(10,2) DEFAULT '0.00' COMMENT '系统补差标准 如1800保底 此处存储就是1800',
  `SeparatePercent` decimal(10,2) DEFAULT '0.00' COMMENT '分成比例 0.35',
  `CreateBy` bigint(20) NOT NULL COMMENT '创建人id',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建日期',
  PRIMARY KEY (`Id`),
  KEY `Year_Month` (`Year`,`Month`),
  KEY `OwerId` (`OwerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='业主月结算表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_room_records 结构
CREATE TABLE IF NOT EXISTS `t_room_records` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) DEFAULT NULL COMMENT '联系人名称',
  `UserPhone` varchar(50) DEFAULT NULL COMMENT '联系人电话',
  `CardType` int(11) DEFAULT NULL COMMENT '证件类型',
  `CardNo` varchar(50) DEFAULT NULL COMMENT '证件号码',
  `ArrivingTime` datetime DEFAULT NULL COMMENT '（预抵/入住）时间',
  `LeavingTime` datetime DEFAULT NULL COMMENT '预离时间',
  `ExpiredTime` datetime DEFAULT NULL COMMENT '预定状态下过期时间',
  `Days` int(11) DEFAULT NULL COMMENT '（预定/入住）天数',
  `RoomId` bigint(20) DEFAULT NULL COMMENT '房间ID',
  `RoomPrice` decimal(10,2) DEFAULT NULL COMMENT '房价',
  `Status` bit(1) DEFAULT b'0' COMMENT '记录状态 0：预定  1：入住  2：退房',
  `CreateBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间',
  `IsDeleted` bit(1) DEFAULT b'0' COMMENT '是否删除 只有预定状态下，可以删除',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预定/入住记录表';

-- 数据导出被取消选择。


-- 导出  表 yuntu.t_room_reserve_items 结构
CREATE TABLE IF NOT EXISTS `t_room_reserve_items` (
  `RecordId` bigint(20) NOT NULL,
  `RoomId` bigint(20) NOT NULL COMMENT '房间ID',
  `ItemKey` varchar(50) NOT NULL COMMENT '项目key 如：20180512',
  `Year` int(11) NOT NULL COMMENT '预定年',
  `Month` int(11) NOT NULL COMMENT '预定月',
  `Day` int(11) NOT NULL COMMENT '预定日',
  `RoomPrice` decimal(10,2) DEFAULT NULL COMMENT '预定房价',
  PRIMARY KEY (`RecordId`,`RoomId`,`Year`,`Month`,`Day`),
  KEY `Year` (`Year`),
  KEY `Month` (`Month`),
  KEY `Day` (`Day`),
  KEY `RoomId` (`RoomId`),
  KEY `RecordId` (`RecordId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预定项目表';

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
