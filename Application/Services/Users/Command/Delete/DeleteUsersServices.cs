using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;

namespace Store.Application.Services.Users.Command.Delete
{
    public class DeleteUsersServices : IDeleteUsersServices
    {
        private readonly IDataBaseContext _dataBaseContext;

        public DeleteUsersServices(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(DeleteUsersDto request)
        {
            if (request.Id != null)
            {
                var user = _dataBaseContext.Users.Find(request.Id);
                if (user == null)
                    return new ResultDto() { IsSuccess = false, Message = "کاربر یافت نشد" };

                user.IsRemoved = true;
                user.RemoveDate = DateTime.Now;
                _dataBaseContext.SaveChanges();
            }

            return new ResultDto() { IsSuccess = true, Message = "کاربر با موفقیت حذف شد" };

        }

    }


}
