using Exhibitopia2.Domain.Enums;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Services;

Console.WriteLine("SALOM");

var userSer = new UserService();
var photoSer = new PhotoService();
var photoLikeSer = new UserService();
var photoCommentSer = new UserService();
var historySer = new InformationService();

var user1 = new UserCreationDto
{
    Bio = "bu bio",
    Fullname = "Axmadjonov Abdulloh",
    Password = "123",
    Username = "FindAbdulloh"
};
var user2 = new UserCreationDto
{
    Bio = "Mening bioyim",
    Fullname = "Kamolov Jasur",
    Password = "321",
    Username = "jasur"
};

var photo1 = new PhotoCreationDto
{
    AuthorId = 1,
    Category = PhotoCategories.Others,
    Description = "Bu menying birinchi photoyim",
    Name = "FirstPhoto",
    Privacy = PrivacyTypes.Public
};

var photo2 = new PhotoCreationDto
{
    AuthorId = 2,
    Category = PhotoCategories.CulinaryArts,
    Description = "Nima buligini bilmayman",
    Name = "Rasm",
    Privacy = PrivacyTypes.Public
};

var photoLike1 = new PhotoLikeCreationDto
{
    PhotoId = 1,
    UserId = 2
};

var photoComment1 = new PhotoCommentCreationDto
{
    PhotoId = 2,
    Text = "Bu menga yoqmadi",
    UserId = 1
};