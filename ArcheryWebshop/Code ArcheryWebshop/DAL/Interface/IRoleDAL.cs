using DAL.DTO;

namespace DAL.Interface;

public interface IRoleDAL
{
    RoleDTO GetRoleByID(int id);
    RoleDTO GetRoleByName(string name);
    List<RoleDTO> GetAllRoles();

}