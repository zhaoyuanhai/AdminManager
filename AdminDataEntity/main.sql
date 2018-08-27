--用户和组的视图
CREATE VIEW V_UserGroup
AS
SELECT u.Id UserId,
       u.UserName,
       u.RealName,
       g.Id GroupId,
       g.Name GroupName,
       g.ParentId GroupParentId
FROM dbo.T_User u
    JOIN dbo.T_UserGroup ug
        ON u.Id = ug.UserId
    JOIN dbo.T_Group g
        ON g.Id = ug.GroupId;
GO

--用户和角色的视图
CREATE VIEW V_UserRole
AS
SELECT u.Id UserId,
       u.UserName,
       u.RealName,
       r.Id RoleId,
       r.Name RoleName
FROM dbo.T_User u
    JOIN dbo.T_UserRole ur
        ON ur.UserId = u.Id
    JOIN dbo.T_Role r
        ON r.Id = ur.RoleId;
GO

--权限和菜单视图
CREATE VIEW V_AuthoirtyMenu
AS
SELECT au.Id AuahorityId,
       au.TypeId,
       m.Id MenuId,
       m.Title MenuTitle,
       m.Url MenuUrl,
       m.[Order] MenuOrder,
       m.ParentId MenuParentId,
       m.Icon MenuIcon
FROM dbo.T_Authority au
    JOIN dbo.T_AuthorityMenu aumenu
        ON au.Id = aumenu.AuthorityId
    JOIN dbo.T_Menu m
        ON m.Id = aumenu.MenuId
WHERE au.TypeId = 1;
GO

--权限和操作按钮视图
CREATE VIEW V_AuthorityOperation
AS
SELECT au.Id AuthorityId,
       au.TypeId,
       op.Id OperationId,
       op.Icon OperationIcon,
       op.Event OperationEvent,
       op.ClassName OperationClassName
FROM T_Authority au
    JOIN T_AuthorityOperation auop
        ON au.Id = auop.AuthorityId
    JOIN T_Operation op
        ON op.Id = auop.OperationId
WHERE au.TypeId = 2;
GO

--获取某一个用户所在的所有分组
CREATE PROC P_GetUserGroupByUserId @userId INT
--用户Id
AS
BEGIN;
    WITH cte
    AS (SELECT gr.*,
               0 AS level
        FROM dbo.T_Group gr
            JOIN V_UserGroup ug
                ON gr.Id = ug.GroupId
        WHERE ug.UserId = @userId
        UNION ALL
        SELECT g.*,
               cte.level + 1
        FROM dbo.T_Group g
            INNER JOIN cte
                ON g.ParentId = cte.Id)
    SELECT *
    FROM cte;
END;
GO

--获取某一个组向上所继承的角色
CREATE PROCEDURE P_GetRoleByGroupId @groupId INT
--组Id
AS
BEGIN;
    WITH cte
    AS (SELECT g.*,
               0 AS level
        FROM dbo.T_Group g
        WHERE g.Id = 1
        UNION ALL
        SELECT g.*,
               cte.level + 1
        FROM dbo.T_Group g
            JOIN cte
                ON g.Id = cte.ParentId)
    SELECT r.Id RoleId,
           r.Name RoleName,
           c.Id GroupId,
           c.Name GroupName,
           c.level
    FROM cte c
        JOIN dbo.V_RoleGroup rg
            ON c.Id = rg.GroupId
        JOIN dbo.T_Role r
            ON r.Id = rg.RoleId;
END;
GO

--创建删除菜单的触发器
CREATE TRIGGER Tgr_DeleteMenu
ON T_Menu
INSTEAD OF DELETE
AS
--删除关联的相关信息
DELETE dbo.T_AuthorityMenu
FROM dbo.T_AuthorityMenu am
    JOIN Deleted d
        ON am.MenuId = d.Id;

--删除子目录数据
WITH cte_menu
AS (SELECT m.Id,
           m.Title
    FROM dbo.T_Menu m
        JOIN Deleted d
            ON m.Id = d.Id
    UNION ALL
    SELECT m.Id,
           m.Title
    FROM dbo.T_Menu m
        JOIN cte_menu
            ON m.ParentId = cte_menu.Id)
DELETE dbo.T_Menu
FROM dbo.T_Menu m
    JOIN cte_menu
        ON m.Id = cte_menu.Id;
GO

--创建添加菜单的触发器
CREATE TRIGGER Tgr_CreateMenu
ON T_Menu
FOR INSERT
AS
--修改排序字段为MenuId
UPDATE dbo.T_Menu
SET [Order] = m.Id
FROM dbo.T_Menu m
    JOIN Inserted temp
        ON m.Id = temp.Id;

--往权限表里添加一条菜单记录
INSERT INTO dbo.T_Authority
(
    Name,
    _CreateDate,
    _UpdateDate,
    TypeId
)
VALUES
(   N'',       -- Name - nvarchar(20)
    GETDATE(), -- _CreateDate - datetime
    GETDATE(), -- _UpdateDate - datetime
    1          -- TypeId - int
    );

--关联菜单和权限
DECLARE @authorityId INT = @@IDENTITY;
INSERT INTO dbo.T_AuthorityMenu
(
    [AuthorityId],
    [MenuId]
)
SELECT @authorityId,
       Id
FROM Inserted;
GO

--创建添加按钮的触发器
CREATE TRIGGER Tgr_CreateOperation
ON dbo.T_Operation
FOR INSERT
AS
--往权限表里插入一条操作按钮记录
INSERT INTO dbo.T_Authority
(
    Name,
    TypeId,
    _CreateDate,
    _UpdateDate
)
VALUES
(   N'',       -- Name - nvarchar(20)
    2,         -- TypeId - int
    GETDATE(), -- _CreateDate - datetime
    GETDATE()  -- _UpdateDate - datetime
    )

--关联操作按钮和权限
DECLARE @authorityId INT = @@IDENTITY
INSERT INTO	dbo.T_AuthorityOperation
(
  [AuthorityId],
   [OperationId]
)
SELECT @authorityId,ID
FROM Inserted
GO	

--创建删除按钮的触发器
