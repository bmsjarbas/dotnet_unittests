public class UserController : ApiController
{
    private UserRepository _userRepository;

    public UserController()
    {
        _userRepository = new UserRepository();
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
