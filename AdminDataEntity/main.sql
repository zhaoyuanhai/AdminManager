--�û��������ͼ
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

--�û��ͽ�ɫ����ͼ
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

--Ȩ�޺Ͳ˵���ͼ
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

--Ȩ�޺Ͳ�����ť��ͼ
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

--��ȡĳһ���û����ڵ����з���
CREATE PROC P_GetUserGroupByUserId @userId INT
--�û�Id
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

--��ȡĳһ�����������̳еĽ�ɫ
CREATE PROCEDURE P_GetRoleByGroupId @groupId INT
--��Id
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

--����ɾ���˵��Ĵ�����
CREATE TRIGGER Tgr_DeleteMenu
ON T_Menu
INSTEAD OF DELETE
AS
--ɾ�������������Ϣ
DELETE dbo.T_AuthorityMenu
FROM dbo.T_AuthorityMenu am
    JOIN Deleted d
        ON am.MenuId = d.Id;

--ɾ����Ŀ¼����
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

--������Ӳ˵��Ĵ�����
CREATE TRIGGER Tgr_CreateMenu
ON T_Menu
FOR INSERT
AS
--�޸������ֶ�ΪMenuId
UPDATE dbo.T_Menu
SET [Order] = m.Id
FROM dbo.T_Menu m
    JOIN Inserted temp
        ON m.Id = temp.Id;

--��Ȩ�ޱ������һ���˵���¼
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

--�����˵���Ȩ��
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

--������Ӱ�ť�Ĵ�����
CREATE TRIGGER Tgr_CreateOperation
ON dbo.T_Operation
FOR INSERT
AS
--��Ȩ�ޱ������һ��������ť��¼
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

--����������ť��Ȩ��
DECLARE @authorityId INT = @@IDENTITY
INSERT INTO	dbo.T_AuthorityOperation
(
  [AuthorityId],
   [OperationId]
)
SELECT @authorityId,ID
FROM Inserted
GO	

--����ɾ����ť�Ĵ�����
