using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers;

public class RoleService
{
    private readonly IRoleDAL _roleDAL;

    public RoleService(IRoleDAL roleDAL)
    {
        _roleDAL = roleDAL;
    }
    
    public List<Role> GetAllRoles()
    {
        List<RoleDTO> roleDTOs = _roleDAL.GetAllRoles();
        List<Role> roles = new List<Role>();

        foreach (RoleDTO roleDTO in roleDTOs)
        {
            roles.Add(MapToRole(roleDTO));
        }

        return roles;
    }

    
    public Role GetRoleByID(int roleID)
    {
        RoleDTO roleDTO = _roleDAL.GetRoleByID(roleID);
        return MapToRole(roleDTO);
    }

    public Role GetRoleByName(string roleName)
    {
        RoleDTO roleDTO = _roleDAL.GetRoleByName(roleName);
        return MapToRole(roleDTO);
    }
    
    private Role MapToRole(RoleDTO roleDTO)
    {
        if (roleDTO == null)
        {
            return null;
        }

        return new Role
        {
            ID = roleDTO.ID,
            Name = roleDTO.Name,
        };
    }
}