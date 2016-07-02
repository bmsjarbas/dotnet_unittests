public class UserControllerTests
{
    private IMock<IUserRepository> _mockUserRepository;

    [SetUp]
    private Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
    }
    private User ValidUser(int id, string name)
    {
        return new User(){ Id = id, Name = name };
    } 
    private void SetupToUserNotFound()
    {
        _mockUserRepository.Setup(method => method.FindByID(10)).Returns(null);
    }   
    private void SetupValidUser()
    {
        _mockUserRepository.Setup(method => method.FindByID(1))
            .Returns(ValidUser(1, "Jarbas"));
    }

    [Test]
    public void WhenUserDoesntExistsShouldReturn404HttpStatusCode()
    {
        SetupToUserNotFound();
        var userController = new UserController(_mockUserRepository.Object);
        var httpActionResult = userController.findByID(10);
        Assert.InstanceOf(httpActionResult, typeof(NotFoundResult));
    }

    [Test]
    public void WhenUserExistsShouldReturnAValidUser()
    {

    }
        
}
