
USE [master];

DECLARE @kill varchar(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('aspnet-FPT_Training_4.0-20211231092456')

EXEC(@kill);

drop database [aspnet-FPT_Training_4.0-20211231092456]