--用户和组的视图
CREATE VIEW V_UserGroup
AS
SELECT 
u.Id UserId,
u.UserName,
u.RealName,
g.Id GroupId,
g.Name GroupName,
g.ParentId GroupParentId
 FROM dbo.T_User u
JOIN dbo.T_UserGroup ug ON u.Id=ug.UserId
JOIN dbo.T_Group g ON g.Id= ug.GroupId
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

--获取某一个用户所在的所有分组
CREATE PROC P_GetUserGroupByUserId
@userId INT --用户Id
AS
BEGIN
WITH cte AS
(
	SELECT gr.*,0 AS level FROM dbo.T_Group gr JOIN V_UserGroup
	ug ON gr.Id= ug.GroupId WHERE ug.UserId=@userId
	UNION ALL
	SELECT g.*,cte.level+1 FROM dbo.T_Group g INNER JOIN cte
	ON g.ParentId = cte.Id
)
SELECT * FROM cte
END
GO	

--获取某一个组向上所继承的角色
CREATE PROCEDURE P_GetRoleByGroupId
@groupId INT --组Id
AS
BEGIN
WITH cte AS
(
	SELECT g.*,0 AS level FROM dbo.T_Group g
	WHERE g.Id= 1
	UNION ALL
	SELECT g.*,cte.level+1 FROM dbo.T_Group g JOIN cte 
	ON g.Id= cte.ParentId
)
SELECT 
r.Id RoleId,
r.Name RoleName,
c.Id GroupId,
c.Name GroupName,
c.level
 FROM cte c JOIN dbo.V_RoleGroup rg
ON c.Id = rg.GroupId
JOIN dbo.T_Role r ON r.Id=rg.RoleId
END	

