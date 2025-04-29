//using Azure;
//using Microsoft.EntityFrameworkCore;
//using WebApi8_Scheduling.Data;
//using WebApi8_Scheduling.Dto.User;
//using WebApi8_Scheduling.Models;

//namespace WebApi8_Scheduling.Services.User
//{
//    public class EnterpriseService : IEnterpriseInterface
//    {
//        private readonly AppDbContext _context;

//        public EnterpriseService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ResponseModel<EnterpriseModel>> CreateEnterprise(EnterpriseCreateDto userCreateDto)
//        {
//            ResponseModel<EnterpriseModel> respost = new ResponseModel<EnterpriseModel>();

//            try
//            {
//                //var userExist = await _context.Enterprise
//                //    .FirstOrDefaultAsync(userBanco => userBanco.Login == userCreateDto.Login);

//                //if(userExist != null)
//                //{
//                //    respost.Mensagem = "User existent, try with another login please";
//                //    return respost;
//                //}

//                var newUser = new EnterpriseModel
//                {
//                    Login = userCreateDto.Login,
//                    Password = userCreateDto.Password,
//                    Email = userCreateDto.Email,
//                };

//                _context.Enterprise.Add(newUser);
//                _context.SaveChanges();

//                respost.Dados = newUser;

//                respost.Mensagem = "User create successfull!";
//                return respost;

//            }
//            catch (Exception ex)
//            {
//                respost.Mensagem = ex.Message;
//                respost.Status = false;
//                return respost;
//            }
//        }

//        public async Task<ResponseModel<EnterpriseModel>> LoginEnterprise(EnterpriseLoginDto userLoginDto)
//        {
//            ResponseModel<EnterpriseModel> respost = new ResponseModel<EnterpriseModel>();

//            try
//            {
//                var user = await _context.Enterprise
//                    .FirstOrDefaultAsync(userBanco =>
//                        userBanco.Login == userLoginDto.Login &&
//                        userBanco.Password == userLoginDto.Password);

//                if (user == null)
//                {
//                    var loginExists = await _context.Enterprise
//                        .AnyAsync(userBanco => userBanco.Login == userLoginDto.Login);

//                    respost.Mensagem = loginExists ? "Incorrect password" : "Login not found";
//                    respost.Status = false;
//                    return respost;
//                }

//                respost.Dados = new EnterpriseModel
//                {
//                    Id = user.Id,
//                    Login = user.Login,
//                    Email = user.Email
//                };

//                respost.Mensagem = "Login successful!";
//                respost.Status = true;
//                return respost;
//            }
//            catch (Exception ex)
//            {
//                respost.Mensagem = ex.Message;
//                respost.Status = false;
//                return respost;
//            }
//        }
//    }
//}
