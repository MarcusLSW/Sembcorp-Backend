# Sembcorp-Backend
Contains the ASP.NET Web Server and MS SQL Server 2012 Database codes

# Configuration
The following section will explain the necessary backend configuration for setting up the web server and database server

## MS SQL Server 2012
<i>Refer to the guide at blogs.perficient.com/ibm/2012/11/02/how-to-install-sql-server-2012-management-studio-express-on-windows-7-pc-and-create-a-local-sql-server-database/</i>

<b>Configure DB Instance</b>
1. Download and install Microsoft SQL Server 2012
2. Upon doing so, open up your *Command Prompt* and key in the following command `SqlLocalDb Info`. You should see "v11.0" as your response
3. Create a local instance with the syntax `SqlLocalDb create <DatabaseInstanceName>`. For this project, I will use `SqlLocalDb create SembcorpSecureInstance`
4. Start the database instance with `SqlLocalDb start SembcorpSecureInstance`
5. To check for the instance information, use the command `SqlLocalDb info SembcorpSecureInstance`

<b>Apply SQLCMD to Create Database for the Instance</b>
<i>Ensure that you have successfully configured your DB Instance before this point</i>
1. Change your director within the `cmd` window to the following path: `cd C:\Program Files\Microsoft SQL Server\110\Tools\Binn\`
2. Connect to the created DB Instance with SQLCMD (SQL Command Line) by entering the following command `sqlcmd -S (localdb)\SembcorpSecureInstance`
3. You will be presented with a stdin interface. Key in the following
1> SELECT @@VERSION;
2> GO
The above two lines will now start the SQLCMD within the `SembcorpSecureInstance` database instance and the `@@VERSION` will return the version, architecture, OS version and build date for current instance.

<b>Writing SQL Query</b>
<i>Ensure that you have successfully applied SQLCMD before this point</i>
1. To create a database, you need to type int he command with the syntax `CREATE DATABASE DBNAME`. For this project, I will use `CREATE DATABASE SEMBCORP_SECURE;`. Follow the following commands:
1> CREATE DATABASE SEMBCORP_SECURE;
2> GO
1> USE SEMBCORP_SECURE;
2> GO
You should see the response *Changed database context to 'SEMBCORP_SECURE'.*
2. Your database will now be created
3. Validate your install by
