CREATE TABLE `test`.`emergency_contact` ( 
    `location_name` VARCHAR(100) NOT NULL , 
    `region_code` INT(3) NOT NULL , 
    `contact_number` INT(15) NOT NULL , 
    `lat` DOUBLE NOT NULL , 
    `longi` DOUBLE NOT NULL ,
    `desc` TEXT NOT NULL ,
    primary key(region_code , contact_number)
) ENGINE = MyISAM;

CREATE TABLE `test`.`sos_message` ( 
    `id` VARCHAR(100) NOT NULL , 
    `email` VARCHAR(100) NOT NULL , 
    `lat` DOUBLE NOT NULL , 
    `long` DOUBLE  NOT NULL ,
    `initialisationDate` DATETIME NOT NULL,
    `message` TEXT NOT NULL,
    `is_resloved` BOOLEAN NOT NULL,
    `last_update` DATETIME NOT NULL,  
    primary key(uuid)
) ENGINE = MyISAM;

CREATE TABLE `test`.`user` (
    `email` VARCHAR(100) NOT NULL , 
    `name` VARCHAR(100) NOT NULL ,
    `contact_num` int(15) ,
    `region_code` int(3) ,
    `is_admin` BOOLEAN NOT NULL ,
    `is_male` BOOLEAN NOT NULL ,
    `lat` DOUBLE ,
    `longi` DOUBLE ,
    primary key(email)
) ENGINE = MyISAM;

CREATE TABLE `test`.`user_reg` (
    `email` VARCHAR(100) NOT NULL ,
    `reg_id` VARCHAR(100) NOT NULL ,
    primary key(email , reg_id) ,
    FOREIGN KEY (email) REFERENCES user(email)
        ON UPDATE CASCADE
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_alert_response` (
    `modified` VARCHAR(100) NOT NULL ,
    `globals` VARCHAR(100) NOT NULL ,
    `regions` VARCHAR(100) NOT NULL ,
    `countires` VARCHAR(100) NOT NULL ,
    primary key(modified)
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_country_alert` (
    `modified` VARCHAR(100) NOT NULL ,
    `country` VARCHAR(100) NOT NULL ,
    `lang` VARCHAR(50) NOT NULL ,
    `name` VARCHAR(100) NOT NULL ,
    `update` INT(100) NOT NULL ,
    primary key(modified, country) ,
    FOREIGN KEY (modified) REFERENCES isos_alert_response(modified)
        ON UPDATE CASCADE
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_global_alert` (
    `modified` VARCHAR(100) NOT NULL ,
    `lang` VARCHAR(50) NOT NULL ,
    `update` INT(100) NOT NULL ,
    primary key(modified, lang) ,
    FOREIGN KEY (modified) REFERENCES isos_alert_response(modified)
        ON UPDATE CASCADE
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_region_alert` (
    `modified` VARCHAR(100) NOT NULL ,
    `id` INT(100) NOT NULL ,
    `lang` VARCHAR(50) NOT NULL ,
    `name` VARCHAR(100) NOT NULL ,
    `update` INT(100) NOT NULL ,
    primary key(modified, id),
    FOREIGN KEY (modified) REFERENCES isos_alert_response(modified)
        ON UPDATE CASCADE
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_update` (
    `herf` VARCHAR(100) NOT NULL ,
    `title` VARCHAR(100) NOT NULL ,
    `summary` TEXT NOT NULL ,
    `created` VARCHAR(100) NOT NULL ,
    `modified` VARCHAR(100) NOT NULL ,
    `longi` INT NOT NULL ,
    `lat` INT NOT NULL ,
    `id` INT(50) NOT NULL ,
    `version` INT NOT NULL ,
    `special_advisory`BOOLEAN NOT NULL ,
    `body`TEXT NOT NULL ,
    primary key(id)
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_update_cat` (
    `id` INT(50) NOT NULL ,
    `cat` INT(255) NOT NULL ,
    primary key(id , cat) ,
    FOREIGN KEY (cat) REFERENCES isos_category(id) ,
    FOREIGN KEY (id) REFERENCES isos_update(id)
) ENGINE = MyISAM;

CREATE TABLE `test`.`isos_category` (
    `id` INT(255) NOT NULL ,
    `desc` VARCHAR(100) NOT NULL ,
    primary key(id)
) ENGINE = MyISAM;

CREATE TABLE `test`.`admin_alert` ( 
    `id` VARCHAR(100) NOT NULL , 
    `email` VARCHAR(100) NOT NULL , 
    `creation_date` DATETIME NOT NULL , 
    `lat` DOUBLE NOT NULL , 
    `longi` DOUBLE NOT NULL ,
    `alert` TEXT NOT NULL ,
    `parent_id` VARCHAR(100) ,
    `child_id` VARCHAR(100) ,
    primary key(id)
) ENGINE = MyISAM;

ALTER TABLE `admin_alert` CHANGE `parent_id` `parent_id` VARCHAR(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000', CHANGE `child_id` `child_id` VARCHAR(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';