public class UserController : ApiController
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IHttpActionResult FindByID(int id)
    {
        var user = _userRepository.findByID(id);
        if(user is null)
            return NotFound();
        return Ok(user); 
    }
}
