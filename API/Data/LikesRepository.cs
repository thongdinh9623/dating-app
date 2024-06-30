using API.Helpers;

namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion

        #region Constructors
        public LikesRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Public methods
        public async Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams)
        {
            IQueryable<AppUser> users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            IQueryable<UserLike> likes = _context.Likes.AsQueryable();

            if (likesParams.Predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == likesParams.UserId);
                users = likes.Select(like => like.LikedUser);
            }

            if (likesParams.Predicate == "likedBy")
            {
                likes = likes.Where(like => like.LikedUserId == likesParams.UserId);
                users = likes.Select(like => like.SourceUser);
            }

            IQueryable<LikeDto> likedUsers = users.Select(user => new LikeDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = user.City,
                Id = user.Id
            });

            return await PagedList<LikeDto>.CreateAsync(likedUsers, likesParams.PageNumber, likesParams.PageSize);
        }

        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await _context.Likes.FindAsync(sourceUserId, likedUserId);
        }

        public async Task<AppUser> GetUserWithLikes(int userId)
        {
            return await _context.Users
                .Include(x => x.LikedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
        #endregion
    }
}
