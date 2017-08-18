CREATE TABLE admin_alert (
  id varchar(100) NOT NULL,
  email varchar(100) NOT NULL,
  creation_date datetime NOT NULL,
  lat float NOT NULL,
  longi float NOT NULL,
  alert text NOT NULL,
  parent_id varchar(100) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  child_id varchar(100) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'
) 

--
-- Dumping data for table admin_alert
--

INSERT INTO admin_alert (id, email, creation_date, lat, longi, alert, parent_id, child_id) VALUES
('ad3af573-3a0f-4c91-86b4-1ab72ae617ef', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('f2388c41-c720-46ab-892e-fc3dca2c7e9f', 'marcus.lee', '2017-08-09 07:15:15', 1.2323, 2.43434, 'TEST', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('d371f72d-b17c-458d-8823-d70ae35d5ce2', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000'),
('517b6b34-4b9a-4599-bb32-d0ac7baf6474', 'marcus.lee.2015@smu.edu.sg', '2017-08-08 05:11:13', 1.0909, 2.123123, 'Come back now', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000');

-- --------------------------------------------------------

--
-- Table structure for table emergency_contact
--

-- --------------------------------------------------------

--
-- Table structure for table emergency_contact
--

CREATE TABLE emergency_contact (
  location_name varchar(100) NOT NULL,
  region_code int NOT NULL,
  contact_number int NOT NULL,
  lat float NOT NULL,
  longi float NOT NULL,
  [desc] text NOT NULL
);

--
-- Dumping data for table emergency_contact
--

INSERT INTO emergency_contact (location_name, region_code, contact_number, lat, longi, [desc]) VALUES
('Sembcorp Singapore', 65, 94561238, 1.00021545, 2.32326613, 'This is the head office in Singapore near to SMU'),
('Sembcorp Malaysia', 60, 95462368, 1.22, 3.6265656, 'The office of sembcorp in Malaysia'),
('Sembcorp India', 89, 55525288, 3.66696, 6.33232955, 'The is the office in sembcorp');

-- --------------------------------------------------------

--
-- Table structure for table isos_alert_response
--

CREATE TABLE isos_alert_response (
  modified varchar(100) NOT NULL,
  globals varchar(100) NOT NULL,
  regions varchar(100) NOT NULL,
  countires varchar(100) NOT NULL
);

-- --------------------------------------------------------

--
-- Table structure for table isos_category
--

CREATE TABLE isos_category (
  id int NOT NULL,
  [desc] varchar(100) NOT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table isos_country_alert
--

CREATE TABLE isos_country_alert (
  modified varchar(100) NOT NULL,
  country varchar(100) NOT NULL,
  lang varchar(50) NOT NULL,
  name varchar(100) NOT NULL,
  [update] int NOT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table isos_global_alert
--

CREATE TABLE isos_global_alert (
  modified varchar(100) NOT NULL,
  lang varchar(50) NOT NULL,
  [update] int NOT NULL
);

-- --------------------------------------------------------

--
-- Table structure for table isos_region_alert
--

CREATE TABLE isos_region_alert (
  modified varchar(100) NOT NULL,
  id int NOT NULL,
  lang varchar(50) NOT NULL,
  name varchar(100) NOT NULL,
  [update] int NOT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table isos_update
--

CREATE TABLE isos_update (
  herf varchar(100) NOT NULL,
  title varchar(100) NOT NULL,
  summary text NOT NULL,
  created varchar(100) NOT NULL,
  modified varchar(100) NOT NULL,
  longi int NOT NULL,
  lat int NOT NULL,
  id int NOT NULL,
  [version] int NOT NULL,
  special_advisory tinyint NOT NULL,
  body text NOT NULL
);

-- --------------------------------------------------------

--
-- Table structure for table isos_update_cat
--

CREATE TABLE isos_update_cat (
  id int NOT NULL,
  cat int NOT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table sos_message
--

CREATE TABLE sos_message (
  uuid varchar(100) NOT NULL,
  email varchar(100) NOT NULL,
  lat float NOT NULL,
  long float NOT NULL,
  initialisationDate datetime NOT NULL,
  [message] text NOT NULL,
  is_resloved tinyint NOT NULL,
  last_update datetime NOT NULL
);

--
-- Dumping data for table sos_message
--

INSERT INTO sos_message (uuid, email, lat, long, initialisationDate, [message], is_resloved, last_update) VALUES
('b932d34b-cd55-485a-8f56-b0ffc75eb716', 'marcus.lee.2015@smu.edu.sg', 1.29027, 103.851959, '2017-08-05 10:00:00', 'I need help I am trapped in school!', 0, '2017-08-05 10:03:00');

-- --------------------------------------------------------

--
-- Table structure for table user
--

CREATE TABLE [user] (
  email varchar(100) NOT NULL,
  name varchar(100) NOT NULL,
  contact_num int DEFAULT NULL,
  region_code int DEFAULT NULL,
  is_admin tinyint NOT NULL,
  is_male tinyint NOT NULL,
  lat float DEFAULT NULL,
  longi float DEFAULT NULL
) ;

--
-- Dumping data for table user
--

INSERT INTO [user] (email, name, contact_num, region_code, is_admin, is_male, lat, longi) VALUES
('marcus.lee.2015@smu.edu.sg', 'Marcus Lee', 98567423, 65, 0, 1, 1.29027, 103.851959),
('jaren.lim.2015@smu.edu.sg', 'Jaren Lim', 97856412, 65, 1, 1, 1.29027, 103.851959);

-- --------------------------------------------------------

--
-- Table structure for table user_reg
--

CREATE TABLE user_reg (
  email varchar(100) NOT NULL,
  reg_id varchar(100) NOT NULL
) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table admin_alert
--
ALTER TABLE admin_alert
  ADD PRIMARY KEY (id);

--
-- Indexes for table emergency_contact
--
ALTER TABLE emergency_contact
  ADD PRIMARY KEY (region_code,contact_number);

--
-- Indexes for table isos_alert_response
--
ALTER TABLE isos_alert_response
  ADD PRIMARY KEY (modified);

--
-- Indexes for table isos_category
--
ALTER TABLE isos_category
  ADD PRIMARY KEY (id);

--
-- Indexes for table isos_country_alert
--
ALTER TABLE isos_country_alert
  ADD PRIMARY KEY (modified,country);

--
-- Indexes for table isos_global_alert
--
ALTER TABLE isos_global_alert
  ADD PRIMARY KEY (modified,lang);

--
-- Indexes for table isos_region_alert
--
ALTER TABLE isos_region_alert
  ADD PRIMARY KEY (modified,id);

--
-- Indexes for table isos_update
--
ALTER TABLE isos_update
  ADD PRIMARY KEY (id);

--
-- Indexes for table isos_update_cat
--
ALTER TABLE isos_update_cat
  ADD PRIMARY KEY (id,cat),
  ADD KEY cat (cat);

--
-- Indexes for table sos_message
--
ALTER TABLE sos_message
  ADD PRIMARY KEY (uuid);

--
-- Indexes for table user
--
ALTER TABLE [user]
  ADD PRIMARY KEY (email);

--
-- Indexes for table user_reg
--
ALTER TABLE user_reg
  ADD PRIMARY KEY (email,reg_id);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
SHA1: 4D:F2:08:61:C4:5D:DF:C5:A7:45:A4:02:8C:80:D2:21:52:C8:66:1A