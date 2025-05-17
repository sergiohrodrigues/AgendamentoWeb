using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.User;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<UserModel>> CreateUser(UserCreateDto pUser)
    {
        ResponseModel<UserModel> respost = new ResponseModel<UserModel>();

        try
        {
            var newUser = new UserModel()
            {
                Email = pUser.Email,
                Password = pUser.Password,
            };
            
            _context.User.Add(newUser);
            _context.SaveChanges();

            respost.Dados = newUser;
            respost.Mensagem = "User created successfully.";

            return respost;
        }
        catch (Exception ex)
        {
            respost.Mensagem = ex.Message;
            respost.Status = false;
            return respost;
        }

    }

    public async Task<ResponseModel<UserModel>> Login(LoginDto pUser)
    {
        ResponseModel<UserModel> respost = new ResponseModel<UserModel>();
        
        try
        {
            var user = _context.User.FirstOrDefault(p => p.Email == pUser.Email && p.Password == pUser.Password);

            if (user == null)
            {
                respost.Mensagem = "User not found, email ou senha invalidos";
                return respost;
            }

            respost.Dados = user;
            respost.Mensagem = "User logged successfully.";

            return respost;
        }
        catch (Exception ex)
        {
            respost.Mensagem = ex.Message;
            respost.Status = false;
            return respost;
        }
    }
}