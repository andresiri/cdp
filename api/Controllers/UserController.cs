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

        public UserController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        [AllowAnonymousAttribute]
        [Route("api/user")]
        public JsonResult Create([FromBody]User obj)
        {
            try
            {
                var op = new CreateUserOp(_unitOfWork);
                var newUser = op.Execute(obj);

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