using PruebaFinaktiva.Models;
using PruebaFinaktiva.Models.ViewModels.ResponseVM;
using PruebaFinaktiva.ViewModel;
using PruebaFinaktiva.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPruebaFinaktivaPI.Models.ViewModels.ResponseVM;


namespace PruebaFinaktiva.Repositories.Users
{
    public class UserRepositories
    {
        FinaktivaTwoContext DB;
        public UserRepositories(FinaktivaTwoContext context)
        {
            DB = context;
        }
        public BasicResponseVM deleteById(int id)
        {
            var userToDelete = DB.User.Where(X => X.Id == id).FirstOrDefault();

            if (userToDelete == null)
                return new BasicResponseVM(400, "El usuario no existe.");

            userToDelete.Status = 0;
            DB.User.Update(userToDelete);
            bool delete = DB.SaveChanges() > 0;

            if (delete)
                return new BasicResponseVM(200, "Usuario eliminado.");
            else
                return new BasicResponseVM(400, "No se pudo eliminar el usuario.");
        }

        public BasicResponseVM updateById(int id,UserVM userVM)
        {
            var userToUpdate = DB.User.Where(X => X.Id == id).FirstOrDefault();

            if (userToUpdate == null)
                return new BasicResponseVM(400, "El usuario no existe.");

            userToUpdate.Username = userVM.Username;
            userToUpdate.Password = userVM.Password;
            userToUpdate.IdRole = userVM.IdRole;
            DB.User.Update(userToUpdate);
            bool update = DB.SaveChanges() > 0;

            if (update)
                return new BasicResponseVM(200, "Usuario Actualizado.");
            else
                return new BasicResponseVM(400, "No se pudo Actualizar el usuario.");
        }
        public UniqueModelResponse<UserVM> getById(int id)
        {
            throw new NotImplementedException();
        }
        public ListModelResponseVM<UserVM> getList()
        {
            var personList = (from p in DB.User
                              select new UserVM()
                              {
                                  Id = p.Id,
                                  Username = p.Username,
                                  Password = p.Password,
                                  IdRole = p.IdRole
                              }).ToList();

            return new ListModelResponseVM<UserVM>(200, $"Se encontraron {personList.Count} registros", personList);
        }
        public BasicResponseVM insertNew (UserVM userVM)
        {
            User new_User = new User()
            {
                Username = userVM.Username,
                Password = userVM.Password,
                IdRole = userVM.IdRole
            };

            DB.User.Add(new_User);
            int saveData = DB.SaveChanges();

            if (saveData > 0)
                return new BasicResponseVM(200, "Se creó la persona con éxito.");
            else
                return new BasicResponseVM(400, "No se pudo crear el registro de la persona.");
        }
        public bool validateUser(UserTokenVM loginToken)
        {
            int validarUser = DB.User.Where(t => t.Username == loginToken.Username && t.Password == loginToken.Password).Count();

            return validarUser == 0 ? false : true;
        }
        public string validateRole(UserTokenVM loginToken)
        {
            int validaRole = DB.User.Where(t => t.Username == loginToken.Username && t.Password == loginToken.Password && t.IdRole == 1).Count();

            return validaRole == 0 ? "0" : "1";
        }
    }

   
}
