CREATE TABLE [dbo].[Person](
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL
) ON [PRIMARY]
GO

--需要先安装依赖包：
--Microsoft.EntityFrameworkCore
--Microsoft.EntityFrameworkCore.SqlServer
--Microsoft.EntityFrameworkCore.Tools

--Scaffold-DbContext 'Data Source=PC-20201104WQRT;initial catalog=Test;user id=sa;password=zbhxn389906;' Microsoft.EntityFrameworkCore.SqlServer -Tables Person
