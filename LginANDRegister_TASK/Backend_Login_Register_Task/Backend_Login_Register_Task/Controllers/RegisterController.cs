using AutoMapper;
using Backend_Login_Register_Task.Models;
using Backend_Login_Register_Task.Models.DTO;
using Backend_Login_Register_Task.Models.ViewModel;
using Backend_Login_Register_Task.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Controllers
{
    [Route("api/Register")]
    [ApiController]

   
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        private readonly IEncryptionRepository _encryptionRepository;

        public RegisterController(IRegisterRepository registerRepository,IMapper mapper, IEncryptionRepository encryptionRepository)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
            _encryptionRepository = encryptionRepository;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _registerRepository.IsUniqueUser(registerDto.Username);
                if (!isUniqueUser) return BadRequest("User In Use");

                var reg = _mapper.Map<RegisterDto, Register>(registerDto);
                registerDto.Password = _encryptionRepository.EncryptPassword(registerDto.Password);

                var UserInfo = _registerRepository.Register(registerDto.Username, registerDto.Password);
                if (UserInfo == null) return BadRequest();
            }
            return Ok(registerDto);
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            var login = _mapper.Map<LoginDto, LoginVM>(loginDto);

            var User = _registerRepository.Authenticate(login.UserName, login.UserPassword);
            loginDto.UserPassword = _encryptionRepository.EncryptPassword(loginDto.UserPassword);

            if (User == null)
                return BadRequest("Wrong user/Pwd");
            return Ok(loginDto);
        }
    }
}



