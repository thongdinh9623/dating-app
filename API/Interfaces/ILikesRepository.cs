using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);

        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);

        Task<AppUser> GetUserWithLikes(int userId);
    }
}
