using System;
using CartolaDaPelada.Controllers;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using api.ViewModel;
using Microsoft.AspNetCore.Authorization;
using api.Op.User;
using api.Context.Transaction;

namespace api.Controllers
{
    public class UserController : BaseController
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly CreateUserOp _createUserOp;

        public UserController(IMapper mapper, IUnitOfWork unitOfWork, CreateUserOp createUserOp)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _createUserOp = createUserOp;
        }

        [HttpPost]
        [AllowAnonymousAttribute]
        [Route("api/users")]
        public JsonResult Create([FromBody]User obj)
        {
            try
            {
                var newUser = _createUserOp.Execute(obj);

                var userViewModel = _mapper.Map<UserViewModel>(newUser);

                return Json(userViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }
    }
}